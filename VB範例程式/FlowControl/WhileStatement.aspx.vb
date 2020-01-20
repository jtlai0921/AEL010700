
Partial Class WhileStatement
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '動態加入DropDownList成員項目
        If Not IsPostBack Then
            dwnHeight.Items.Add("==請選擇身高==")
            Dim h As Integer = 160

            '產生160~185 cm的身高項目
            While h <= 185
                dwnHeight.Items.Add(h.ToString() & "cm")
                h += 1
                '或者可以Exit While來強制離開While迴圈
                'If h > 180 Then
                '    Exit While
                'End If
            End While

        End If
    End Sub

    '顯示選擇的身高
    Protected Sub dwnHeight_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dwnHeight.SelectedIndexChanged
        If dwnHeight.SelectedItem.Text <> "==請選擇身高==" Then
            txtMsg.Text = "您的身高為：" & dwnHeight.SelectedItem.Text
        Else
            txtMsg.Text = ""
        End If
    End Sub


End Class
