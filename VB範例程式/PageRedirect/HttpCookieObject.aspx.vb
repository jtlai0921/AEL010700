
Partial Class HttpCookieObject
    Inherits System.Web.UI.Page

    '儲存資料到Cookie
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (Not String.IsNullOrEmpty(txtName.Text) And Not String.IsNullOrEmpty(txtBlood.Text) And Not String.IsNullOrEmpty(txtHobby.Text)) Then
            '以HttpCookie加入與儲存Cookie資料
            Dim userCookie As New HttpCookie("userInfo")
            userCookie.Name = "userInfo"
            userCookie.Values("Name") = txtName.Text
            userCookie.Values("Blood") = txtBlood.Text
            userCookie.Values("Hobby") = txtHobby.Text
            userCookie.Expires = DateTime.Now.AddDays(1)
            Response.Cookies.Add(userCookie)

            txtMsg.Text = "Cookie資料儲存成功！"
        Else
            txtMsg.Text = "TextBox不得為空白或Nothing"
        End If

    End Sub

    '讀取Cookie資料
    Protected Sub btnRead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRead.Click
        '讀取userInfo的Cookie集合
        Dim userCookies As HttpCookie = Request.Cookies("userInfo")

        If userCookies IsNot Nothing Then
            Dim sb As New StringBuilder()
            sb.Append("姓名：" & Server.HtmlEncode(userCookies("Name")) & "<BR/>")
            sb.Append("血型：" & Server.HtmlEncode(userCookies("Blood")) & "<BR/>")
            sb.Append("興趣：" & Server.HtmlEncode(userCookies("Hobby")) & "<BR/>")
            txtMsg.Text = sb.ToString()
        Else
            txtMsg.Text = "Cookie為Nothing"
        End If
    End Sub

    '讀取Cookies集合中的資料
    Protected Sub btnReadAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReadAll.Click
        Dim sb As New StringBuilder()
        '取得Cookies集合
        Dim cookies As HttpCookieCollection = Request.Cookies

        '以迴圈讀取HttpCookieCollection物件中的Cookis集合
        For i As Integer = 0 To cookies.Count - 1
            sb.Append("Name：" & cookies(i).Name & "<BR/>")
            sb.Append("Value：" & cookies(i).Value & "<BR/>")
            sb.Append("Expires：" & cookies(i).Expires.ToLocalTime() & "<BR/><BR/>")
        Next

        txtMsg.Text = sb.ToString()
    End Sub
End Class
