
Partial Class adoTransaction
    Inherits System.Web.UI.Page

    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        InsertRecord()  '新增員工資料
    End Sub

    '新增資料紀錄
    Protected Sub InsertRecord()
        Dim connString As String = WebConfigurationManager.ConnectionStrings("NorthwindConnection").ConnectionString
        Dim conn As New SqlConnection(connString)
        conn.Open()
        '建立交易Transaction
        Dim tran As SqlTransaction = conn.BeginTransaction
        Dim strSQL As String = "INSERT INTO Employees(FirstName, LastName, City, Address) values (@paramFirstName,@paramLastName,@paramCity,@paramAddress)"
        Dim cmd As New SqlCommand(strSQL, conn, tran)

        Try
            cmd.Parameters.Add("@paramFirstName", SqlDbType.NVarChar, 20).Value = txtFirstName.Text
            cmd.Parameters.Add("@paramLastName", SqlDbType.NVarChar, 10).Value = txtLastName.Text
            cmd.Parameters.Add("@paramCity", SqlDbType.NVarChar, 15).Value = txtCity.Text
            cmd.Parameters.Add("@paramAddress", SqlDbType.NVarChar, 60).Value = txtAddress.Text
            cmd.ExecuteNonQuery()
            tran.Commit()   '確認交易
            txtMsg.Text = "新增資料成功,交易確認!"
        Catch ex As Exception
            tran.Rollback()   '交易回復
            txtMsg.Text = "新增資料失敗,交易Rollback!,失敗原因為：" & ex.ToString()
        Finally
            conn.Close()
            conn.Dispose()
            tran.Dispose()
            cmd.Dispose()
        End Try
    End Sub
End Class
