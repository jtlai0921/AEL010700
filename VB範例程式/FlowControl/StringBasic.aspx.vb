
Partial Class StringBasic
    Inherits System.Web.UI.Page

    '進行字串處理作業
    Protected Sub btnGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGo.Click
        '判斷TextBox是否有輸入文字
        If Not String.IsNullOrEmpty(txtInput.Text) Then
            '將Integer以ToString()轉換成String字串
            txtLength.Text = txtInput.Text.Length.ToString()

            '以Substring取得輸入字串位置2~5之子字串
            If txtInput.Text.Length > 5 Then
                txtSubString.Text = txtInput.Text.Substring(2, 5)
            End If

            '將輸入字串以ToUpper轉換成大寫
            txtToUpper.Text = txtInput.Text.ToUpper()
            '將輸入字串以ToLower轉換成小寫
            txtToLower.Text = txtInput.Text.ToLower()
            '以IndexOf尋找字串中特定文字，並回傳起值位置
            txtIndexOf.Text = txtInput.Text.IndexOf("Dot").ToString()
            '以Trim將字串前後空白去除
            txtTrim.Text = txtInput.Text.Trim()
        End If
    End Sub
End Class
