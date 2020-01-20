
Partial Class Compare
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtTotalBonus.Text = "10000"
        End If
    End Sub

    '將紅利兌換成現金
    Protected Sub btnConvert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConvert.Click
        '兌換之紅利點利
        Dim bonus As Integer
        Dim cash As Integer
        Dim result As Boolean
        Dim message As String = "紅利{0}點兌換成現金為{1}元，剩餘之紅利點數為{2}點。"

        If Not String.IsNullOrEmpty(txtBonus.Text) Then
            If Page.IsValid Then
                '將紅利由字串轉換為Integer型態
                result = Integer.TryParse(txtBonus.Text, bonus)
                '20點紅利兌換成1元現金
                cash = Math.Abs(Convert.ToInt32(txtBonus.Text) / 20)
                txtMsg.Text = String.Format(message, bonus, cash, CType(txtTotalBonus.Text, Integer) - cash * 20)
                txtMsg.Visible = True
            Else
                txtMsg.Text = ""
            End If
        Else
            txtMsg.Text = "紅利輸入不得為空白！"
        End If
    End Sub
End Class
