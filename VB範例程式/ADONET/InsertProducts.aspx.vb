Imports System.Data
Imports System.Data.SqlClient

Partial Class InsertProducts
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            showProducts()  '顯示產品資料
        End If
    End Sub

    '新增產品資料
    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        '簡化的ADO.NET程式
        'Dim conn As SqlConnection = New SqlConnection("Data Source=.;Initial Catalog=myDB;User Id=sa;Password=test")
        'conn.Open()
        'Dim cmd As SqlCommand = New SqlCommand("Insert Into myProducts (ProductID,ProductName,Quantity,Price) Values ('M0001','芒果汁',100,25) ", conn)
        'cmd.ExecuteNonQuery()
        '釋放物件及連線資源
        'cmd.Dispose()
        'conn.Close()
        'conn.Dispose()


        '較為嚴謹及防止例外錯誤產生
        Dim conn As SqlConnection = New SqlConnection("Data Source=.;Initial Catalog=myDB;User Id=sa;Password=test")
        Dim cmd As SqlCommand = Nothing

        Try
            conn.Open()     '開啓資料庫連線
            '建立SqlCommand查詢命令
            cmd = New SqlCommand("Insert Into myProducts (ProductID,ProductName,Quantity,Price) Values ('M0001','芒果汁',100,25) ", conn)
            cmd.ExecuteNonQuery()   '執行SQL陳述式命令
        Catch ex As Exception
            txtMsg.Text = ex.ToString() '顯示錯誤訊息
        Finally
            '釋放物件及連線資源
            cmd.Dispose()
            conn.Close()
            conn.Dispose()
        End Try

        showProducts() '顯示產品資料
    End Sub

    '顯示產品資料
    Protected Sub showProducts()
        '建立資料庫連線
        Dim conn As New SqlConnection("Data Source=.;Initial Catalog=myDB;User Id=sa;Password=test")
        conn.Open() '開啓資料庫連線

        '建立SqlCommand查詢命令
        Dim cmd As New SqlCommand("Select * From myProducts ", conn)
        Dim dr As SqlDataReader = cmd.ExecuteReader()   '執行查詢

        gvProducts.DataSource = dr  '指定GridView控制項之資料來源
        gvProducts.DataBind()   '資料繫結

        '釋放物件及連線資源
        dr.Dispose()
        cmd.Dispose()
        conn.Close()
        conn.Dispose()
    End Sub
End Class
