Imports System.Data
Imports System.Data.SqlClient

Partial Class InsertParameter
    Inherits System.Web.UI.Page

    Dim info As String = Nothing

    '新增產品記錄
    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        If checkInputValid() Then
            Dim conn As New SqlConnection("Data Source=.;Initial Catalog=myDB;User Id=sa;Password=test")
            Dim cmd As SqlCommand = Nothing

            Try
                conn.Open() '開啓資料庫連線

                '建立SqlCommand查詢命令
                cmd = New SqlCommand("Insert Into myProducts (ProductID,ProductName,Quantity,Price) values (@paramPID,@paramPN,@paramQuantity,@paramPrice)", conn)
                cmd.Parameters.Add("@paramPID", SqlDbType.NVarChar, 10).Value = txtProductID.Text
                cmd.Parameters.Add("@paramPN", SqlDbType.NVarChar, 50).Value = txtProductName.Text
                cmd.Parameters.Add("@paramQuantity", SqlDbType.Int, 4).Value = txtQuantity.Text
                cmd.Parameters.Add("@paramPrice", SqlDbType.SmallMoney, 4).Value = txtPrice.Text

                Dim rows As Integer = cmd.ExecuteNonQuery()
                txtMsg.Text = String.Format("新增產品資料記錄{0}筆成功！", rows)
            Catch ex As Exception
                txtMsg.Text = ex.ToString()   '顯示錯誤訊息
            Finally
                '釋放物件及連線資源
                cmd.Dispose()
                conn.Close()
                conn.Dispose()
            End Try
        Else
            txtMsg.Text = info
        End If
    End Sub

    '檢查TextBox控制項輸入內容是否合法
    Protected Function checkInputValid() As Boolean
        Dim ValidStatus As Boolean = True
        '檢查產品編號是否有輸入
        If String.IsNullOrEmpty(txtProductID.Text) Then
            ValidStatus = False
            info = "*產品編號不得為空白！<BR/>"
        End If

        '檢查產品名稱是否有輸入
        If String.IsNullOrEmpty(txtProductName.Text) Then
            ValidStatus = False
            info &= "*產品名稱不得為空白！<BR/>"
        End If

        '檢查產品數量是否有輸入，並且為數字
        If Not IsNumeric(txtQuantity.Text) Then
            ValidStatus = False
            info &= "*產品數量不得為空白，且必須為數字！<BR/>"
        End If

        '檢查產品價格是否有輸入，並且為數字
        If Not IsNumeric(txtPrice.Text) Then
            ValidStatus = False
            info &= "*產品價格不得為空白，且必須為數字！<BR/>"
        End If

        Return ValidStatus
    End Function
End Class
