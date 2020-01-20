using System;

public partial class Constants : System.Web.UI.Page
{
    public const double Pi = 3.1415;    //宣告Pi圓週率
    public double radius; //宣告圓形之半徑

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("<H2>以常數宣告pi圓週率</H2>");
        //以下修改Pi常數是不合法的
        //Pi = 4;   
        radius=5;

        Response.Write("圓形之面積為：" + radius * radius * Pi);
    }
}
