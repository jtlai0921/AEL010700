Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Linq
Imports System.Xml.Linq

Partial Class SampleFile
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '網頁載入時之事件程式
        '顯示目前時間
        Dim time As String = getTime()
        Response.Write("現在時間是:" & time & "<BR/>")
    End Sub

    REM 這是單行註解
    '顯示TextBox輸入文字資料
    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Response.Write("您輸入的文字是：" & txtMsg.Text)
    End Sub

    ''' <summary>
    ''' 取得伺服器時間方法
    ''' </summary>
    ''' <returns>回傳時間字串</returns>
    Protected Function getTime() As String
        Return DateTime.Now.ToLongTimeString()
    End Function
End Class
