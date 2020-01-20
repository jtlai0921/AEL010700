
Partial Class intArray2D
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '第一種，明確指定陣列大小
        Dim myArray1(,) As Integer = New Integer(3, 1) {{1, 2}, {3, 4}, {5, 6}, {7, 8}}

        '第二種，省略明確指定陣列大小
        Dim myArray2(,) As Integer = New Integer(,) {{1, 2}, {3, 4}, {5, 6}, {7, 8}}

        '第三種，省略掉New Integer(,)
        Dim myArray3(,) As Integer = {{1, 2}, {3, 4}, {5, 6}, {7, 8}}

        '第四種，先宣告與初始化陣列，稍後再指定陣列的元素值
        Dim myArray4(,) As Integer = New Integer(3, 1) {}
        myArray4(0, 0) = 1
        myArray4(0, 1) = 2
        myArray4(1, 0) = 3
        myArray4(1, 1) = 4
        myArray4(2, 0) = 5
        myArray4(2, 1) = 6
        myArray4(3, 0) = 7
        myArray4(3, 1) = 8

        '顯示myArray1~myArray4陣列的元素值
        Response.Write("<H2>二維的Integer型別陣列之四種初始化方式</H2>")
        Response.Write(String.Format("myArray1(0, 1)的元素值：{0}<BR/>", myArray1(0, 1)))
        Response.Write(String.Format("myArray2(1, 1)的元素值：{0}<BR/>", myArray2(1, 1)))
        Response.Write(String.Format("myArray3(2, 0)的元素值：{0}<BR/>", myArray3(2, 0)))
        Response.Write(String.Format("myArray4(3, 1)的元素值：{0}<BR/>", myArray4(3, 1)))
    End Sub
End Class
