using System;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //網頁載入時之事件程式
        string time = getTime();
        Response.Write("現在時間是:" + time);
    }

    /// <summary>
    /// 取得伺服器時間方法
    /// </summary>
    /// <returns>回傳時間字串</returns>
    protected string getTime()
    {
        return DateTime.Now.ToLongTimeString();
    }
}
