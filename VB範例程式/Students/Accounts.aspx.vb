Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Partial Class Accounts
    Inherits System.Web.UI.Page

    Dim InputMsg As String = ""   '輸入驗證之訊息

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '判斷是否身份通過驗證
        If User.Identity.IsAuthenticated = False Then
            '若未通過驗證，則導向Login頁面
            FormsAuthentication.RedirectToLoginPage()
        Else
            If Not Session("Role") = "Admin" Then
                txtMsg.Text = "你沒有瀏覽權限，限管理者使用！"
                txtMsg.Visible = True
                plAccount.Visible = False
            End If
        End If
    End Sub

    Protected Sub SqlDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles sqlAccount.Selecting
        '檢查是否具有Admin管理者權限，才允許瀏覽帳號資料
        If Session("Role") <> "Admin" Then
            e.Cancel = True
        End If
    End Sub

    Protected Sub dwmRole_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dwnRole.SelectedIndexChanged
        Dim dwnRole As DropDownList = CType(sender, DropDownList)
        If dwnRole.SelectedValue <> 0 Then
            dwnRole.ToolTip = dwnRole.SelectedItem.Text
        End If
    End Sub

    'CRUD權限勾選改變時，將權限更新到資料庫
    Protected Sub cbxPermission_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cbxPermission As CheckBoxList = CType(sender, CheckBoxList)
        Dim permission As String = getPermission(cbxPermission)

        Dim txtPermission As Label = CType(cbxPermission.Parent.FindControl("txtPermission"), Label)
        txtPermission.Text = permission
    End Sub

    'GridView資料繫結時，將CRUD資料還原到CheckBoxList控制項
    Protected Sub gvAccount_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvAccount.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim view As DataRowView = CType(e.Row.DataItem, DataRowView)
            If view IsNot Nothing Then
                '取得permission欄位資料
                Dim permission As String = view.Item(1)
                '取得CheckBoxList控制項
                Dim cbxPermission = CType(e.Row.Cells(1).FindControl("cbxPermission"), CheckBoxList)

                '根據CRUD還勾選顯示CheckBoxList控制項
                Dim y = permission.GetEnumerator()
                While y.MoveNext()
                    RestoreCheckBox(cbxPermission, y.Current)
                End While
            End If
        End If
    End Sub

    '依據CRUD還原勾選CheckBoxList的項目
    Protected Sub RestoreCheckBox(ByVal cbxPermission As CheckBoxList, ByVal p As Char)
        '計算CheckBoxList中有幾個項目
        Dim count As Integer = cbxPermission.Items.Count
        For i = 0 To count - 1
            If cbxPermission.Items(i).Value = p Then
                cbxPermission.Items(i).Selected = True
            End If
        Next
    End Sub

    '讀取CheckBoxList控制項的CRUD勾選
    Protected Function getPermission(ByVal cbxPermission As CheckBoxList) As String
        Dim permission As String = ""

        '判斷CheckBoxList項目是否被勾選
        For i = 0 To cbxPermission.Items.Count - 1
            Select Case cbxPermission.Items(i).Value
                Case "C"
                    If cbxPermission.Items(i).Selected Then
                        permission &= "C"
                    End If
                Case "R"
                    If cbxPermission.Items(i).Selected Then
                        permission &= "R"
                    End If
                Case "U"
                    If cbxPermission.Items(i).Selected Then
                        permission &= "U"
                    End If
                Case "D"
                    If cbxPermission.Items(i).Selected Then
                        permission &= "D"
                    End If
            End Select
        Next
        Return IIf(permission = "", " ", permission)
    End Function

    '新增帳號資料
    Protected Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        '寫入ADO.NET之前，先進行防呆檢查
        txtResult.Text = ""
        If CheckInput() Then
            Try
                sqlAccount.InsertParameters("ID").DefaultValue = txtID.Text
                sqlAccount.InsertParameters("Password").DefaultValue = txtPassword.Text
                sqlAccount.InsertParameters("Permission").DefaultValue = getPermission(cblPermission)
                sqlAccount.InsertParameters("Role").DefaultValue = dwnRole.SelectedItem.Text
                sqlAccount.InsertParameters("Active").DbType = DbType.Boolean
                sqlAccount.InsertParameters("Active").DefaultValue = True
                sqlAccount.Insert()
            Catch ex As Exception
                txtResult.Text = ex.ToString()
            End Try
        Else
            txtResult.Text = InputMsg
        End If

    End Sub

    Protected Function CheckInput() As Boolean
        'Input輸入合法性檢查,預設為True
        Dim status As Boolean = True
        If String.IsNullOrEmpty(txtID.Text) Then
            status = False
            InputMsg &= "＊帳號不得為零或空白<BR/>"
        End If

        If String.IsNullOrEmpty(txtPassword.Text) Then
            status = False
            InputMsg &= "＊密碼不得為零或空白<BR/>"
        End If

        If dwnRole.SelectedValue = 0 Then
            status = False
            InputMsg &= "＊必須選擇角色群組<BR/>"
        End If
        Return status
    End Function

    '顯示帳號建立成功或失敗訊息
    Protected Sub sqlAccount_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceStatusEventArgs) Handles sqlAccount.Inserted
        If e.AffectedRows > 0 Then
            '寫入成功，顯示成功之訊息
            txtResult.Text = "帳號建立成功！"
            txtID.Text = ""
            txtPassword.Text = ""
            cblPermission.ClearSelection()
            dwnRole.ClearSelection()
            'GridView必須再重新繫結，才能顯示新增的帳號
            gvAccount.DataBind()
        Else
            txtResult.Text = "帳號建立失敗！"
        End If
    End Sub

End Class
