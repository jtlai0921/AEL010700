
Partial Class TargetPage
    Inherits System.Web.UI.Page
    '宣告來源網頁url
    Shared sourceUrl As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '讀取並保存來源網頁Url
            sourceUrl = Request.RawUrl.ToString()
        End If
    End Sub

    '回上一頁
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        '導向回到上一頁之來源網頁
        Response.Redirect(sourceUrl)
    End Sub
End Class
