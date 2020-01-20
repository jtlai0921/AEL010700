
Partial Class MyWebForm
    Inherits System.Web.UI.Page

    '顯示TextBox輸入文字資料
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Response.Write("您輸入的文字是：" & txtInput.Text)
    End Sub
End Class
