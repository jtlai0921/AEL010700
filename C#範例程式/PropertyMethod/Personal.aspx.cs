using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Personal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        People Mary = new People();
        Mary.LastName = "Mary";
        Mary.FirstName = "Could";
        Mary.Height = 165;
        Mary.Weight = 50;
        Mary.Age = 18;
        Mary.Gender = false;

        //將Mary的資料顯示出來
        Response.Write("<H2>Mary的屬性資料</H2>");
        Response.Write(String.Format("LastName：{0}<BR/>", Mary.LastName));
        Response.Write(String.Format("FirstName：{0}<BR/>", Mary.FirstName));
        Response.Write(String.Format("身高：{0}cm<BR/>", Mary.Height));
        Response.Write(String.Format("體重：{0}Kg<BR/>", Mary.Weight));
        Response.Write(String.Format("年齡：{0}歲<BR/>", Mary.Age));
        Response.Write(String.Format("性別：{0}<BR/>", (Mary.Gender == true ? "男" : "女")));


        People Cindy = new People();
        Cindy.LastName = "Cindy";
        Cindy.FirstName = "";
        Cindy.Height = -168;
        Cindy.Weight = -50;
        Cindy.Age = 0;
        Cindy.Gender = false;

        //將Cindy的資料顯示出來
        Response.Write("<span style='color:red;'><BR/>");
        Response.Write("<H2>Cindy的屬性資料：</H2>");
        Response.Write(String.Format("LastName：{0}<BR/>", Cindy.LastName));
        Response.Write(String.Format("FirstName：{0}<BR/>", Cindy.FirstName));
        Response.Write(String.Format("身高：{0}cm<BR/>", Cindy.Height));
        Response.Write(String.Format("體重：{0}Kg<BR/>", Cindy.Weight));
        Response.Write(String.Format("年齡：{0}歲<BR/>", Cindy.Age));
        Response.Write(String.Format("性別：{0}<BR/>", (Mary.Gender == true ? "男" : "女")));
        Response.Write("</span>");
    }
}
