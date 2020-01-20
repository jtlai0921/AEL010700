Imports System.Data
Imports System.Data.SqlClient

Partial Class DeleteParameter
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        showProducts()  '顯示產品資料
    End Sub

    '刪除產品資料記錄
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        '判斷TextBox控制項中是否有輸入產品編號
        If Not String.IsNullOrEmpty(txtProductID.Text) Then
            '建立資料庫連線
            Dim conn As New SqlConnection("Data Source=.;Initial Catalog=myDB;User Id=sa;Password=test")
            Dim cmd As SqlCommand = Nothing
            Dim rows As Integer = -1

            Try
                conn.Open() '開啓資料庫連線

                '建立SqlCommand查詢命令
                cmd = New SqlCommand("Delete From myProducts Where ProductID=@paramPID", conn)
                '於SqlCommand中加入SqlParameter參數，並設定參數值
                cmd.Parameters.Add("@paramPID", SqlDbType.NVarChar, 10).Value = txtProductID.Text
                rows = cmd.ExecuteNonQuery()   '執行命令
            Catch ex As Exception
                txtMsg.Text = ex.ToString()   '顯示錯誤訊息
            Finally
                '釋放物件及連線資源
                cmd.Dispose()
                conn.Close()
                conn.Dispose()
            End Try

            If rows > 0 Then
                txtMsg.Text = String.Format("刪除產品資料記錄{0}筆成功！", rows)
            Else
                txtMsg.Text = "無任何產品資料被刪除！"
            End If

        Else
            txtMsg.Visible = True
            txtMsg.Text = "產品編號不得為空白！"
        End If

        showProducts()
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
