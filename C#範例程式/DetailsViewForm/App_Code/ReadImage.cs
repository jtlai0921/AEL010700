using System;
using System.Data;
using System.IO;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// ReadImage 的摘要描述
/// </summary>
public class ReadImage
{
	//取得資料庫連線設定
    static string connString = WebConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;

	//從byte 0開始，沒有位移78bytes
	public MemoryStream GetImage(string EmployeeID)
	{
		//建立Sql命令
		string strSQL = "Select Photo from Employees where EmployeeID=@paramEmployeeID";
		//建立SqlDataSource
		SqlDataSource sqldsPhoto = new SqlDataSource(connString, strSQL);
		sqldsPhoto.SelectParameters.Add("paramEmployeeID", TypeCode.Int32, EmployeeID);

		try
		{
			//透過SqlDataSource進行查詢
			DataView dv = (DataView)sqldsPhoto.Select(DataSourceSelectArguments.Empty);
			//回傳DataView第一個Row的Photo欄位資料
			Byte[] PhotoImage = (Byte[])dv[0]["Photo"];
			//回傳MemoryStream
			return new MemoryStream(PhotoImage,0, PhotoImage.Length);
		}
		catch
		{
			return null;
		}
	}

	//位移78bytes
	public MemoryStream GetImageOffset(string EmployeeID)
	{
		//建立Sql命令
		string strSQL = "Select Photo from Employees where EmployeeID=@paramEmployeeID";
		//建立SqlDataSource
		SqlDataSource sqldsPhoto = new SqlDataSource(connString.ConnectionString, strSQL);
		sqldsPhoto.SelectParameters.Add("paramEmployeeID",TypeCode.Int32,EmployeeID);

		try
		{
			//透過SqlDataSource進行查詢
			DataView dv = (DataView)sqldsPhoto.Select(DataSourceSelectArguments.Empty);
			//回傳DataView第一個Row的Photo欄位資料
			Byte[] PhotoImage = (Byte[])dv[0]["Photo"];	
			//回傳MemoryStream
			return new MemoryStream(PhotoImage,78,PhotoImage.Length-78);
		}
		catch
		{
			return null;
		}
	}
}
