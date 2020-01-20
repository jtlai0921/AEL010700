using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

public partial class LoginAuthenticate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //使用自訂的身份驗證事件
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        //將login控制項的登入帳號一律轉換為大寫
        userLogin.UserName = userLogin.UserName.ToUpper();

        //這段可自訂驗證的程序，若您已有帳號的資料庫，可以在這裡用ADO.NET的方式
        //連結自己的資料庫來驗證
        //取得Web.config中設定的資料庫連線字串
        string connString = WebConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();

        //或者也可以直接將連線字串寫在程式之中
        //string connString = "data source=.;initial catalog=aspnet4db;user id=sa;password=test";
        SqlCommand cmd = new SqlCommand("Select top 1 ID from UserAccount Where ID=@paramID and Password=@paramPwd", conn);
        cmd.Parameters.Add("@paramID", SqlDbType.NVarChar, 12).Value = userLogin.UserName;
        cmd.Parameters.Add("@paramPwd", SqlDbType.NVarChar, 12).Value = userLogin.Password;

        //若帳號及密碼符合則回傳一個Object型態（ID欄位）
        //故必須將Object轉型為字串
        string txtID = (string)cmd.ExecuteScalar();

        cmd.Dispose();
        conn.Close();
        conn.Dispose();

        //判斷txtID是否為空值，非空值則為false，空值為true
        if (!string.IsNullOrEmpty(txtID))
        {
            e.Authenticated = true;	//驗證通過
        }
        else
        {
            e.Authenticated = false;//驗證失敗
        }
    }
}
