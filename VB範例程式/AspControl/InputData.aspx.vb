
Partial Class InputData
    Inherits System.Web.UI.Page

    '導向另一個網頁
    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        '傳統寫法
        Response.Redirect("ShowData.aspx?ID=" & txtID.Text & "&Password=" & _
                          txtPassword.Text & "&Msg=" & txtMsg.Text)
        '使用字串參數的型式
        Response.Redirect(String.Format("ShowData.aspx?ID={0}&Password={1}&Msg={2}",txtID.Text, txtPassword.Text, txtMsg.Text))
    End Sub
End Class
