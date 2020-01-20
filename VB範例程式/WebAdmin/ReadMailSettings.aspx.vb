Imports System.Net.Configuration
Imports System.Web.Configuration

Partial Class ReadMailSettings
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '開啓Request所在路徑網站的Web.config檔
        Dim config As Configuration = WebConfigurationManager.OpenWebConfiguration(Me.Request.ApplicationPath)
        '取得Web.config中Mail設定區段
        Dim mail As MailSettingsSectionGroup = CType(config.GetSectionGroup("system.net/mailSettings"), MailSettingsSectionGroup)

        '讀取顯示mailSettingsx設定相關值
        Response.Write("Mail主機名稱：" & mail.Smtp.Network.Host & "<BR>")
        Response.Write("Mail主機Port：" & mail.Smtp.Network.Port & "<BR>")
        Response.Write("Mail訊息：" & mail.Smtp.From & "<BR>")
        '如果Mail的Authentication驗證模式選擇Basic，則可讀取UserName及Password
        'Response.Write("使用者姓名：" & mail.Smtp.Network.UserName & "<BR>");
        'Response.Write("使用者密碼：" & mail.Smtp.Network.Password & "<BR>");
    End Sub
End Class
