Imports System.Drawing
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Partial Class LoginAuthenticateCode
    Inherits System.Web.UI.Page

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        setLoginControl()
    End Sub

    '自訂Login控制項的驗證
    Protected Sub userLogin_Authenticate(ByVal sender As Object, ByVal e As AuthenticateEventArgs)
        '這段可自訂驗證的程序，若您已有帳號的資料庫，
        '可以在這裡用ADO.NET的方式連結自己的資料庫來驗證

        '取得Web.config中設定的資料庫連線字串
        Dim connString As String = WebConfigurationManager.ConnectionStrings("ApplicationServices").ConnectionString
        Dim conn As New SqlConnection(connString)
        conn.Open()

        '或是您也可以直接將連線字串寫在程式之中
        'Dim connString As String = "data source=.;initial catalog=aspnet4db;user id=sa;password=test";
        '取得Login控制項
        Dim userLogin As System.Web.UI.WebControls.Login = CType(sender, System.Web.UI.WebControls.Login)
        '將login控制項的登入帳號一律轉換為大寫
        userLogin.UserName = userLogin.UserName.ToUpper()

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

    '建立Login控制項，並設定相關屬性
    Protected Sub setLoginControl()
        '建立Login控制項實體
        Dim userLogin As New System.Web.UI.WebControls.Login()
        With userLogin
            '設定Loin的Title
            .TitleText = "3C會員"
            .TitleTextStyle.BackColor = Color.DarkRed
            .TitleTextStyle.ForeColor = Color.White
            .InstructionText = "使用者登入"
            .ToolTip = "請輸入您的會員帳號密碼"
            .Width = Unit.Pixel(200)

            '設定驗證成功後所要導向的網頁
            .DestinationPageUrl = "LoginMessage.aspx"
            '設定Login控制項外觀
            .BackColor = Color.LightYellow
            .BorderStyle = BorderStyle.Solid
            .BorderWidth = Unit.Pixel(1)
            .Font.Size = 8

            '設定使用者名稱及密碼文字
            .UserNameLabelText = "會員帳號:"
            .PasswordLabelText = "會員密碼:"
            '設定TextBox背景
            .TextBoxStyle.BackColor = Color.LightBlue
            '設定TextBox寬度
            .TextBoxStyle.Width = Unit.Pixel(80)

            '設定登入按鈕
            .LoginButtonText = "登入"
            .LoginButtonStyle.BackColor = Color.LightPink
            .LoginButtonStyle.Font.Size = 8

            '設定記憶屬性
            .RememberMeText = "請記憶我的身份"
        End With


        '建立自訂的驗證事件
        AddHandler userLogin.Authenticate, AddressOf userLogin_Authenticate
        '將Login控制項加入Web Form
        Page.FindControl("form1").Controls.Add(userLogin)
    End Sub
End Class
