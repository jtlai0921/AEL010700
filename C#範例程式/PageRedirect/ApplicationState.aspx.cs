using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ApplicationState : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("Blog名稱：" + Application["Blog"] + "<BR/>");
        Response.Write("管理者：" + Application["Administrator"] + "<BR/>");
        Response.Write("Tel：" + Application["Tel"] + "<BR/>");
        Response.Write("目前訪客人數為：" + Application["Counter"] + "<BR/>");
    }
}
