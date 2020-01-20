
Partial Class DateTimeObject
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '將 DateTime 結構的新執行個體初始化為年、月、日、時、分、秒及毫秒。
        Dim moment As DateTime = New DateTime(2010, 6, 15, 9, 45, 5, 11)

        '取得年2010
        Dim year As Integer = moment.Year

        '取得月6
        Dim month As Integer = moment.Month

        '取得15
        Dim day As Integer = moment.Day

        '取得時9
        Dim hour As Integer = moment.Hour

        '取得分45
        Dim minute As Integer = moment.Minute

        '取得秒32
        Dim second As Integer = moment.Second

        '取得毫秒11
        Dim millisecond As Integer = moment.Millisecond

        Dim param As String = "您所建立的DateTime物件日期時間為：{0}年{1}月{2}日，{3}時{4}分{5}秒{6}毫秒"
        Response.Write(String.Format(param, year, month, day, hour, minute, second, millisecond))
    End Sub
End Class
