
Partial Class IfStatement
    Inherits System.Web.UI.Page

    '判斷成績是否及格
    Protected Sub btnOK_Click(ByVal sender As Object, _
      ByVal e As System.EventArgs) Handles btnOK.Click
        Dim score As Integer
        Dim result As Boolean

        '判斷TextBox中的英文成績是否為Null或空白
        If Not String.IsNullOrEmpty(txtScore.Text) Then
            '將英文成績由字串型別轉為Integer型別，
            '成功會回傳True給rerult,且score會包含轉型後的值
            '失敗會回傳False給rerult
            result = Integer.TryParse(txtScore.Text, score)

            '判斷字串轉型為Integer型別是否成功
            If result = True Then
                '再進一步判斷英文成績是否大於等於60分
                If score >= 60 Then
                    txtMsg.Text = "英文成績及格！"
                    txtMsg.BackColor = Drawing.Color.Aqua
                Else
                    txtMsg.Text = "英文成績不及格！"
                    txtMsg.BackColor = Drawing.Color.Red
                End If
            Else
                '字串轉型為Integer型別失敗
                Response.Write("<script>alert('成績限輸入阿拉伯數字，不得為英文字母或其他符號！')</script>")
            End If
        Else
            '若TextBox中的英文成績為空白，則顯示警告訊息
            Response.Write("<script>alert('英文成績不得為空白！')</script>")
        End If

        '或使用IsNumeric()函式判斷輸入是否為數字
        'If IsNumeric(txtScore.Text) Then
        '    score = CType(txtScore.Text, Integer)
        '    If score >= 60 Then
        '        txtMsg.Text = "英文成績及格！"
        '    Else
        '        txtMsg.Text = "英文成績不及格！"
        '    End If
        'Else
        '    Response.Write("<script>alert('成績限輸入阿拉伯數字，不得為空白、英文字母或其他符號！')</script>")
        'End If
    End Sub
End Class
