
Partial Class Range
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '設定存款餘額為1百萬元
            txtDeposit.Text = "1000000"

            '設定RangeValidator控制項的最小與最大值範圍
            '限定最小提款金額為100元
            RangeValidator1.MinimumValue = "1"
            '設定最大提款金額上限為存款總額
            RangeValidator1.MaximumValue = txtDeposit.Text
            RangeValidator1.ErrorMessage = String.Format("*轉帳金額必須介於{0}到{1}元之間，且不得有英文字或小數點！", RangeValidator1.MinimumValue, RangeValidator1.MaximumValue)
        End If

    End Sub

    '轉帳之處理程序
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        '總存款金額
        Dim deposit As Integer = CType(txtDeposit.Text, Integer)
        Dim withDraw As New Integer()   '轉帳金額
        Dim result As New Boolean()     '型別轉換是否通過

        If Not String.IsNullOrEmpty(txtWithDraw.Text) Then
            '判斷提款金額是否通過RangeValidator控制項的驗證
            '若通過驗證，Page.IsValid為True，否則為False
            If Page.IsValid Then
                result = Integer.TryParse(txtWithDraw.Text, withDraw)
                If result Then
                    txtMsg.Text = String.Format("您的轉帳金額為{0}元，存款餘額為{1}元。", withDraw, deposit - withDraw)
                End If
            Else
                txtMsg.Text = ""
            End If
        Else
            txtMsg.Text = "轉帳金額輸入不得為空白！"
        End If
    End Sub
End Class
