
Partial Class ArrayRank
    Inherits System.Web.UI.Page

    Dim myArray1() As Integer   '宣告第一個陣列
    Dim myArray2(,) As Integer  '宣告第二個陣列
    Dim myArray3(,,) As Integer '宣告第三個陣列

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '初始化陣列
        myArray1 = New Integer(1) {}
        myArray2 = New Integer(4, 1) {}
        myArray3 = New Integer(9, 4, 1) {}
    End Sub

    '取得陣列的維度
    Protected Sub btnGetRank_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetRank.Click
        txtArray1.Text = myArray1.Rank.ToString()
        txtArray2.Text = myArray2.Rank.ToString()
        txtArray3.Text = myArray3.Rank.ToString()
    End Sub
End Class
