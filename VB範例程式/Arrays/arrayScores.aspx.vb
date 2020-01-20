
Partial Class arrayScores
    Inherits System.Web.UI.Page

    '計算每位學生考試分數
    Protected Sub btnCalculate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCalculate.Click
        '建立3列3行之Scores成績二維陣列
        Dim Scores(,) As Integer = New Integer(2, 2) {{78, 92, 85}, {85, 87, 90}, {82, 100, 88}}

        '計算每位學生之考試總分
        txtA.Text = Convert.ToString(Scores(0, 0) + Scores(0, 1) + Scores(0, 2))
        txtB.Text = Convert.ToString(Scores(1, 0) + Scores(1, 1) + Scores(1, 2))
        txtC.Text = Convert.ToString(Scores(2, 0) + Scores(2, 1) + Scores(2, 2))
    End Sub
End Class
