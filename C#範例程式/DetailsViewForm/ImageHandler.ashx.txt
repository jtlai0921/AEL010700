<%@ WebHandler Language="C#" Class="ImageHandler" %>

using System;
using System.Web;
using System.IO;
using System.Configuration;

public class ImageHandler : IHttpHandler 
{
    public void ProcessRequest(HttpContext context)
    {
        //取得員工代號
        string EmployeeID=context.Request.QueryString["EmployeeID"];
        //透過ReadImage類別的GetImage()方法取得SQL Server中圖片資料
        //其圖片儲存在MemoryStream之中回傳
        MemoryStream ms = new ReadImage().GetImage(EmployeeID);
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