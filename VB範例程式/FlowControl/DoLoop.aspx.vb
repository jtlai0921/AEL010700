
Partial Class DoLoop
    Inherits System.Web.UI.Page

    Protected Sub btnGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGo.Click
        txtMsg.Text = ""
        Dim i As New Integer

        '判斷TextBox輸入是否為阿拉伯數字
        If IsNumeric(txtStart.Text) Then
            i = CType(txtStart.Text, Integer)
            '執行迴圈，Ｗhile接在Do之後
            Do While i <= 100
                txtMsg.Text &= i & vbCrLf
                i += 1
            Loop

            '或Ｗhile接在Loop之後
            'Do
            '    txtMsg.Text &= i & vbCrLf
            '    i += 1
            'Loop While i <= 100
        Else
            Response.Write("<script>alert('限輸入阿拉伯數字!')</script>")
        End If
    End Sub
End Class
