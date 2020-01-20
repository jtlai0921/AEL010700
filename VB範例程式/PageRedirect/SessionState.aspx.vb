
Partial Class SessionState
    Inherits System.Web.UI.Page

    '儲存Session狀態資料
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (Not String.IsNullOrEmpty(txtName.Text) And Not String.IsNullOrEmpty(txtTel.Text)) Then
            Session("Name") = txtName.Text
            Session("Tel") = txtTel.Text
            txtMsg.Text = "Session狀態儲存成功！"
        Else
            txtMsg.Text = "不得為空白或Nothing!"
        End If
    End Sub

    '讀取Session狀態資料
    Protected Sub btnRead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRead.Click
        txtMsg.Text = ""

        If (Session("Name") IsNot Nothing And Session("Tel") IsNot Nothing) Then
            txtMsg.Text = "Session狀態資料如下：<BR/>"
            txtMsg.Text &= "姓名：" & Session("Name") & "<BR/>"
            txtMsg.Text &= "Tel：" & Session("Tel")
        Else
            txtMsg.Text = "Session狀態值為Nothing"
        End If
    End Sub
End Class
