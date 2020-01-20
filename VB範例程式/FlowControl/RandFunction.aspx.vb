Imports System.Drawing

Partial Class RandFunction
    Inherits System.Web.UI.Page

    Protected Sub btnRand_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRand.Click
        Randomize() '初始化亂數產生器

        '以亂數產生18~36的字型大小
        Dim size As Integer = CInt(Int((36 - 18) * Rnd() + 18))
        txtTitle.Font.Size = FontUnit.Point(size)

        '以亂數產生0~255前景色數值
        Dim r As Integer = CInt(Int(255 * Rnd() + 0)) 'Red紅色
        Dim g As Integer = CInt(Int(255 * Rnd() + 0)) 'Green綠色
        Dim b As Integer = CInt(Int(255 * Rnd() + 0)) 'Blue藍色
        '以亂數設定標題前景色（Red , Green , Blue）
        txtTitle.ForeColor = Color.FromArgb(r, g, b)

        '以亂數產生0~255背景色數值
        Dim r1 As Integer = CInt(Int(255 * Rnd() + 0)) 'Red紅色
        Dim g1 As Integer = CInt(Int(255 * Rnd() + 0)) 'Green綠色
        Dim b1 As Integer = CInt(Int(255 * Rnd() + 0)) 'Blue藍色
        '以亂數設定標題背景色（Red , Green , Blue）
        txtTitle.BackColor = Color.FromArgb(r1, g1, b1)

        txtMsg.Text = "字型大小為：" & size & "<BR/>"
        txtMsg.Text &= String.Format("前景色：Red：{0} , Green：{1} , Blue：{2}", r, g, b)
        txtMsg.Text &= "<BR/>" & String.Format("背景色：Red：{0} , Green：{1} , Blue：{2}", r1, g1, b1)
    End Sub
End Class
