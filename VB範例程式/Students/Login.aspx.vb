Imports System.Web.Configuration
Imports System.Data
Imports System.Data.SqlClient

Partial Class Login
    Inherits System.Web.UI.Page

    '取得Web.config中的資料庫連線字串設定
    Shared connString As String = WebConfigurationManager.ConnectionStrings("SchoolConnectionString").ConnectionString

    Dim userID As String = Nothing  '帳號
    Dim activeStatus As Boolean = Nothing   '帳號啓用狀態

    '進行帳號密碼驗證比對
    Protected Sub userLogin_Authenticate(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles userLogin.Authenticate
        '將login控制項的登入帳號一律轉換為大寫
        userLogin.UserName = userLogin.UserName.ToUpper()

        Dim conn As New SqlConnection(connString)
        conn.Open()

        '進行使用者帳號密碼與資料庫的比對
        Dim cmd As New SqlCommand("Select top 1 ID,Permission,Role,Active from UserAccount Where ID=@paramID and Password=@paramPwd", conn)
        cmd.Parameters.Add("@paramID", SqlDbType.NVarChar, 12).Value = userLogin.UserName
        cmd.Parameters.Add("@paramPwd", SqlDbType.NVarChar, 12).Value = userLogin.Password
        Dim dr As SqlDataReader

        Try
            dr = cmd.ExecuteReader()

            '如果成功查詢帳號資料
            If dr.HasRows Then
                dr.Read()
                userID = dr(0)
                '設定Permission及Role的狀態資料
                Session("Permission") = dr(1).ToString().Trim() 'CRUD權限
                Session("Role") = dr(2) '角色群組
                activeStatus = dr(3)
            End If
        Finally
            cmd.Dispose()
            conn.Close()
            conn.Dispose()
        End Try

        '判斷帳號密碼比對結果是否有效
        If Not String.IsNullOrEmpty(userID) Then
            If activeStatus = True Then
                e.Authenticated = True  '驗證通過
            Else
                e.Authenticated = False '驗證失敗
                If activeStatus = False Then
                    userLogin.FailureText = "此帳號被停用！"
                End If
            End If
        Else
            e.Authenticated = False '驗證失敗
            userLogin.FailureText = "帳號或密碼不符！"
        End If
    End Sub

    '設定Login控制項焦點在UserName的TextBox上
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.SetFocus("UserName")
    End Sub
End Class
