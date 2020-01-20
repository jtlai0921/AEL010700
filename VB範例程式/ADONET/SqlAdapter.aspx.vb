
Partial Class SqlAdapter
    Inherits System.Web.UI.Page

    '以SqlDataAdapter注入資料到DataSet
    Protected Sub btnFill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFill.Click
        '取得Web.config中的資料庫連線字串設定
        Dim connString As String = WebConfigurationManager.ConnectionStrings("myDBConnection").ConnectionString
        Dim conn As New SqlConnection(connString)
        conn.Open()

        '建立SqlDataAdapter
        Dim da As New SqlDataAdapter("Select * From myProducts", conn)
        Dim ds As New DataSet() '建立DataSet資料集
        da.Fill(ds, "Products") '將資料注入到DataSet之中，並命名DataTable為Products

        conn.Close()    '資料在Fill到DataSet之後，即可關閉資料庫連線
        conn.Dispose()

        gvProducts.DataSource = ds
        gvProducts.DataBind()
    End Sub
End Class
