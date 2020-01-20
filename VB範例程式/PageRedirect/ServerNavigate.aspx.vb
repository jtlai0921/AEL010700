
Partial Class ServerNavigate
    Inherits System.Web.UI.Page

    '以Response.Redirect()方法進行網頁切換導向
    Protected Sub btnRedirect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRedirect.Click
        Response.Redirect("http://www.microsoft.com")
    End Sub

    '以Server.Transfer()方法進行網頁切換導向
    Protected Sub btnTransfer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTransfer.Click
        Server.Transfer("TargetPage.aspx")
    End Sub
End Class
