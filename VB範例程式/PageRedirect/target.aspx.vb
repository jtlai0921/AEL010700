
Partial Class target
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '讀取來源網頁傳送之資料參數
        Dim Name As String = Request.QueryString("Name")
        Dim Tel As String = Request.QueryString("Tel")
        Dim City As String = Request.QueryString("City")
        '顯示資料
        Response.Write(String.Format("<H2>您的基本資料如下：</H2>姓名：{0}<BR/>電話：{1}<BR/>居住縣市：{2}", Name, Tel, City))
    End Sub
End Class
