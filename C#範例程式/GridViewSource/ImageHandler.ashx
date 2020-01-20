<%@ WebHandler Language="C#" Class="ImageHandler" %>

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public class ImageHandler : IHttpHandler 
{
    //取得資料庫連線設定
    static ConnectionStringSettings connString = WebConfigurationManager.ConnectionStrings["NorthwindConnectionString"];

    public void ProcessRequest(HttpContext context)
    {
        MemoryStream ms=null;
        try
        {
            //取得員工代號
            string EmployeeID = context.Request.QueryString["EmployeeID"];
            //透過ReadImage類別的GetImage()方法取得SQL Server中圖片資料
            //建立Sql命令
            string strSQL = "Select Photo from Employees where EmployeeID=@paramEmployeeID";
            //建立SqlDataSource
            SqlDataSource sqldsPhoto = new SqlDataSource(connString.ConnectionString, strSQL);
            sqldsPhoto.SelectParameters.Add("paramEmployeeID", TypeCode.Int32, EmployeeID);
            //透過SqlDataSource進行查詢
            DataView dv = (DataView)sqldsPhoto.Select(DataSourceSelectArguments.Empty);
            //回傳DataView第一個Row的Photo欄位資料
            Byte[] PhotoImage = (Byte[])dv[0]["Photo"];
            ms = new MemoryStream(PhotoImage, 0, PhotoImage.Length);
        }
        catch
        {
        }
        
        if (ms != null)
        {
            //取得影像MemoryStream大小
            int bufferSize = (int)ms.Length;
            //建立 buffer
            byte[] buffer = new byte[bufferSize];
            //呼叫MemoryStream.Read，自MemoryStream 讀取至buffer，並傳回count
            int countSize = ms.Read(buffer, 0, bufferSize);
            //傳回影像buffer
            context.Response.OutputStream.Write(buffer, 0, countSize);
        }
    }
 
    public bool IsReusable 
    {
        get 
        {
            return false;
        }
    }
}