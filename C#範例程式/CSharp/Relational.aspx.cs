using System;

public partial class Relational : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int x = 10;
        int y = 5;
        int z = 10;

        Response.Write("<H2>關係運算子的運用</H2>");
        Response.Write(string.Format("x為{0}，y為{1}，z為{2}<BR/><BR/>", x, y, z));

        //判斷x是否大於y
        if (x > y)
        {
            Response.Write("x > y為true<BR/>");
        }
        else
        {
            Response.Write("x > y為false<BR/>");
        }

        //判斷z是否小於y
        if (z < y)
        {
            Response.Write("z < y為true<BR/>");
        }
        else
        {
            Response.Write("z < y為false<BR/>");
        }

        //判斷x與z是否相等
        if (x == z)
        {
            Response.Write("x = z為true<BR/>");
        }
        else
        {
            Response.Write("x = z為false<BR/>");
        }

        //更精簡的語法，使用? :
        Response.Write("<BR/>更精簡的語法，使用? :<BR/>");
        Response.Write(x > y ? "x > y為true<BR/>" : "x > y為false<BR/>");
        Response.Write(z < y ? "z < y為true<BR/>" : "z < y為false<BR/>");
        Response.Write(z == y ? "x ＝ z為true<BR/>" : "x ＝ z為false<BR/>");
    }
}
