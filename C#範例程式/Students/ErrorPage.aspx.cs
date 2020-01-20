using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ErrorPage : System.Web.UI.Page
{
    protected void Page_Error(object sender, EventArgs e)
    {
        //取得Server最後一個錯誤訊息
        if (Server.GetLastError() != null)
        {
            Exception ex = Server.GetLastError();
            Response.Write(ex.ToString());
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}