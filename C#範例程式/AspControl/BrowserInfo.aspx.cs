using System;
using System.Text;

public partial class BrowserInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.HttpBrowserCapabilities browser = Request.Browser;

        StringBuilder info = new StringBuilder();
        info.Append( "<ul>");
        info.Append(String.Format("<li>名稱：{0}</li>", browser.Browser));
        info.Append(String.Format("<li>版本：{0}</li>", browser.Version));
        info.Append(String.Format("<li>名稱與版本：{0}</li>", browser.Type));
        info.Append(String.Format("<li>主要版本：{0}</li>", browser.MajorVersion));
        info.Append(String.Format("<li>次要版本：{0}</li>", browser.MinorVersion));
        info.Append(String.Format("<li>用戶端使用的平台名稱：{0}</li>", browser.Platform));
        info.Append(String.Format("<li>安裝在用戶端上的 .NET Framework 版本：{0}</li>", browser.ClrVersion));
        info.Append(String.Format("<li>是否為Beta版：{0}</li>", browser.Beta));
        info.Append(String.Format("<li>是否為 Web Crawler搜尋引擎：{0}</li>", browser.Crawler));
        info.Append(String.Format("<li>是否為 America Online(AOL)瀏覽器：{0}</li>", browser.AOL));
        info.Append(String.Format("<li>否為 Win16架構電腦：{0}</li>", browser.Win16));
        info.Append(String.Format("<li>否為 Win32架構電腦：{0}</li>", browser.Win32));
        info.Append(String.Format("<li>是否支援Frames：{0}</li>", browser.Frames));
        info.Append(String.Format("<li>是否支援Tables：{0}</li>", browser.Tables));
        info.Append(String.Format("<li>是否支援Cookies：{0}</li>", browser.Cookies));
        info.Append(String.Format("<li>是否支援VBScript：{0}</li>", browser.VBScript));
        info.Append(String.Format("<li>是否支援JavaApplets：{0}</li>", browser.JavaApplets));
        info.Append(String.Format("<li>是否支援ActiveXControls：{0}</li>", browser.ActiveXControls));
        info.Append(String.Format("<li>JScriptVersion版本：{0}</li>", browser.JScriptVersion));
        info.Append(String.Format("<li>EcmaScript版本：{0}</li>", browser.EcmaScriptVersion));
        info.Append(String.Format("<li>瀏覽器是否行動裝置：{0}</li>", browser.IsMobileDevice));
        info.Append("</ul>");
        txtInfo.Text = info.ToString();
    }
}
