using System;

public partial class Variables : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /* 不合法的例子，變數未初始化就使用
        string lastName;
        int age;
        bool gender;
        decimal money;
        decimal rate;
        Response.Write("名字：" + lastName + "<BR/>");
        Response.Write("年齡：" + age + "<BR/>");
        Response.Write("性別：" + (gender == true ? "男" : "女") + "<BR/>");
        Response.Write("銀行存款：" + money + "<BR/>");
        Response.Write("利率：" + rate + "<BR/>");
        Response.Write("一年存款利息：" + money * rate + "<BR/>");
         * */

        //合法的方式，指定區域變數之初始值
        string lastName = "聖殿祭司";
        int age = 99;
        bool gender = true;    //男性為True，女性為False
        decimal money = 1000000;    //存款金額
        decimal rate = 0.035M;      //存款利率

        Response.Write("<H2>變數宣告、設定與使用</H2>");
        Response.Write("名字：" + lastName + "<BR/>");
        Response.Write("年齡：" + age + "<BR/>");
        Response.Write("性別：" + (gender == true ? "男" : "女") + "<BR/>");
        Response.Write("銀行存款：" + money + "<BR/>");
        Response.Write("利率：" + rate * 100 + "%<BR/>");
        Response.Write("一年存款利息：" + money * rate + "<BR/>");
    }
}
