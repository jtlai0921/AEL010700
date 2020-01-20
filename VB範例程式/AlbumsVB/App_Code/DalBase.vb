Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class DalBase
    '取得Web.config中的AlbumDBConnectionString1連線字串設定
    Public Shared connString As String = WebConfigurationManager.ConnectionStrings("AlbumDBConnectionString1").ConnectionString
    Public publicConnection As SqlConnection = Nothing

    Public Sub New()
        'DAL初始化時，則建立公用的SqlConnection連線
        publicConnection = getConnection()
    End Sub

    Public Function getConnection() As SqlConnection
        '取得對資料庫的SqlConnection物件
        Dim connection As New SqlConnection()
        connection.ConnectionString = connString
        connection.Open()

        Return connection
    End Function

    '取得設定好連線及命令的SqlDataReader
    Protected Function getDataReader(ByVal CommandText As String) As SqlDataReader
        Dim connection As SqlConnection = getConnection()
        Dim cmd As SqlCommand = New SqlCommand(CommandText, publicConnection)

        Return cmd.ExecuteReader()
    End Function

    '取得設定好連線的SqlCommand

    Protected Function getSqlCommand(ByVal CommandText As String) As SqlCommand
        Dim cmd As New SqlCommand(CommandText, publicConnection)
        Return cmd
    End Function
End Class
