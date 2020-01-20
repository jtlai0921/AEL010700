
Partial Class LoginTemplate
    Inherits System.Web.UI.Page

    Dim RV1 As RequiredFieldValidator
    Dim RV2 As RequiredFieldValidator

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '在Login控制項完成驗證程序，檢查是否通過驗證，若通過則顯示使用者姓名
        If User.Identity.IsAuthenticated Then
            '顯示登入使用者名稱
            CType(UserLogin.FindControl("txtUserName"), Label).Text = "歡迎你：" & User.Identity.Name
        Else
            CType(UserLogin.FindControl("txtUserName"), Label).Text = ""
        End If
    End Sub

    '登入前
    Protected Sub UserLogin_LoggingIn(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs) Handles UserLogin.LoggingIn
        RV1 = CType(UserLogin.FindControl("RV1"), RequiredFieldValidator)
        RV1.Enabled = True
        RV1.Validate()
        RV2 = CType(UserLogin.FindControl("RV2"), RequiredFieldValidator)
        RV2.Enabled = True
        RV2.Validate()
    End Sub

    '登入後
    Protected Sub UserLogin_LoggedIn(ByVal sender As Object, ByVal e As System.EventArgs) Handles UserLogin.LoggedIn
        RV1.Enabled = False
        RV2.Enabled = False
    End Sub

    '登出
    Protected Sub btnSignout_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        FormsAuthentication.SignOut()   '登出，刪除Cookie
        Response.Redirect("LoginTemplate.aspx")
    End Sub

    '顯示JavaScript訊息
    Protected Sub UserLogin_LoginError(ByVal sender As Object, ByVal e As System.EventArgs) Handles UserLogin.LoginError
        WebMessageBox.MessageBox.Show("帳號密碼錯誤!")
    End Sub
End Class
