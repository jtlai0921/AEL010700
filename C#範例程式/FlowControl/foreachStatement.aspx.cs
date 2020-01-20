using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class foreachStatement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("<Img src='Images/foreach.jpg' /><BR/>");
        string[] Models = new string[] { "Kelly", "Mary", "Tom", "Bob", "John" };

        Response.Write("<UL>模特兒成員如下:");
        //以foreach執行陣列資料的讀取
        foreach (string m in Models)
        {
            Response.Write("<Li>" + m + "</Li>");
        }

        Response.Write("</UL>");
    }
}
