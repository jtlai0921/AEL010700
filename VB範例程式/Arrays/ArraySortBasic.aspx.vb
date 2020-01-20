
Partial Class ArraySortBasic
    Inherits System.Web.UI.Page

    '建立陣列，並排序
    Protected Sub btnSort_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSort.Click
        txtBefore.Text = Nothing
        '排序前的陣列
        Dim myArray() As Integer = New Integer(9) {}

        '以亂數產生陣列
        Dim rnd As New Random()
        For i = 0 To 9
            myArray(i) = rnd.Next(0, 100)
            txtBefore.Text &= CType(myArray(i), String) & vbCrLf
        Next

        txtAfter.Text = Nothing
        '排序後的陣列
        System.Array.Sort(myArray)
        For i = 0 To 9
            txtAfter.Text &= CType(myArray(i), String) & vbCrLf
        Next
    End Sub
End Class
