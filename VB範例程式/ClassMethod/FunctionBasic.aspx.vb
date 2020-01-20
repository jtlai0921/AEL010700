
Partial Class FunctionBasic
    Inherits System.Web.UI.Page

    '呼叫ToChinese的Function程序，進行阿拉伯數字轉換為中文字
    Protected Sub btnConvert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConvert.Click
        '檢查TextBox是為否Null或空白
        If Not String.IsNullOrEmpty(txtNumber.Text) Then
            '呼叫ToChineseNum的Function程序
            Dim Nums As String = "轉換後的中文數字為：" & ToChineseNum(txtNumber.Text)
            txtMsg.Text = Nums
        Else
            txtMsg.Text = "必須輸入阿拉伯數字，不可為空白！"
        End If
    End Sub

    '將阿拉伯數字轉換為中文字的Function程序
    Function ToChineseNum(ByVal number As String) As String
        Dim num As String = ""
        Dim ChineseNum() As String = {"零", "壹", "貳", "參", "肆", "伍", "陸", "柒", "捌", "玖"}
        Dim result As String = ""

        '檢查number是否為數字
        If IsNumeric(number) Then
            For i = 0 To number.Length - 1
                '依序逐一取出number字串中的字元，
                '將阿拉伯數字轉換為中文數字
                num = number.Substring(i, 1)
                result &= ChineseNum(CInt(num))
            Next
        Else
            result = "必須為數字，不可以其他文字或空白！"
        End If

        Return result
    End Function
End Class
