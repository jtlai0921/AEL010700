
Partial Class VBStringModule
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim msg As String = "Hi...My name is Mary."
        Dim s As String = ""
        '使用.NET Framework的String物件函數
        s = msg.ToUpper()   '將輸入字串以ToUpper轉換成大寫
        Response.Write(s + "<BR/>")
        s = msg.ToLower()   '將輸入字串以ToLower轉換成小寫
        Response.Write(s + "<BR/><BR/>")

        '使用VB獨有的字串處理函數
        s = UCase(msg)  '將輸入字串以ToUpper轉換成大寫
        Response.Write(s + "<BR/>")
        s = LCase(msg)  '將輸入字串以ToLower轉換成小寫
        Response.Write(s + "<BR/>")
    End Sub
End Class
