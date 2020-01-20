
Partial Class Admin_AlbumsAdmin
    Inherits System.Web.UI.Page

    '編輯相簿
    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnEdit.Click
        MultiView1.ActiveViewIndex = 0
        gvAlbums.DataBind()
    End Sub

    '新增相簿
    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnInsert.Click
        MultiView1.ActiveViewIndex = 1
    End Sub

    '編輯相片
    Protected Sub btnEditPhotos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnEditPhotos.Click
        MultiView1.ActiveViewIndex = 2
        gvPhotos.DataBind()
    End Sub

    '登出
    Protected Sub LoginStatus1_LoggedOut(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginStatus1.LoggedOut
        Session("AllowAlbumID") = Nothing
        Response.Redirect("~/Albums.aspx")
    End Sub

    '顯示訊息
    Protected Sub alert(ByVal Status As String)
        Dim alert As String = "<script>alert('{0}')</script>"
        Dim txtMsg As New Literal()
        txtMsg.Text = String.Format(alert, Status)
        Page.Form.Controls.Add(txtMsg)
    End Sub

    '執行新增
    Protected Sub btnInsertDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsertDetail.Click
        sqlDetail.Insert()
    End Sub

    '刪除資料列
    Protected Sub gvAlbums_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvAlbums.RowDeleting
        '預設為取消
        'e.Cancel = true
    End Sub

    Protected Sub gvAlbums_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles gvAlbums.RowDeleted
        gvAlbums.DataBind()
        MultiView1.DataBind()
    End Sub
End Class
