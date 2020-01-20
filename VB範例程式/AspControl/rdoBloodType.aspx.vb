
Partial Class rdoBloodType
    Inherits System.Web.UI.Page

    '顯示使用者血型
    Protected Sub rdoBlood_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdoBlood.SelectedIndexChanged
        txtMsg.Text = "您的血型為：" & rdoBlood.SelectedItem.Text
    End Sub
End Class
