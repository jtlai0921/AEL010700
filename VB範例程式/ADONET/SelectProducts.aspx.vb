Imports System.Data
Imports System.Data.SqlClient

Partial Class SelectProducts
    Inherits System.Web.UI.Page

    '讀取產品資料
    Protected Sub btnRead_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRead.Click
        '建立資料庫連線
        Dim conn As New SqlConnection("Data Source=.;Initial Catalog=myDB;User Id=sa;Password=test")
        conn.Open()    '開啓資料庫連線

        '建立SqlCommand查詢命令
        Dim cmd As New SqlCommand("Select * From myProducts ", conn)
        Dim dr As SqlDataReader = cmd.ExecuteReader()   '執行查詢

        gvProducts.DataSource = dr '指定GridView控制項之資料來源
        gvProducts.DataBind()  '資料繫結

        '釋放物件及連線資源
        dr.Dispose()
        cmd.Dispose()
        conn.Close()
        conn.Dispose()
    End Sub
End Class
