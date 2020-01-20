
Partial Class ErrorPage
    Inherits System.Web.UI.Page

    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        '取得Server最後一個錯誤訊息
        If Server.GetLastError() IsNot Nothing Then
            Dim ex As Exception = Server.GetLastError()
            Response.Write(ex.ToString())
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '檢查使用者是否通過身份驗證，才顯示這些控制項
        showControls()
    End Sub

    Public Sub showControls()
        If User.Identity.IsAuthenticated Then
            '登入後顯示
            txtAdmin.Visible = True
            txtUpload.Visible = True
        Else
            txtAdmin.Visible = False
            txtUpload.Visible = False
        End If
    End Sub

    Protected Sub LoginStatus1_LoggedOut(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginStatus1.LoggedOut
        Session("AllowAlbumID") = Nothing
    End Sub
End Class
