
Partial Class BrowserInfo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim info As String = ""
        With Request.Browser
            info &= "名稱：" & .Browser & "<BR/>"
            info &= "版本： " & .Version & "<BR/>"
            info &= "名稱與版本： " & .Type & "<BR/>"
            info &= "主要版本： " & .MajorVersion & "<BR/>"
            info &= "次要版本： " & .MinorVersion & "<BR/>"
            info &= "用戶端使用的平台名稱： " & .Platform & "<BR/>"
            info &= "安裝在用戶端上的 .NET Framework 版本： " & .ClrVersion.ToString() & "<BR/>"
            info &= "是否為Beta版： " & .Beta & "<BR/>"
            info &= "是否為 Web Crawler搜尋引擎： " & .Crawler & "<BR/>"
            info &= "是否為 America Online(AOL)瀏覽器： " & .AOL & "<BR/>"
            info &= "否為 Win16架構電腦： " & .Win16 & "<BR/>"
            info &= "否為 Win32架構電腦： " & .Win32 & "<BR/>"
            info &= "是否支援Frames： " & .Frames & "<BR/>"
            info &= "是否支援Tables： " & .Tables & "<BR/>"
            info &= "是否支援Cookies： " & .Cookies & "<BR/>"
            info &= "是否支援VBScript： " & .VBScript & "<BR/>"
            info &= "是否支援JavaApplets： " & .JavaApplets & "<BR/>"
            info &= "是否支援ActiveXControls： " & .ActiveXControls & "<BR/>"
            info &= "JScriptVersion版本： " & .JScriptVersion.ToString() & "<BR/>"
            info &= "EcmaScript版本： " & .EcmaScriptVersion.ToString() & "<BR/>"
            info &= "瀏覽器是否行動裝置： " & .IsMobileDevice & "<BR/>"
        End With

        txtInfo.Text = info
    End Sub
End Class
