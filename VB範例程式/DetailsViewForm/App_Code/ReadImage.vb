Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class ReadImage
    '取得資料庫連線設定
    Shared connString As ConnectionStringSettings = WebConfigurationManager.ConnectionStrings("NorthwindConnectionString")

    '從byte 0開始，沒有位移78bytes
    Public Function GetImage(ByVal EmployeeID As String) As MemoryStream
        '建立Sql命令
        Dim strSQL As String = "Select Photo from Employees where EmployeeID=@paramEmployeeID"
        '建立SqlDataSource
        Dim sqldsPhoto As New SqlDataSource(connString.ConnectionString, strSQL)
        sqldsPhoto.SelectParameters.Add("paramEmployeeID", TypeCode.Int32, EmployeeID)

        Try
            '透過SqlDataSource進行查詢
            Dim dv As DataView = CType(sqldsPhoto.Select(DataSourceSelectArguments.Empty), DataView)
            '回傳DataView第一個Row的Photo欄位資料
            Dim PhotoImage As Byte() = CType(dv(0)("Photo"), Byte())
            '回傳MemoryStream
            Return New MemoryStream(PhotoImage, 0, PhotoImage.Length)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    '位移78bytes
    Public Function GetImageOffset(ByVal EmployeeID As String) As MemoryStream
        '建立Sql命令
        Dim strSQL As String = "Select Photo from Employees where EmployeeID=@paramEmployeeID"
        '建立SqlDataSource
        Dim sqldsPhoto As New SqlDataSource(connString.ConnectionString, strSQL)
        sqldsPhoto.SelectParameters.Add("paramEmployeeID", TypeCode.Int32, EmployeeID)

        Try
            '透過SqlDataSource進行查詢
            Dim dv As DataView = CType(sqldsPhoto.Select(DataSourceSelectArguments.Empty), DataView)
            '回傳DataView第一個Row的Photo欄位資料
            Dim PhotoImage As Byte() = CType(dv(0)("Photo"), Byte())
            '回傳MemoryStream
            Return New MemoryStream(PhotoImage, 78, PhotoImage.Length - 78)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
