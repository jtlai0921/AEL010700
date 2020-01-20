using System;

public partial class DateTimeObject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //將 DateTime 結構的新執行個體初始化為年、月、日、時、分、秒及毫秒。
        DateTime moment = new DateTime(2010, 6, 15, 9, 45, 5, 11);

        //取得年2010
        int year = moment.Year;

        //取得月6
        int month = moment.Month;

        //取得15
        int day = moment.Day;

        //取得時9
        int hour = moment.Hour;

        //取得分45
        int minute = moment.Minute;

        //取得秒32
        int second = moment.Second;

        //取得毫秒11
        int millisecond = moment.Millisecond;

        string param="您所建立的DateTime物件日期時間為：{0}年{1}月{2}日，{3}時{4}分{5}秒{6}毫秒";

        Response.Write(string.Format(param, year, month, day, hour, minute, second, millisecond));
    }
}
