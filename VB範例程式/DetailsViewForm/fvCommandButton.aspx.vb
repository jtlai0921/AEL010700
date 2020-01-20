
Partial Class fvCommandButton
    Inherits System.Web.UI.Page

    Protected Sub fvEmp_ItemDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewDeleteEventArgs) Handles fvEmp.ItemDeleting, fvEmp.ItemDeleting
        e.Cancel = True
        WebMessageBox.MessageBox.Show("為防止誤刪Employee資料表，故取消刪除命令!")
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        WebMessageBox.MessageBox.Show("您按下了編輯按鈕")
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        WebMessageBox.MessageBox.Show("您按下了刪除按鈕")
    End Sub

    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        WebMessageBox.MessageBox.Show("您按下了新增按鈕")
    End Sub
End Class
