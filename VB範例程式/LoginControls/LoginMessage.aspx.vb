
Partial Class LoginMessage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If User.Identity.IsAuthenticated Then
            Response.Write(User.Identity.Name & "您已通過驗證!")
        Else
            '傳統導回Login.aspx做法(缺乏彈性)
            'Response.Redirect("Login.aspx")
            '導向Web.config中預設的登入網頁(優先使用此法)
            FormsAuthentication.RedirectToLoginPage()
        End If
    End Sub
End Class
