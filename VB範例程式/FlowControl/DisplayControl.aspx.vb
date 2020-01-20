
Partial Class DisplayControl
    Inherits System.Web.UI.Page

    Dim str1 As String = "我的名字是""Tom""."
    Dim str2 As String = "我家住'Taipei'."
    Dim str3 As String = "我的興趣是:'看書、聽音樂、打電腦'."

    Protected Sub btnDisplay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        '使用VB常數控制顯示
        txtMsg.Text = str1 & vbCrLf
        txtMsg.Text &= vbTab & str2 & vbNewLine
        txtMsg.Text &= str3 & vbCrLf & vbCrLf

        '沒有利用VB常數控制顯示
        txtMsg.Text &= str1
        txtMsg.Text &= str2
        txtMsg.Text &= str3
    End Sub
End Class
