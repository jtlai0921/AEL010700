Imports System.Drawing

Partial Class PanelControl
    Inherits System.Web.UI.Page

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        AddControls()  '呼叫AddControls()方法
    End Sub

    Protected Sub AddControls()
        Dim t1 As New TextBox()
        t1.Text = "動態加入第一個TextBox"
        t1.BackColor = Color.LightBlue

        Dim t2 As New TextBox()
        t2.Text = "動態加入第二個TextBox"
        t2.BackColor = Color.LightPink

        Dim t3 As New TextBox()
        t3.Text = "動態加入第三個TextBox"
        t3.BackColor = Color.LightGreen

        Dim t4 As New TextBox()
        t4.Text = "動態加入第四個TextBox"
        t4.BackColor = Color.LightSalmon

        '將TextBox控制項加入到Panel之中
        Panel1.Controls.Add(t1)
        Panel1.Controls.Add(t2)
        Panel1.Controls.Add(t3)
        Panel1.Controls.Add(t4)
    End Sub
End Class
