using System;
using System.Globalization;

public partial class StandardFormat : System.Web.UI.Page
{
    DateTime date1;

    protected void Page_Load(object sender, EventArgs e)
    {
        date1 = new DateTime(2010,4,12);
        Response.Write("原始日期格式：<Font Color='Blue'>" + date1 + "</Font><BR/><BR/>");

        //使用標準日期及時間格式參數
        Response.Write("<Font Color='Blue'><<使用標準日期及時間格式參數>></Font><BR/>");
        Response.Write(stringFormat("d"));
        Response.Write(stringFormat("D"));
        Response.Write(stringFormat("f"));
        Response.Write(stringFormat("F"));
        Response.Write(stringFormat("g"));
        Response.Write(stringFormat("G"));
        Response.Write(stringFormat("m"));
        Response.Write(stringFormat("M"));
        Response.Write(stringFormat("o"));
        Response.Write(stringFormat("O"));
        Response.Write(stringFormat("r"));
        Response.Write(stringFormat("R"));
        Response.Write(stringFormat("s"));
        Response.Write(stringFormat("t"));
        Response.Write(stringFormat("T"));
        Response.Write(stringFormat("u"));
        Response.Write(stringFormat("U"));
        Response.Write(stringFormat("y"));
        Response.Write(stringFormat("Y"));
    }

    //自訂字串格式化方法，無指定CultureInfo文化特性，但預設台灣使用zh-TW
    protected string stringFormat(string specifier)
    {
        string param = "標準格式化參數{0}-->{1}<BR/>";
        return string.Format(param, specifier, date1.ToString(specifier));
    }


}
