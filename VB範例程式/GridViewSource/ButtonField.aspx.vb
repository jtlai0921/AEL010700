
Partial Class ButtonField
    Inherits System.Web.UI.Page

    '建立GridView Button按鈕的RowCommand事件
    Protected Sub gvProducts_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvProducts.RowCommand
        '取得哪個Row的列索引
        Dim index As Integer = CType(e.CommandArgument, Int32)
        Dim selectedRow As GridViewRow = gvProducts.Rows(index)
        '取得該列Row的欄位產品名稱代號
        Dim productName As TableCell = selectedRow.Cells(1)
        '判斷使用者按下的是哪個種類的按鈕
        Select Case e.CommandName
            Case "Order"
                '將訂購的產品名稱加入ListBox
                lbOrders.Items.Add(productName.Text)
            Case "CancelOrder"
                '將取消的產品名稱自ListBox移除
                If (lbOrders.Items.Count > 0) Then
                    Dim i As Integer = 0

                    Do While (i <= lbOrders.Items.Count - 1)
                        If (lbOrders.Items(i).Text = productName.Text) Then
                            lbOrders.Items.Remove(lbOrders.Items(i))
                            Exit Do
                        Else
                            i += 1
                        End If
                    Loop
                End If
        End Select
    End Sub
End Class
