
Partial Class CrossPageTarget
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(PreviousPage) And PreviousPage.IsCrossPagePostBack Then
            Dim txtUsername As TextBox = PreviousPage.FindControl("txtUserName")
            txtMsg.Text = "您輸入的名字是：" & txtUsername.Text
        End If
    End Sub
End Class
