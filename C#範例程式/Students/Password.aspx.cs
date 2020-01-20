using System;
using System.Web.UI.WebControls;

public partial class Password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated == true)
        {
            //以登入帳號ID傳入SqlDataSource做查詢
            sqlPassword.SelectParameters["paramID"].DefaultValue = User.Identity.Name;
        }
    }

    //判斷密碼是否成新成功
    protected void sqlPassword_Updated(object sender, SqlDataSourceStatusEventArgs e)
    {
        if (e.AffectedRows >= 1)
        {
            dvAccount.FooterText = "<div align='Center'>密碼更新成功！</div>";
        }
        else
        {
            dvAccount.FooterText = "<div align='Center'>密碼更新失敗！</div>";
        }
    }
}