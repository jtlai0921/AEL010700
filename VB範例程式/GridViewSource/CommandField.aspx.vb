
Partial Class CommandField
    Inherits System.Web.UI.Page

    '取消刪除資料列
    Protected Sub gvProducts_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvProducts.RowDeleting
        e.Cancel = True
        WebMessageBox.MessageBox.Show("資料列刪除取消!")
    End Sub
End Class
