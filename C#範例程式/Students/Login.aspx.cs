using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    //取得Web.config中的資料庫連線字串設定
    static string connString = WebConfigurationManager.ConnectionStrings["SchoolConnectionString"].ConnectionString;
    string userID = null;   //帳號
    bool? activeStatus = false;   //帳號啓用狀態

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.SetFocus("UserName");
    }

    //進行帳號密碼驗證比對
    protected void userLogin_Authenticate(object sender, AuthenticateEventArgs e)
    {
        //將login控制項的登入帳號一律轉換為大寫
        userLogin.UserName = userLogin.UserName.ToUpper();
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();

        //進行使用者帳號密碼與資料庫的比對
        SqlCommand cmd = new SqlCommand("Select top 1 ID,Permission,Role,Active from UserAccount Where ID=@paramID and Password=@paramPwd", conn);
        cmd.Parameters.Add("@paramID", SqlDbType.NVarChar, 12).Value = userLogin.UserName;
        cmd.Parameters.Add("@paramPwd", SqlDbType.NVarChar, 12).Value = userLogin.Password;
        SqlDataReader dr;

        try
        {
            dr = cmd.ExecuteReader();

            //如果成功查詢帳號資料
            if (dr.HasRows)
            {
                dr.Read();
                userID = dr[0].ToString();
                //設定Permission及Role的狀態資料
                Session["Permission"] = dr[1].ToString().Trim(); //CRUD權限
                Session["Role"] = dr[2].ToString(); //角色群組
                activeStatus = (bool)dr[3];
            }
        }
        finally
        {
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }

        //判斷帳號密碼比對結果是否有效
        if (!String.IsNullOrEmpty(userID))
        {
            if (activeStatus == true)
            {
                e.Authenticated = true;  //驗證通過
            }
            else
            {
                e.Authenticated = false; //驗證失敗
                if (activeStatus == false)
                {
                    userLogin.FailureText = "此帳號被停用！";
                }
            }
        }
        else
        {
            e.Authenticated = false; //驗證失敗
            userLogin.FailureText = "帳號或密碼不符！";
        }
    }
}