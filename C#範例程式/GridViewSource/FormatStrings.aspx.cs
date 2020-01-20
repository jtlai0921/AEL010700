using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FormatStrings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        double x = 2005.5;
        int y = 128;
        double z = 0.25;

        Response.Write("<H2>標準數值格式化字串</H2>");

        string stringX = x.ToString().PadLeft(6, '*');
        string stringY = y.ToString().PadLeft(6, '*');
        string stringZ = z.ToString().PadLeft(6, '*');

        Response.Write(stringX + "　以C2格式化之後" + String.Format("{0:C2}", x) + "<BR>");
        Response.Write(stringY + "　以D格式化之後" + String.Format("{0:D}", y) + "<BR>");
        Response.Write(stringX + "　以E2格式化之後" + String.Format("{0:E2}", x) + "<BR>");
        Response.Write(stringX + "　以F4格式化之後" + String.Format("{0:F4}", x) + "<BR>");
        Response.Write(stringX + "　以G格式化之後" + String.Format("{0:G}", x) + "<BR>");
        Response.Write(stringX + "　以N3格式化之後" + String.Format("{0:N3}", x) + "<BR>");
        Response.Write(stringZ + "　以P格式化之後" + String.Format("{0:P}", z) + "<BR>");
        Response.Write(stringY + "　以X格式化之後" + String.Format("{0:X}", y) + "<BR>");
        Response.Write(stringX + "　以00####.00格式化之後" + String.Format("{0:00####.00}", x) + "<BR>");
    }
}
