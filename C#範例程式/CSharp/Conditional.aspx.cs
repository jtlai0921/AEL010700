using System;

public partial class Conditional : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //以下為Tom個人年齡及學科測試成績
        int age = 28;       //年齡28歲
        int english = 70;   //英文分數
        int math = 85;      //數學分數
        int chinese = 100;  //國文分數

        //顯示年齡及成績
        Response.Write("<H2>以條件運算子進行邏輯條件運算</H2>");
        Response.Write("Tom的年齡及成績如下：<BR/>");
        Response.Write("年齡=" + age + "，");

        string str = "英文={0}，數學={1}，國文={2}<BR/><BR/>";
        Response.Write(String.Format(str, english, math, chinese));

        //以條件運算子&&及||進行邏輯條件運算
        if (age >= 20 && age < 30)
        {
            if (english < 80 || math < 80 || chinese < 80)
            {
                Response.Write("學科成績有一科低於80分，不予錄取！");
            }
            else
            {
                Response.Write("錄取通過！");
            }
        }
        else
        {
            Response.Write("年齡不符，無法參試！");
        }
    }
}
