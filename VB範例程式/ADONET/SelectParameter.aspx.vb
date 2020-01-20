Imports System.Data
Imports System.Data.SqlClient

Partial Class SelectParameter
    Inherits System.Web.UI.Page

    '以產品編號查詢產品資料
    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        '第一種寫法，於一行程式中完成SqlParameter之宣告與設定值
        '判斷TextBox控制項中是否有輸入產品名稱
        If Not String.IsNullOrEmpty(txtProductID.Text) Then
            Dim conn As New SqlConnection("Data Source=.;Initial Catalog=myDB;User Id=sa;Password=test")
            conn.Open() '開啓資料庫連線

            '建立SqlCommand查詢命令
            Dim cmd As New SqlCommand("Select * From myProducts Where ProductID=@paramPID", conn)
            '於SqlCommand中加入SqlParameter參數，並設定參數值
            cmd.Parameters.Add("@paramPID", SqlDbType.NVarChar, 10).Value = txtProductID.Text

            Dim dr As SqlDataReader = cmd.ExecuteReader()   '執行查詢

            '判斷SqlDataReader是否含有回傳之資料記錄
            If dr.HasRows Then
                '將資料記錄顯示在GridView控制項上
                gvProducts.Visible = True
                txtMsg.Visible = False
                gvProducts.DataSource = dr
                gvProducts.DataBind()
            Else
                '顯示查不到之訊息
                gvProducts.Visible = False
                txtMsg.Visible = True
                txtMsg.Text = "查無該項產品之資料記錄！"
            End If

            '釋放物件及連線資源
            dr.Dispose()
            cmd.Dispose()
            conn.Close()
            conn.Dispose()
        Else
            txtMsg.Visible = True
            txtMsg.Text = "產品名稱不得為空白！"
        End If

        'SelectQuery()  '呼叫執行第二種SqlParameter參數的程式
    End Sub

    '第二種寫法，將SqlParameter之宣告與設定值分成數段完成
    Protected Sub SelectQuery()
        If Not String.IsNullOrEmpty(txtProductID.Text) Then
            Dim conn As New SqlConnection("Data Source=.;Initial Catalog=myDB;User Id=sa;Password=test")
            conn.Open() '開啓資料庫連線

            '建立SqlCommand查詢命令
            Dim cmd As New SqlCommand("Select * From myProducts Where ProductID=@paramPID", conn)
            '建立並定義SqlParameter
            Dim p1 As SqlParameter = New SqlParameter()
            '設定p1參數各種屬性
            With p1
                .ParameterName = "@paramPID"            '參數名稱（必須）
                .SqlDbType = SqlDbType.NVarChar         '指定資料型態（必須）
                .Value = txtProductID.Text              '指定參數值（必須）
                .Size = 10                              '指定參數長度（選擇性）
                .IsNullable = False                     '是否可以Null（選擇性）
                .Direction = ParameterDirection.Input   '參數方向（選擇性）
            End With
            '將p1參數加入到SqlCommand的Parameters集合
            cmd.Parameters.Add(p1)
            Dim dr As SqlDataReader = cmd.ExecuteReader()   '執行查詢

            '判斷SqlDataReader是否含有回傳之資料記錄
            If dr.HasRows Then
                '將資料記錄顯示在GridView控制項上
                gvProducts.Visible = True
                txtMsg.Visible = False
                gvProducts.DataSource = dr
                gvProducts.DataBind()
            Else
                '顯示查不到之訊息
                gvProducts.Visible = False
                txtMsg.Visible = True
                txtMsg.Text = "查無該項產品之資料記錄！"
            End If

            '釋放物件及連線資源
            dr.Dispose()
            cmd.Dispose()
            conn.Close()
            conn.Dispose()
        Else
            txtMsg.Visible = True
            txtMsg.Text = "產品名稱不得為空白！"
        End If
    End Sub
End Class
