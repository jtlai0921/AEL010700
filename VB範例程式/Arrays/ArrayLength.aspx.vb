
Partial Class ArrayLength
    Inherits System.Web.UI.Page

    '以亂數動態建立不固定長度陣列
    Protected Sub btnArray_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnArray.Click
        txtLength.Text = "陣列的長度為："
        txtArray.Text = Nothing '將TextBox控制項清空

        Dim rnd As New Random() '建立亂數rnd instance
        Dim len As Integer = rnd.Next(1, 10)    '產生一個介於1~10之間的亂數值
        '建立一個以len為長度的陣列
        Dim myArray() As Integer = New Integer(len - 1) {}

        For i = 0 To len - 1
            myArray(i) = rnd.Next(1, 50)    '以隨機亂數指定陣列元素值
            '將陣列元素值加到TextBox之中
            txtArray.Text += CType(myArray(i), String) & vbCrLf
        Next

        '讀取得陣列的長度，取得陣列元素總數目
        txtLength.Text += CType(myArray.Length, String)
    End Sub
End Class
