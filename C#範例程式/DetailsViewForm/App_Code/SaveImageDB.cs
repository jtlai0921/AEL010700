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
public class SaveImageDB
{
	public SaveImageDB()
	{
	}

	//儲存照片到資料庫，位移78個Bytes
	public bool SaveImageOffset(byte[] ImagesBinary)
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
			//配合原本Photo圖片都有位移78個Bytes
			byte[] Images = new byte[78 + ImagesBinary.Length];
			//將FileUpload的二進位資料複製到Images，並指定從78位置開始
			ImagesBinary.CopyTo(Images, 78);
			SqlCommand cmd = new SqlCommand("Update Employees set Photo=@paramPhoto where EmployeeID=14", conn);
			cmd.Transaction = tran;	//指定SqlCommand使用交易

			try
			{
				cmd.Parameters.Add("@paramPhoto", SqlDbType.Image).Value = Images;
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

	//儲存照片到資料庫，傳入特定員工代號
	public bool SaveImage(byte[] ImagesBinary,string txtEmployeeID)
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
			//配合原本Photo圖片都有位移78個Bytes
			byte[] Images = new byte[78 + ImagesBinary.Length];
			//將FileUpload的二進位資料複製到Images，並指定從78位置開始
			ImagesBinary.CopyTo(Images, 78);
			SqlCommand cmd = new SqlCommand("Update Employees set Photo=@paramPhoto where EmployeeID=@paramEmployeeID", conn);
			cmd.Parameters.Add("@paramEmployeeID",SqlDbType.Int,4).Value=Convert.ToInt32(txtEmployeeID);
			cmd.Transaction = tran;	//指定SqlCommand使用交易

			try
			{
				cmd.Parameters.Add("@paramPhoto", SqlDbType.Image).Value = Images;
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
