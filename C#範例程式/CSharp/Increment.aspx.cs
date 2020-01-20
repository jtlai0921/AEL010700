using System;

public partial class Increment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        double x;

        Response.Write("<H2>++遞增運算子的運用</H2>");
        //後置遞增運算x++
        x = 1.5;
        Response.Write(string.Format("原始的x值為：{0}<BR/>", x));
        Response.Write(string.Format("後置遞增運算x值為：{0}<BR/>", x++));

        //前置遞增運算++x
        x = 1.5;
        Response.Write(string.Format("前置遞增運算x值為：{0}<BR/>", ++x));
    }
}
