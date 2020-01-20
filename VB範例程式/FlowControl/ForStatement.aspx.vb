
Partial Class ForStatement
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Write("<h1>For...Next陳述式</h1>")
        '遞增，動態加入Label控制項
        Dim increase As New Label
        increase.Text = "遞增："
        '設定Label控制項字型大小
        increase.Font.Size = FontUnit.Point(36)
        '指定Label控制項前景顏色
        increase.ForeColor = Drawing.Color.Red
        Me.form1.Controls.Add(increase) '將Label控制項加入form1

        '以For迴圈遞增字型大小
        For i = 0 To 10
            Dim label As New Label()
            label.Text = i & "  "
            label.Font.Size = FontUnit.Point(16 + i * 4)
            label.ForeColor = Drawing.Color.Blue
            Me.form1.Controls.Add(label)
        Next

        '換行
        Dim break As New Label()
        break.Text = "<BR/>"
        Me.form1.Controls.Add(break)

        '以For迴圈遞減字型大小
        Dim decrease As New Label
        decrease.Text = "遞減："
        decrease.Font.Size = FontUnit.Point(36)
        decrease.ForeColor = Drawing.Color.Red
        Me.form1.Controls.Add(decrease)

        For i = 10 To 0 Step -1
            Dim label As New Label()
            label.Text = i & "  "
            label.Font.Size = FontUnit.Point(16 + i * 4)
            label.ForeColor = Drawing.Color.Blue
            Me.form1.Controls.Add(label)
        Next
    End Sub
End Class
