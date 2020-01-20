
Partial Class Logical
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '以下為Tom個人年齡及學科測試成績
        Dim age As Integer = 28
        Dim english As Integer = 70
        Dim math As Integer = 85
        Dim chinese As Integer = 100

        '顯示年齡及成績
        Response.Write("<H2>以邏輯運算子進行邏輯條件運算</H2>")
        Response.Write("Tom的年齡及成績如下：<BR/>")
        Response.Write("年齡=" & age & "，")
        Dim str = "英文={0}，數學={1}，國文={2}<BR/><BR/>"
        Response.Write(String.Format(str, english, math, chinese))

        '以邏輯運算子And及Or進行邏輯條件運算
        If age >= 20 And age < 30 Then
            If english < 80 Or math < 80 Or chinese < 80 Then
                Response.Write("學科成績有一科低於80分，不予錄取！")
            Else
                Response.Write("錄取通過！")
            End If
        Else
            Response.Write("年齡不符，無法參試！")
        End If
    End Sub
End Class
