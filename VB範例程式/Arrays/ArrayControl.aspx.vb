
Partial Class ArrayControl
    Inherits System.Web.UI.Page

    '將陣列中的產品資料加入到ASP.NET控制項之中
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim products() As String = New String() {"電腦", "LCD螢幕", "HDD硬碟", "CPU處理器", "RAM記憶體"}
        '1.以迴圈將陣列元素加入到DropDownList控制項之中
        For Each p As String In products
            dwnProducts.Items.Add(p)
        Next

        '2.透過DropDownList的DataSource屬性，指定資料來源為陣列
        dwnProducts1.DataSource = products
        dwnProducts1.DataBind() '資料繫結

        '將資料繫結到GridView控制項之中
        gvProducts.DataSource = products
        gvProducts.DataBind()
    End Sub

    Protected Sub dwnProducts_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dwnProducts.SelectedIndexChanged
        '將sender轉換成DropDownList控制項，
        '當成參數傳入showProduct()方法之中
        showProduct(CType(sender, DropDownList))
    End Sub

    Protected Sub dwnProducts1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dwnProducts1.SelectedIndexChanged
        showProduct(CType(sender, DropDownList))
    End Sub

    '顯示產品名稱
    Protected Sub showProduct(ByVal product As DropDownList)
        txtMsg.Text = "您選擇的產品是：" & product.SelectedItem.Text
    End Sub
End Class
