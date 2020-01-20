
Partial Class rdoDegree
    Inherits System.Web.UI.Page

    '顯示最高學歷
    Protected Sub btnSumbit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSumbit.Click
        '判斷選擇的RadioButton控制項
        If rdoSenior.Checked = True Then
            txtMsg.Text = "你的最高學歷為：" & rdoSenior.Text
        ElseIf rdoUniversity.Checked = True Then
            txtMsg.Text = "你的最高學歷為：" & rdoUniversity.Text
        ElseIf rdoMaster.Checked = True Then
            txtMsg.Text = "你的最高學歷為：" & rdoMaster.Text
        ElseIf rdoDoctor.Checked = True Then
            txtMsg.Text = "你的最高學歷為：" & rdoDoctor.Text
        Else
            txtMsg.Text = "請至少選擇一個學歷選項！"
        End If
    End Sub
End Class
