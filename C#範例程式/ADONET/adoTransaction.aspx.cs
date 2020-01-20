using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class sqldsTransaction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

	protected void btnInsert_Click(object sender, EventArgs e)
	{
		InsertRecord();	//新增員工資料
	}

	//新增資料庫
	protected void InsertRecord()
	{
		string connString = WebConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
		SqlConnection conn = new SqlConnection(connString);
		conn.Open();
		SqlTransaction tran = conn.BeginTransaction();	//建立交易Transaction

		string strSQL = "INSERT INTO Employees(FirstName, LastName, City, Address) values (@paramFirstName,@paramLastName,@paramCity,@paramAddress)";
		SqlCommand cmd = new SqlCommand(strSQL, conn,tran);		//建立SqlCommand

		try
		{
			cmd.Parameters.Add("@paramFirstName", SqlDbType.NVarChar, 20).Value = txtFirstName.Text;
			cmd.Parameters.Add("@paramLastName", SqlDbType.NVarChar, 10).Value = txtLastName.Text;
			cmd.Parameters.Add("@paramCity", SqlDbType.NVarChar, 15).Value = txtCity.Text;
			cmd.Parameters.Add("@paramAddress", SqlDbType.NVarChar, 60).Value = txtAddress.Text;
			cmd.ExecuteNonQuery();
			tran.Commit();		//確認交易
            txtMsg.Text = "新增資料成功,交易確認!";
		}
		catch(Exception ex)
		{
			tran.Rollback();   //交易回復
            txtMsg.Text = "新增資料失敗,交易Rollback!,失敗原因為：" + ex.ToString();
		}

		finally
		{
			conn.Close();
			conn.Dispose();
			tran.Dispose();
			cmd.Dispose();
		}
	}
}
