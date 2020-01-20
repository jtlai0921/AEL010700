
Partial Class Message
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtMsg.Text = "原因：" & Server.HtmlEncode(Request.QueryString("Reason"))
    End Sub
End Class
