
Partial Class ArrayInitialize
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim price() As Integer 'Integer型別陣列宣告
        price = New Integer(4) {}  '陣列初始化

        Dim models As String()  'String型別陣列宣告
        models = New String(4) {}

        Dim x As Integer = 0
        Response.Write(x)

        '陣列的宣告與初始化
        Dim Height As Integer() = New Integer(4) {182, 170, 165, 174, 152}
    End Sub
End Class
