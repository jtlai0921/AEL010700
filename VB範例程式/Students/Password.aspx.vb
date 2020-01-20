
Partial Class Password
    Inherits System.Web.UI.Page

    '檢查使用者是否登入，才能更改密碼
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If User.Identity.IsAuthenticated = True Then
            '以登入帳號ID傳入SqlDataSource做查詢
            sqlPassword.SelectParameters("paramID").DefaultValue = User.Identity.Name
        End If
    End Sub

    '判斷密碼是否成新成功
    Protected Sub sqlPassword_Updated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceStatusEventArgs) Handles sqlPassword.Updated
        If e.AffectedRows >= 1 Then
            dvAccount.FooterText = "<div align='Center'>密碼更新成功！</div>"
        Else
            dvAccount.FooterText = "<div align='Center'>密碼更新失敗！</div>"
        End If
    End Sub
End Class
