
Partial Class TryCatch
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    '無Try...Catch例外狀況處理
    Protected Sub btnDiv1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDiv1.Click
        Dim a As Decimal                '被除數
        Dim b As Decimal                '除數
        Dim errMsg As String = Nothing  '錯誤訊息

        '判斷TextBox輸入是否為阿拉伯字
        If IsNumeric(txtNumerator.Text) And IsNumeric(txtDenominator.Text) Then
            a = txtNumerator.Text
            b = txtDenominator.Text
            txtResult.Text = (a / b).ToString() '除法計算
        Else
            Response.Write("<script>alert('輸入的數字格式錯誤，限輸入阿拉伯數字！')</script>")
        End If
    End Sub

    '有Try...Catch例外狀況處理
    Protected Sub btnDiv2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDiv2.Click
        Dim a As Decimal                '被除數
        Dim b As Decimal                '除數
        Dim errMsg As String = Nothing  '錯誤訊息

        '判斷TextBox輸入是否為阿拉伯字
        If IsNumeric(txtNumerator.Text) And IsNumeric(txtDenominator.Text) Then
            a = txtNumerator.Text
            b = txtDenominator.Text
            Try
                txtResult.Text = (a / b).ToString() '除法計算
            Catch ex As Exception
                '例外狀況發生時，ex含有錯誤訊息，並指定給errMsg
                txtResult.Text = "<BR/>" & ex.ToString()
            End Try
        Else
            Response.Write("<script>alert('輸入的數字格式錯誤，限輸入阿拉伯數字！')</script>")
        End If
    End Sub
End Class
