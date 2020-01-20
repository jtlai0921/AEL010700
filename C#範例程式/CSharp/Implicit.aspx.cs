using System;

public partial class Implicit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //int型別
        int height = 180;
        int weight = 75;

        //long型別
        long h = height;
        long w = weight;

        //float型別
        float h1 = height;
        float w1 = w;

        Response.Write("<H2>int型別的隱含轉換</H2>");
        Response.Write(string.Format("身高為：{0}，體重為：{1}（int->long型別）<BR/>", h, w));
        Response.Write(string.Format("身高為：{0}，體重為：{1}（int->float型別）<BR/>", h1, w1));
    }
}
