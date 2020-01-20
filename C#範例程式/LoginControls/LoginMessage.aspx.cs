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

public partial class LoginMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            Response.Write(User.Identity.Name + "您已通過身份驗證！");
        }
        else
        {
            //傳統導回Login.aspx做法(缺乏彈性)
            //Response.Redirect("Login.aspx");
            //導向Web.config中預設的登入網頁(優先使用此法)
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}
