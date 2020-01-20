
Partial Class DataViewBasic
    Inherits System.Web.UI.Page

    'DataView資料檢視的運用
    Protected Sub btnDataView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDataView.Click
        '取得Web.config中的資料庫連線字串設定
        Dim connString As String = WebConfigurationManager.ConnectionStrings("NorthwindConnection").ConnectionString
        Dim conn As New SqlConnection(connString)
        conn.Open()

        '建立SqlDataAdapter
        Dim da As New SqlDataAdapter("Select EmployeeID,LastName,FirstName,City,Country From Employees", conn)
        Dim ds As New DataSet() '建立DataSet資料集
        da.Fill(ds, "Employees") '將資料注入到DataSet之中，並命名DataTable為Products

        conn.Close()    '資料在Fill到DataSet之後，即可關閉資料庫連線
        conn.Dispose()

        '建立DataView資料檢視，篩選Country為USA的員工
        '並依City,LastName二個欄位排序
        Dim dvUSA As New DataView(ds.Tables("Employees"), "Country='USA'", "City,LastName", DataViewRowState.CurrentRows)
        '顯示USA美國員工資料
        GridView1.DataSource = dvUSA
        GridView1.DataBind()

        '建立DataView資料檢視，篩選Country為UK的員工
        '並依EmployeeID,LastName二個欄位排序
        Dim dvUK As New DataView(ds.Tables("Employees"), "Country='UK'", "EmployeeID,LastName", DataViewRowState.CurrentRows)
        '顯示UK英國員工資料
        GridView2.DataSource = dvUK
        GridView2.DataBind()
    End Sub
End Class
