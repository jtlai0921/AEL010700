
Partial Class intArray
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '第一種，初始化明確指定陣列的大小為4
        Dim myArray1() As Integer = New Integer(4) {1, 3, 5, 7, 9}

        '第二種，初始化省略陣列的大小
        Dim myArray2() As Integer = New Integer() {1, 3, 5, 7, 9}

        '第三種，初始化省略掉New Integer()的陳述式
        Dim myArray3() As Integer = {1, 3, 5, 7, 9}

        '第四種，先宣告及初始化陣列，稍後再指定陣列元素的值
        Dim myArray4() As Integer = New Integer(4) {}
        myArray4(0) = 1
        myArray4(1) = 3
        myArray4(2) = 5
        myArray4(3) = 7
        myArray4(4) = 9

        '顯示myArray1~myArray4陣列的元素值
        Response.Write("<H2>一維的Integer型別陣列之四種初始化方式</H2>")
        Response.Write(String.Format("myArray1的元素值：{0}<BR/>", myArray1(0)))
        Response.Write(String.Format("myArray2的元素值：{0}<BR/>", myArray1(1)))
        Response.Write(String.Format("myArray3的元素值：{0}<BR/>", myArray1(3)))
        Response.Write(String.Format("myArray4的元素值：{0}<BR/>", myArray1(4)))
    End Sub
End Class
