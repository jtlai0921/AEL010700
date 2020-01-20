
Partial Class ArrayRedim
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '原始陣列
        Dim intArray(2, 4, 6) As Integer
        Dim str = "第一個陣列長度：{0}，第二個陣列長度：{1}，第三個陣列長度：{2}"
        Dim value1 = intArray.GetLength(0)  '第一個維度之長度大小
        Dim value2 = intArray.GetLength(1)  '第二個維度之長度大小
        Dim value3 = intArray.GetLength(2)  '第三個維度之長度大小
        Response.Write("<H2>以ReDim變更陣列大小</H2>")
        Response.Write("<H4>原始陣列大小</H4>")
        Response.Write(String.Format(str, value1, value2, value3))


        '增加陣列大小
        ReDim intArray(5, 7, 9)
        value1 = intArray.GetLength(0)  '第一個維度之長度大小
        value2 = intArray.GetLength(1)  '第二個維度之長度大小
        value3 = intArray.GetLength(2)  '第三個維度之長度大小
        Response.Write("<H4>增加陣列大小</H4>")
        Response.Write(String.Format(str, value1, value2, value3))

        '縮小陣列大小
        ReDim intArray(1, 2, 3)
        value1 = intArray.GetLength(0)  '第一個維度之長度大小
        value2 = intArray.GetLength(1)  '第二個維度之長度大小
        value3 = intArray.GetLength(2)  '第三個維度之長度大小
        Response.Write("<H4>縮小陣列大小</H4>")
        Response.Write(String.Format(str, value1, value2, value3))
    End Sub
End Class
