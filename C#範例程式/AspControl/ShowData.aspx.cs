using System;

public partial class ShowData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("帳號：" + Request.QueryString["ID"] + "<BR/>");
        Response.Write("密碼：" + Request.QueryString["Password"] + "<BR/>");
        Response.Write("輸入訊息：" + Request.QueryString["Msg"] + "<BR/>");
    }
}
