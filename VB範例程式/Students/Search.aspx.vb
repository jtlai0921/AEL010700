Imports System.Data

Partial Class Search
    Inherits System.Web.UI.Page

    Protected filter As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("Permission").ToString().Contains("R") Then
            Response.Redirect("Message.aspx?Reason=必須具備讀取權限")
        End If
        txtID.Focus()
    End Sub

    '如果兩個TextBox都沒有輸入任何資料，則取消SqlDataSource查詢動作
    Protected Sub sqlStudents_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles sqlStudents.Selecting
        If String.IsNullOrEmpty(txtID.Text) And String.IsNullOrEmpty(txtName.Text) Then
            e.Cancel = True
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If String.IsNullOrEmpty(txtID.Text) And String.IsNullOrEmpty(txtName.Text) Then
            txtMsg.Text = "請至少輸入一個查詢！"
        Else
            '加入Where條件式-ID
            If Not String.IsNullOrEmpty(txtID.Text) Then
                filter = " Where ID like @paramID"
                sqlStudents.SelectCommand = sqlStudents.SelectCommand & filter
                If sqlStudents.SelectParameters("paramID") Is Nothing Then
                    sqlStudents.SelectParameters.Add("paramID", TypeCode.String, "")
                End If
                sqlStudents.SelectParameters("paramID").DefaultValue = "%" & txtID.Text & "%"
            End If

            '加入Where條件式-Name
            If Not String.IsNullOrEmpty(txtName.Text) Then
                If filter = "" Then
                    filter = " Where Name like @paramName"
                Else
                    filter = " " & dwnAndOr.SelectedValue & " Name like @paramName"
                End If
                sqlStudents.SelectCommand = sqlStudents.SelectCommand & filter
                If sqlStudents.SelectParameters("paramName") Is Nothing Then
                    sqlStudents.SelectParameters.Add("paramName", TypeCode.String, "")
                End If
                sqlStudents.SelectParameters("paramName").DefaultValue = "%" & txtName.Text & "%"
            End If
            '進行查詢
            sqlStudents.Select(DataSourceSelectArguments.Empty)
        End If
    End Sub

    '將Gender性別的Boolean，由True或False轉換成男或女
    Protected Sub gvStudents_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvStudents.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim view As DataRowView = CType(e.Row.DataItem, DataRowView)
            If view IsNot Nothing Then
                '取得Gender欄位資料
                If Not String.IsNullOrEmpty(view.Item(2)) Then
                    Dim gender As Boolean = view.Item(2)
                    Dim txtGender = CType(e.Row.Cells(3).FindControl("txtGender"), Label)
                    If txtGender IsNot Nothing Then
                        If gender = True Then
                            txtGender.Text = "男"
                        Else
                            txtGender.Text = "女"
                        End If
                    End If
                End If
            End If
        End If
    End Sub
End Class
