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

public partial class LoginTemplate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		//在Login控制項完成驗證程序，檢查是否通過驗證，若通過則顯示使用者姓名
        if (User.Identity.IsAuthenticated)
        {
            //顯示登入使用者名稱
            ((Label)UserLogin.FindControl("txtUserName")).Text = "歡迎你：" + User.Identity.Name;
        }
        else
        {
            ((Label)UserLogin.FindControl("txtUserName")).Text = "";
        }
    }

    //登入驗證前
	protected void UserLogin_LoggingIn(object sender, LoginCancelEventArgs e)
	{
		RequiredFieldValidator RV1 = (RequiredFieldValidator)UserLogin.FindControl("RV1");
		RV1.Enabled = true;
		RV1.Validate();		
		RequiredFieldValidator RV2 = (RequiredFieldValidator)UserLogin.FindControl("RV2");
		RV2.Enabled = true;
		RV2.Validate();
	}

	//驗證成功登入後
	protected void UserLogin_LoggedIn(object sender, EventArgs e)
	{
		((RequiredFieldValidator)UserLogin.FindControl("RV1")).Enabled = false;
		((RequiredFieldValidator)UserLogin.FindControl("RV2")).Enabled = false;
	}

	//登出
	protected void btnSignout_Click(object sender, ImageClickEventArgs e)
	{
		FormsAuthentication.SignOut();	//登出，刪除Cookie
		Response.Redirect("LoginTemplate.aspx");    
	}

	//顯示JavaScript訊息
	protected void UserLogin_LoginError(object sender, EventArgs e)
	{
		WebMessageBox.MessageBox.Show("帳號密碼錯誤!");
	}
}
