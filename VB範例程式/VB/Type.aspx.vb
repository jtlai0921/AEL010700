
Partial Class Type
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '宣告與設定x1,x2,x3,s與d變數
        Dim x1 = 5
        Dim x2 = 5.0
        Dim x3 = 2147483648
        Dim s = "123"
        Dim d = #4/12/2010 9:32:00 AM#


        '顯示x1,x2,x3,s與d的資料型別
        Response.Write("<H2>以GetType() Function讀取資料型別</H2>")
        Response.Write("x1的型別是：" & x1.GetType().ToString() & "<BR/>")
        Response.Write("x2的型別是：" & x2.GetType().ToString() & "<BR/>")
        Response.Write("x3的型別是：" & x3.GetType().ToString() & "<BR/>")
        Response.Write("s的型別是：" & s.GetType().ToString() & "<BR/>")
        Response.Write("d的型別是：" & d.GetType().ToString() & "<BR/>")
    End Sub
End Class
