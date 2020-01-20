
Partial Class RequiredFieldBasic
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    '顯示使用者輸入資料
    Protected Sub btnSumbit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSumbit.Click
        If Page.IsValid Then
            txtMsg.Text = "您輸入的基本資料如下：<BR/>"
            txtMsg.Text &= "姓名：" & Server.HtmlEncode(txtName.Text) & "<BR/>"
            txtMsg.Text &= "電話：" & Server.HtmlEncode(txtTel.Text) & "<BR/>"
        Else
            txtMsg.Text = "您輸入的資料沒有通過驗證！"
        End If
    End Sub
End Class
