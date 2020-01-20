
Partial Class ChangePassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '檢查是否身份經過驗證成功
        If Not Request.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        End If
    End Sub
End Class
