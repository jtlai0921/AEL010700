<%@ WebHandler Language="VB" Class="ImageHandler" %>
Imports System
Imports System.Web
Imports System.IO
Imports System.Web.Configuration
Imports System.Data

Public Class ImageHandler : Implements IHttpHandler
    '取得資料庫連線設定
    Shared connString As ConnectionStringSettings = WebConfigurationManager.ConnectionStrings("NorthwindConnectionString1")
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim ms As MemoryStream = Nothing
        Try
            '取得員工代號
            Dim EmployeeID As String = context.Request.QueryString("EmployeeID")
            '透過ReadImage類別的GetImage()方法取得SQL Server中圖片資料
            '建立Sql命令
            Dim strSQL As String = "Select Photo from Employees where EmployeeID=@paramEmployeeID"
            '建立SqlDataSource
            Dim sqldsPhoto As New SqlDataSource(connString.ConnectionString, strSQL)
            sqldsPhoto.SelectParameters.Add("paramEmployeeID", TypeCode.Int32, EmployeeID)
            '透過SqlDataSource進行查詢
            Dim dv As DataView = CType(sqldsPhoto.Select(DataSourceSelectArguments.Empty), DataView)
            '回傳DataView第一個Row的Photo欄位資料
            Dim PhotoImage() As Byte = CType(dv(0)("Photo"), Byte())
            ms = New MemoryStream(PhotoImage, 0, PhotoImage.Length)
        Catch ex As Exception

        End Try
        
        If ms IsNot Nothing Then
            '取得影像MemoryStream大小
            Dim bufferSize As Integer = CType(ms.Length, Integer)
            '建立 buffer陣列
            Dim buffer() As Byte = New Byte(bufferSize) {}
            '呼叫MemoryStream.Read，自MemoryStream 讀取至buffer，並傳回count
            Dim countSize As Integer = ms.Read(buffer, 0, bufferSize)
            '傳回影像buffer
            context.Response.OutputStream.Write(buffer, 0, countSize)
        End If
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
End Class