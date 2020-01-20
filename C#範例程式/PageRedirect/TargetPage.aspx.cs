using System;

public partial class TargetPage : System.Web.UI.Page
{
    static string sourceUrl = "";   //來源網頁

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //讀取並保存來源網頁Url
            sourceUrl = Request.RawUrl.ToString();
        }
    }

    //回上一頁
    protected void btnBack_Click(object sender, EventArgs e)
    {
        //導向回到上一頁之來源網頁
        Response.Redirect(sourceUrl);
    }
}
