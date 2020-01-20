Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class ReadImage
    '���o��Ʈw�s�u�]�w
    Shared connString As ConnectionStringSettings = WebConfigurationManager.ConnectionStrings("NorthwindConnectionString")

    '�qbyte 0�}�l�A�S���첾78bytes
    Public Function GetImage(ByVal EmployeeID As String) As MemoryStream
        '�إ�Sql�R�O
        Dim strSQL As String = "Select Photo from Employees where EmployeeID=@paramEmployeeID"
        '�إ�SqlDataSource
        Dim sqldsPhoto As New SqlDataSource(connString.ConnectionString, strSQL)
        sqldsPhoto.SelectParameters.Add("paramEmployeeID", TypeCode.Int32, EmployeeID)

        Try
            '�z�LSqlDataSource�i��d��
            Dim dv As DataView = CType(sqldsPhoto.Select(DataSourceSelectArguments.Empty), DataView)
            '�^��DataView�Ĥ@��Row��Photo�����
            Dim PhotoImage As Byte() = CType(dv(0)("Photo"), Byte())
            '�^��MemoryStream
            Return New MemoryStream(PhotoImage, 0, PhotoImage.Length)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    '�첾78bytes
    Public Function GetImageOffset(ByVal EmployeeID As String) As MemoryStream
        '�إ�Sql�R�O
        Dim strSQL As String = "Select Photo from Employees where EmployeeID=@paramEmployeeID"
        '�إ�SqlDataSource
        Dim sqldsPhoto As New SqlDataSource(connString.ConnectionString, strSQL)
        sqldsPhoto.SelectParameters.Add("paramEmployeeID", TypeCode.Int32, EmployeeID)

        Try
            '�z�LSqlDataSource�i��d��
            Dim dv As DataView = CType(sqldsPhoto.Select(DataSourceSelectArguments.Empty), DataView)
            '�^��DataView�Ĥ@��Row��Photo�����
            Dim PhotoImage As Byte() = CType(dv(0)("Photo"), Byte())
            '�^��MemoryStream
            Return New MemoryStream(PhotoImage, 78, PhotoImage.Length - 78)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
