using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// SaveImageDB 的摘要描述
/// </summary>
public class SaveImages
{
	public SaveImages()
	{
	}

	//儲存照片到資料庫，沒有傳入員工代號
	public bool SaveImage(byte[] ImagesBinary)
	{
		bool TranStatus = false;

		//判斷FileUpload是否有指定檔案
		if (ImagesBinary.Length > 0)
		{
			//取得連線字串，並建立連線
			string connString = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
			SqlConnection conn = new SqlConnection(connString);
			conn.Open();
			SqlTransaction tran = conn.BeginTransaction();
			SqlCommand cmd = new SqlCommand("Update Employees set Photo=@paramPhoto where EmployeeID=9) ", conn);
			cmd.Transaction = tran;	//指定SqlCommand使用交易

			try
			{
				cmd.Parameters.Add("@paramPhoto", SqlDbType.Image).Value = ImagesBinary;
				cmd.ExecuteNonQuery();
				tran.Commit();		//確認交易
				TranStatus = true;
			}
			catch
			{
				tran.Rollback();	//回復交易
				TranStatus = false;
			}

			cmd.Dispose();
			conn.Close();
			conn.Dispose();
		}

		return TranStatus;
	}

}
