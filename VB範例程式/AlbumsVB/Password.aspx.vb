Imports System.Data

Partial Class Password
    Inherits System.Web.UI.Page

    Dim dv As DataView = Nothing
    Dim albumID As String = Nothing
    Dim albumName As String = Nothing
    Dim url As String = Nothing

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '如果缺少AlbumID相片代號，則導回Albums.aspx網頁
        If IsNothing(Request.QueryString("AlbumID")) Then
            Response.Redirect("~/Albums.aspx")
        End If

        '檢查使用者是否通過身份驗證，才顯示這些控制項
        showControls()
    End Sub

    '如果使用者通過身份驗證，才顯示這些控制項
    Protected Sub showControls()
        If User.Identity.IsAuthenticated Then
            '登入後顯示
            txtAdmin.Visible = True
            txtUpload.Visible = True
        Else
            txtAdmin.Visible = False
            txtUpload.Visible = False
        End If
    End Sub

    '執行密碼查詢
    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnPassword.Click
        txtMsg.Text = ""
        txtMsg.Visible = False

        If Not String.IsNullOrEmpty(txtPassword.Text) Then
            dv = TryCast(sqlAlbumPwd.Select(DataSourceSelectArguments.Empty), DataView)
            If dv.Count > 0 Then
                '指定相簿名稱到Session中
                albumName = TryCast(dv.Table.DataSet.Tables(0).Rows(0)("AlbumName"), String)
                '導回呼叫的url網頁
                Response.Redirect(url)
            End If
        Else
            txtMsg.Text = "*密碼不得為空白!"
            txtMsg.Visible = True
        End If
    End Sub

    '驗證密碼是否正確
    Protected Sub sqlAlbumPwd_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceStatusEventArgs) Handles sqlAlbumPwd.Selected
        '如果等於1，表示密碼正確，並導回Photos.aspx或Browse.aspx網頁的url值
        If e.AffectedRows = 1 Then
            albumID = Request.QueryString("AlbumID")
            Session("AllowAlbumID") = albumID
            Dim pageName As String = Request.QueryString("PageName")

            Select Case pageName
                Case "Browse"
                    url = String.Format("Browse.aspx?PhotoGUID={0}", Request.QueryString("PhotoGUID"))
                Case "Photos"
                    url = "Photos.aspx?AlbumID=" & albumID & "&Page=1"
                Case Else
                    url = "Photos.aspx?AlbumID=" & albumID & "&Page=1"
            End Select
        Else
            Session("AllowAlbumID") = "Protected"
            txtMsg.Text = "*密碼錯誤!!!"
            txtMsg.Visible = True
        End If
    End Sub

    '登出時，將授權瀏覽密碼保護相簿取消
    Protected Sub LoginStatus1_LoggedOut(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginStatus1.LoggedOut
        Session("AllowAlbumID") = Nothing
    End Sub
End Class
