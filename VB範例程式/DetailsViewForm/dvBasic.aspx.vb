
Partial Class dvBasic
    Inherits System.Web.UI.Page

    '取消刪除資料
    Protected Sub dvEmp_ItemDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewDeleteEventArgs) Handles dvEmp.ItemDeleting
        e.Cancel = True
        WebMessageBox.MessageBox.Show("已觸發刪除命令，但為確保原始資料故取消刪除命令！")
    End Sub
End Class
