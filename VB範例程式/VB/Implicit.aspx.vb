
Partial Class Implicit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Integer型別
        Dim height As Integer = 180 '身高
        Dim weight As Integer = 75  '體重

        'Long型別
        Dim h As Long = height
        Dim w As Long = weight

        'Single型別
        Dim h1 As Single = height
        Dim w1 As Single = weight

        Response.Write("<H2>隱含轉換</H2>")
        Response.Write(String.Format("身高為：{0}，體重為：{1}（Integer->Long）<BR/>", h, w))
        Response.Write(String.Format("身高為：{0}，體重為：{1}（Integer->Single）<BR/>", h1, w1))
    End Sub
End Class
