using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class LoginAuthenticateCode : System.Web.UI.Page
{
    //建立Login控制項的實體
    System.Web.UI.WebControls.Login userLogin = new System.Web.UI.WebControls.Login();

    protected void Page_Load(object sender, EventArgs e)
    {
        setLoginControl();	//呼叫建立LoginControl
    }

    //建立Login控制項
    private void setLoginControl()
    {
        //設定Loin的Title
        userLogin.TitleText = "3C會員";
        userLogin.TitleTextStyle.BackColor = Color.DarkRed;
        userLogin.TitleTextStyle.ForeColor = Color.White;
        userLogin.InstructionText = "使用者登入";
        userLogin.ToolTip = "請輸入您的會員帳號密碼";
        userLogin.Width = Unit.Pixel(200);

        //設定驗證成功後所要導向的網頁
        userLogin.DestinationPageUrl = "LoginMessage.aspx";

        //設定Login控制項外觀
        userLogin.BackColor = Color.LightYellow;
        userLogin.BorderStyle = BorderStyle.Solid;
        userLogin.BorderWidth = Unit.Pixel(1);
        userLogin.Font.Size = 8;


        //設定使用者名稱及密碼文字
        userLogin.UserNameLabelText = "會員帳號:";
        userLogin.PasswordLabelText = "會員密碼:";
        userLogin.TextBoxStyle.BackColor = Color.LightBlue;	//設定TextBox背景
        userLogin.TextBoxStyle.Width = Unit.Pixel(80);	//設定TextBox寬度

        //設定登入按鈕
        userLogin.LoginButtonText = "登入";
        userLogin.LoginButtonStyle.BackColor = Color.LightPink;
        userLogin.LoginButtonStyle.Font.Size = 8;

        //設定記憶屬性
        userLogin.RememberMeText = "請記憶我的身份";

        //建立自訂的驗證事件
        userLogin.Authenticate += new AuthenticateEventHandler(userLogin_Authenticate);
        //將Login控制項加入Web Form
        Page.FindControl("form1").Controls.Add(userLogin);
    }

    //自訂驗證
    void userLogin_Authenticate(object sender, AuthenticateEventArgs e)
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
