using System;
using System.Globalization;

public partial class CultureInfoFormat : System.Web.UI.Page
{
    DateTime date1;

    protected void Page_Load(object sender, EventArgs e)
    {
        date1 = new DateTime(2010, 4, 12);
        Response.Write("原始日期格式：<Font Color='Blue'>" + date1 + "</Font><BR/><BR/>");

        //使用標準日期及時間格式參數，並結合文化特性
        Response.Write("<Font Color='Blue'><<使用標準日期及時間格式參數，並結合文化特性>></Font><BR/>");
        Response.Write(FormatCulture("d"));
        Response.Write(FormatCulture("D"));
        Response.Write(FormatCulture("f"));
        Response.Write(FormatCulture("F"));
        Response.Write(FormatCulture("g"));
        Response.Write(FormatCulture("G"));
        Response.Write(FormatCulture("m"));
        Response.Write(FormatCulture("M"));
        Response.Write(FormatCulture("o"));
        Response.Write(FormatCulture("O"));
        Response.Write(FormatCulture("r"));
        Response.Write(FormatCulture("R"));
        Response.Write(FormatCulture("s"));
        Response.Write(FormatCulture("t"));
        Response.Write(FormatCulture("T"));
        Response.Write(FormatCulture("u"));
        Response.Write(FormatCulture("U"));
        Response.Write(FormatCulture("y"));
        Response.Write(FormatCulture("Y"));
    }

    //自訂字串格式化方法，有指定CultureInfo文化特性
    //台灣為zh-TW，中華人民共和國為zh-CN，美國為en-US
    protected string FormatCulture(string specifier)
    {
        string param = "標準格式化參數{0}-->{1}<BR/>";
        return string.Format(param, specifier, date1.ToString(specifier, CultureInfo.CreateSpecificCulture("en-US")));
    }
}
