
Partial Class DataTableBasic
    Inherits System.Web.UI.Page

    '建立並顯示DataTable資料表
    Protected Sub btnCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        '建立DataTable
        Dim dtMembers As New DataTable("Members")

        '宣告DataTable四個DataColumn欄位定義
        dtMembers.Columns.Add(New DataColumn("會員編號", Type.GetType("System.String")))
        dtMembers.Columns.Add(New DataColumn("姓名", Type.GetType("System.String")))
        dtMembers.Columns.Add(New DataColumn("電話", Type.GetType("System.String")))
        dtMembers.Columns.Add(New DataColumn("居住縣市", Type.GetType("System.String")))

        '加入第一個會員資料
        Dim row1 As DataRow = dtMembers.NewRow()
        row1("會員編號") = "A001"
        row1("姓名") = "王仁義"
        row1("電話") = "0922123456"
        row1("居住縣市") = "台北市"
        dtMembers.Rows.Add(row1)  '將DataRow記錄加到DataTable中

        '加入第二個會員資料
        Dim row2 As DataRow = dtMembers.NewRow()
        row2("會員編號") = "A002"
        row2("姓名") = "林秀琴"
        row2("電話") = "0933478152"
        row2("居住縣市") = "桃園縣"
        dtMembers.Rows.Add(row2)

        '加入第三個會員資料
        Dim row3 As DataRow = dtMembers.NewRow()
        row3("會員編號") = "A003"
        row3("姓名") = "林明月"
        row3("電話") = "0968325182"
        row3("居住縣市") = "台中市縣"
        dtMembers.Rows.Add(row3)

        '加入第四個會員資料
        Dim row4 As DataRow = dtMembers.NewRow()
        row4("會員編號") = "A004"
        row4("姓名") = "陳玉玫"
        row4("電話") = "0935456822"
        row4("居住縣市") = "高雄縣"
        dtMembers.Rows.Add(row4)

        '顯示DataTable資料
        gvMembers.DataSource = dtMembers
        gvMembers.DataBind()
    End Sub
End Class
