using System;
using System.Globalization;

public partial class CustomFormat : System.Web.UI.Page
{
    DateTime date1;
    protected void Page_Load(object sender, EventArgs e)
    {
        date1 = new DateTime(2010, 4, 12);
        Response.Write("原始日期格式：<Font Color='Blue'>" + date1 + "</Font><BR/>");

        //自訂日期格式
        Response.Write("<BR/><Font Color='Blue'><<直接指定日期格式>></Font><BR/>");
        Response.Write("自訂格式參數yyyy/MM/dd-->" + date1.ToString("yyyy/MM/dd") + "<BR/>");
        Response.Write("自訂格式參數yyyy-MM-dd-->" + date1.ToString("yyyy-MM-dd") + "<BR/>");
        Response.Write("自訂格式參數MM.dd.yyyy-->" + date1.ToString("MM.dd.yyyy") + "<BR/>");
        Response.Write("自訂格式參數dd.MM.yyyy-->" + date1.ToString("dd.MM.yyyy") + "<BR/>");
    }
}
