
Partial Class ArraySearch
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Write("<H2>陣列元素的比對與搜尋</H2>")
        Dim names() As String = New String() {"Kevin", "Mary", "Bob", "Cindy", "Larry", "David", "Joe", "Cathy", "Rose", "Michael"}
        '列出陣列中所有的名字
        Response.Write("陣列中所有的名字：")

        For Each n As String In names
            Response.Write(n + " , ")
        Next

        Response.Write("<BR/><BR/>")

        'Exists
        Response.Write("陣列中是否有名字的字元長度等於5：" & Array.Exists(names, AddressOf getNameLength))
        Response.Write("<BR/><BR/>")

        'Find
        Response.Write("陣列中第一個名字字元長度等於5的是：" & Array.Find(names, AddressOf getNameLength))
        Response.Write("<BR/><BR/>")

        'FindLast
        Response.Write("陣列中最後一個名字字元長度等於5的是：" & Array.FindLast(names, AddressOf getNameLength))

        'FindAll
        Response.Write("<BR/><BR/>")
        Response.Write("陣列中名字字元長度等於5的所有名字如下：<UL>")

        Dim allNames() As String = Array.FindAll(names, AddressOf getNameLength)

        For Each n As String In allNames
            Response.Write("<Li>" & n)
        Next

        Response.Write("</UL>")

        'Index
        Response.Write("Cindy於陣列中的索引值為：" & Array.IndexOf(names, "Cindy"))
        Response.Write("<BR/><BR/>")

        'BinarySearch
        '陣列必須先排序才能呼叫BinarySearch方法
        System.Array.Sort(names)

        Dim person As Object = "Mary"
        Dim index As Integer = System.Array.BinarySearch(names, person)

        If index > 0 Then
            Response.Write(String.Format("尋找{0}的名字位於陣列的索引位置為：{1}", person, index))
        End If
    End Sub

    '判斷陣列中名字的字元長度是否有等於5
    Protected Shared Function getNameLength(ByVal name As String) As Boolean
        If name.Length = 5 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
