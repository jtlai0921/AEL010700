
Partial Class source
    Inherits System.Web.UI.Page

    '進行網頁導向切換，及使用者資料傳遞
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim name As String = "Name=" & Server.HtmlEncode(txtName.Text)
        Dim tel As String = "Tel=" & Server.HtmlEncode(txtTel.Text)
        Dim city As String = "City=" & Server.HtmlEncode(dwnCity.SelectedItem.Text)
        Dim param As String = name & "&" & tel & "&" & city
        '使用Redirect方法
        Response.Redirect("target.aspx?" & param)
        '使用Transfer方法
        Server.Transfer("target.aspx?" & param)
    End Sub
End Class
