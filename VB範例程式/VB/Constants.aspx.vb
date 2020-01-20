
Partial Class Constants
    Inherits System.Web.UI.Page

    Public Const Pi As Double = 3.1415  '宣告Pi圓週率
    Public radius As Double '宣告圓形之半徑

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Write("<H2>以常數宣告pi圓週率</H2>")
        '以下修改Pi常數是不合法的
        'Pi = 4
        radius = 5
        Response.Write("圓形之面積為：" & radius * radius * Pi)
    End Sub
End Class
