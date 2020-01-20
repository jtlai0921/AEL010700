Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Partial Class LoginAuthenticate
    Inherits System.Web.UI.Page

    '自訂Login控制項的驗證
    Protected Sub Login1_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles userLogin.Authenticate
        '將login控制項的登入帳號一律轉換為大寫
        userLogin.UserName = userLogin.UserName.ToUpper()

        '這段可自訂驗證的程序，若您已有帳號的資料庫，
        '可以在這裡用ADO.NET的方式連結自己的資料庫來驗證

        '取得Web.config中設定的資料庫連線字串
        Dim connString As String = WebConfigurationManager. _
        ConnectionStrings("ApplicationServices").ConnectionString
        Dim conn As New SqlConnection(connString)
        conn.Open()

        '或是您也可以直接將連線字串寫在程式之中
        'Dim connString As String = "data source=.;initial catalog=aspnet4db;user id=sa;password=test";

        '進行使用者帳號密碼與資料庫的比對
        Dim cmd As New SqlCommand("Select top 1 ID from UserAccount Where ID=@paramID and Password=@paramPwd", conn)
        cmd.Parameters.Add("@paramID", SqlDbType.NVarChar, 12).Value = userLogin.UserName
        cmd.Parameters.Add("@paramPwd", SqlDbType.NVarChar, 12).Value = userLogin.Password

        '若帳號及密碼符合則回傳一個Object型態（ID欄位）
        '故必須將Object轉型為字串
        Dim txtID As String = CType(cmd.ExecuteScalar(), String)

        cmd.Dispose()
        conn.Close()
        conn.Dispose()

        '判斷txtID是否為空值，非空值則為False，空值True
        If Not String.IsNullOrEmpty(txtID) Then
            e.Authenticated = True '驗證通過
        Else
            e.Authenticated = False '驗證失敗
        End If
    End Sub
End Class
