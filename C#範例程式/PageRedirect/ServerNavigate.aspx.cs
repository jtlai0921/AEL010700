using System;

public partial class ServerNavigate : System.Web.UI.Page
{
    //以Response.Redirect()方法進行網頁切換導向
    protected void btnRedirect_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://www.microsoft.com");
    }

    //以Server.Transfer()方法進行網頁切換導向
    protected void btnTransfer_Click(object sender, EventArgs e)
    {
        Server.Transfer("TargetPage.aspx");
    }
}
