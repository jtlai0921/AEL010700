
Partial Class ArraySort
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '方法一，傳統之陣列排序，適用於.NET 1.0,1.1,2.0,3.0,3.5
        'Integer型別陣列，陣列中元素為學生身高
        Dim heights() As Integer = New Integer() {172, 168, 175, 165, 160, 152, 183, 167, 180, 174}

        '使用Array.Sort()方法來進行排序
        Array.Sort(heights)

        '顯示學生身高
        Response.Write("*傳統的學生身高排序（ascending）如下：<BR/>")

        For Each h As Integer In heights
            Response.Write(h & "<BR/>")
        Next

        '方法二，以LINQ語法進行陣列元素之查詢與排序,ascending
        '僅適用於.NET Framework 3.5以上之LINQ
        Response.Write("<BR/>*以LINQ語法進行陣列元素之查詢與排序（ascending）<BR/>")

        Dim students = From h In heights _
                       Order By h Ascending _
                       Select h

        For Each s In students
            Response.Write(s & "<BR/>")
        Next

        '以LINQ語法進行陣列元素之查詢與排序,descending
        Dim students2 = From h In heights _
               Order By h Descending _
               Select h

        For Each s In students2
            Response.Write(s & "<BR/>")
        Next

        '方法三，以C# 3.0的Lambda表示式來進行排序
        '僅適用於.NET Framework 3.5以上的C# 3.0語法
        Response.Write("<BR/>*以C#的Lambda表示式來進行排序（ascending）<BR/>")

        Dim students3 = heights.OrderBy(Function(x) x)

        For Each s In students3
            Response.Write(s & "<BR/>")
        Next
    End Sub
End Class
