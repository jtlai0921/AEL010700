
Partial Class cbxControl
    Inherits System.Web.UI.Page

    '顯示使用者興趣
    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        txtMsg.Text = ""
        Dim counter As Integer = 1
        For i As Integer = 0 To cbxHabits.Items.Count - 1
            '判斷CheckBoxList項目是否被選取
            If cbxHabits.Items(i).Selected = True Then
                '若被選取，則加入興趣文字列表
                txtMsg.Text &= counter & "." & cbxHabits.Items(i).Text & "<BR/>"
                counter += 1
            End If
        Next
    End Sub
End Class
