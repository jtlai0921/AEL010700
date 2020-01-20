
Partial Class dvChangeMode
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '將DetailsView變換為Edit模式
            dvEmp.ChangeMode(DetailsViewMode.Edit)
        End If
    End Sub

    '檢查分頁功能若為編輯模式則不准換頁
    Protected Sub dvEmp_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewPageEventArgs) Handles dvEmp.PageIndexChanging
        '判斷DetailsView目前的模式
        If dvEmp.CurrentMode = DetailsViewMode.Edit Then
            e.Cancel = True '取消分頁
            WebMessageBox.MessageBox.Show("編輯模式下禁止換頁！")
        End If
    End Sub

    '取消刪除資料
    Protected Sub dvEmp_ItemDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewDeleteEventArgs) Handles dvEmp.ItemDeleting
        e.Cancel = True
        WebMessageBox.MessageBox.Show("已觸發刪除命令，但為確保原始資料故取消刪除命令！")
    End Sub
End Class
