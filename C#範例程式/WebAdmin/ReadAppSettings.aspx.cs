using System;
using System.Web.Configuration;

public partial class ReadAppSettings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		string txtCompany = WebConfigurationManager.AppSettings["Company"];
		Response.Write("公司名稱：" + txtCompany + "<br>");

        string txtServiceTel = WebConfigurationManager.AppSettings["客服專線"];
        Response.Write("客服專線：" + txtServiceTel + "<br>");
    }
}
