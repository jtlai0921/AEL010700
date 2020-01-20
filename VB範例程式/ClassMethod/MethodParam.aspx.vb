
Partial Class MethodParam
    Inherits System.Web.UI.Page


    '計算斜邊c的長度
    '鬆散的語法，未做任何的資料驗證機制
    Private Function getLengthBad(ByVal a As String, ByVal b As String) As Decimal
        Dim valueA As Decimal = CDec(a) '斜邊a，以CDec將String型別轉換成Decimal型別
        Dim valueB As Decimal = CDec(b) '斜邊b，以CDec將String型別轉換成Decimal型別
        '計算a+b的平方根
        Dim valueC As Decimal = Math.Sqrt(Math.Pow(valueA, 2) + Math.Pow(valueB, 2))

        Return valueC   '回傳斜邊c
    End Function

    '計算斜邊c的長度
    '嚴謹的語法，有資料驗證機制
    Private Function getLength(ByVal a As String, ByVal b As String) As Decimal
        '斜邊c，預設值為-1
        Dim valueC As Decimal = -1
        '判斷a與b是否為數字
        If IsNumeric(a) And IsNumeric(b) Then
            '斜邊a，以CDec將String型別轉換成Decimal型別
            Dim valueA As Decimal = CDec(a)
            '斜邊b，以CDec將String型別轉換成Decimal型別
            Dim valueB As Decimal = CDec(b)
            'a與b必須大於0
            If valueA > 0 And valueB > 0 Then
                '計算a+b的平方根
                valueC = Math.Sqrt(Math.Pow(valueA, 2) + Math.Pow(valueB, 2))
            End If
        End If

        Return valueC   '回傳c
    End Function


    '計算斜邊c的事件處理程式
    Protected Sub btnCal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCal.Click
        Dim a As String = txtA.Text
        Dim b As String = txtB.Text
        Dim c As Decimal = getLength(a, b)
        '顯示斜邊c的長度，如果回傳值為-1，表示a或b輸入值不合法
        txtMsg.Text = "斜邊c的長度為：" & IIf(c = -1, "a或b輸入值不合法！", c.ToString)
    End Sub
End Class




