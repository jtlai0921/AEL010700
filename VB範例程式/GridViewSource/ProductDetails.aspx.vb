
Partial Class ProductDetails
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            '讀取來源URL
            Session("sourceUrl") = Context.Request.UrlReferrer
        End If
    End Sub

    '回上一頁
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        If Session("sourceUrl") <> Nothing Then
            Response.Redirect(Session("sourceUrl").ToString())
        End If
    End Sub
End Class
