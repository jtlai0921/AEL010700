using System;

public partial class Arithmetic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        decimal x = 3;
        decimal y = 5;
        decimal z = 9;

        Response.Write("<H2>算術運算子的運用</H2>");
        Response.Write(string.Format("x為{0}，y為{1}，z為{2}<BR/><BR/>", x, y, z));

        //加法運算子，
        Response.Write(string.Format("x+5運算的結果為{0}<BR/>", x + 5));

        //減法運算子
        Response.Write(string.Format("y-2運算的結果為{0}<BR/>", y - 2));

        //乘法運算子
        Response.Write(string.Format("x*3運算的結果為{0}<BR/>", x * 3));

        //除法運算子
        Response.Write(string.Format("z/2運算的結果為{0}<BR/>", z / 2));

        //餘數運算子
        Response.Write(string.Format("y%2運算的結果為{0}<BR/>", y % 2));
    }
}
