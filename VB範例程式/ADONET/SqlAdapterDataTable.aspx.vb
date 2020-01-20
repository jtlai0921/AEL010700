
Partial Class SqlAdapterDataTable
    Inherits System.Web.UI.Page

    Protected Sub btnFill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFill.Click
        '取得Web.config中的資料庫連線字串設定
        Dim connString As String = WebConfigurationManager.ConnectionStrings("myDBConnection").ConnectionString
        Dim conn As New SqlConnection(connString)
        conn.Open()

        '建立SqlDataAdapter
        Dim da As New SqlDataAdapter("Select * From myProducts", conn)
        Dim dtProducts As New DataTable("Products") '建立DataTable資料表
        da.Fill(dtProducts) '將資料注入到DataTable之中

        conn.Close()    '資料在Fill到DataTable之後，即可關閉資料庫連線
        conn.Dispose()

        gvProducts.DataSource = dtProducts
        gvProducts.DataBind()
    End Sub
End Class
