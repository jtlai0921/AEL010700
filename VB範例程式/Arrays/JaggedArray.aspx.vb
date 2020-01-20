
Partial Class JaggedArray
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '宣告不規則陣列
        Dim myJaggedArray()() As Integer = New Integer(2)() {}

        '設定陣列元素
        myJaggedArray(0) = New Integer(1) {3, 5}
        myJaggedArray(1) = New Integer(2) {1, 2, 4}
        myJaggedArray(2) = New Integer(3) {5, 2, 4, 3}

        '存取不規則陣列元素資料
        Response.Write("<H2>不規則陣列</H2>")
        Response.Write(myJaggedArray(0)(1) & "<BR/>")
        Response.Write(myJaggedArray(1)(2) & "<BR/>")
        Response.Write(myJaggedArray(2)(3) & "<BR/>")
    End Sub
End Class
