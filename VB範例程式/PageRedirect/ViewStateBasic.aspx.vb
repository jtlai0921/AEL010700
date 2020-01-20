
Partial Class ViewStateBasic
    Inherits System.Web.UI.Page

    '儲存ViewState狀態資料
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (Not String.IsNullOrEmpty(txtName.Text) And Not String.IsNullOrEmpty(txtBlood.Text) And Not String.IsNullOrEmpty(txtHobby.Text)) Then
            ViewState("Name") = txtName.Text
            ViewState("Blood") = txtBlood.Text
            ViewState("Hobby") = txtHobby.Text
            txtMsg.Text = "ViewState狀態儲存成功！"
        Else
            txtMsg.Text = "TextBox不得為空白或Nothing!"
        End If
    End Sub

    '讀取ViewStaten狀態資料
    Protected Sub btnRead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRead.Click
        txtMsg.Text = ""

        If (ViewState("Blood") IsNot Nothing And ViewState("Blood") IsNot Nothing And ViewState("Hobby") IsNot Nothing) Then
            txtMsg.Text = "ViewState狀態資料如下：<BR/>"
            txtMsg.Text &= "姓名：" & ViewState("Name") & "<BR/>"
            txtMsg.Text &= "血型：" & ViewState("Blood") & "<BR/>"
            txtMsg.Text &= "興趣：" & ViewState("Hobby") & "<BR/>"
        Else
            txtMsg.Text = "ViewState狀態值為Nothing"
        End If
    End Sub
End Class
