
Partial Class CookiesAdvanced
    Inherits System.Web.UI.Page

    '儲存資料到Cookie
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (Not String.IsNullOrEmpty(txtName.Text) And Not String.IsNullOrEmpty(txtBlood.Text) And Not String.IsNullOrEmpty(txtHobby.Text)) Then
            '單一Cookie使用SubKey加入多重Key-Value資料值
            Response.Cookies("UserInfo")("Name") = txtName.Text
            Response.Cookies("UserInfo")("Blood") = txtBlood.Text
            Response.Cookies("UserInfo")("Hobby") = txtHobby.Text
            Response.Cookies("UserInfo").Expires = DateTime.Now.AddDays(1)
            txtMsg.Text = "Cookie資料儲存成功！"
        Else
            txtMsg.Text = "TextBox不得為空白或Nothing"
        End If
    End Sub

    '讀取Cookie資料
    Protected Sub btnRead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRead.Click
        If Request.Cookies("UserInfo") IsNot Nothing Then
            Dim sb As New StringBuilder()
            sb.Append("姓名：" & Server.HtmlEncode(Request.Cookies("UserInfo")("Name")) & "<BR/>")
            sb.Append("血型：" & Server.HtmlEncode(Request.Cookies("UserInfo")("Blood")) & "<BR/>")
            sb.Append("興趣：" & Server.HtmlEncode(Request.Cookies("UserInfo")("Hobby")) & "<BR/>")

            '另一種讀取的語法
            'sb.Append("姓名：" & Server.HtmlEncode(Request.Cookies("UserInfo").Values("Name")) & "<BR/>")
            'sb.Append("血型：" & Server.HtmlEncode(Request.Cookies("UserInfo").Values("Blood")) & "<BR/>")
            'sb.Append("興趣：" & Server.HtmlEncode(Request.Cookies("UserInfo").Values("Hobby")) & "<BR/>")

            txtMsg.Text = sb.ToString()

            '顯示單一Cookie中所有Key-Value的資料值
            'txtMsg.Text = "<BR/>" & Request.Cookies("UserInfo").Value
        Else
            txtMsg.Text = "Cookie為Nothing"
        End If
    End Sub
End Class
