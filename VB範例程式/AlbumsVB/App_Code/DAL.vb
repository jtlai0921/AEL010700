Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient


Public Class DAL
    Inherits DalBase
    '計算相簿數量
    Public Function countAlbums() As Integer
        Dim albums As Integer = 0 '相本數
        Dim dr As SqlDataReader = getDataReader("Select count(*) from AlbumData")
        While dr.Read()
            albums = CInt(dr(0))
        End While

        '閉關DataReader及Connection
        dr.Dispose()
        publicConnection.Close()

        Return albums
    End Function

    '以AlbumID代號查詢相本名稱
    Public Function queryAlbumName(ByVal albumID As String) As String
        Dim albumName As String = Nothing

        If Not String.IsNullOrEmpty(albumID) Then
            albumID = HttpUtility.HtmlEncode(albumID)
            Dim strSql As String = String.Format("Select top 1 AlbumName from AlbumData where AlbumID={0}", albumID)
            Dim dr As SqlDataReader = getDataReader(strSql) '建立SqlDataReader

            While dr.Read()
                albumName = dr(0).ToString()
            End While

            '閉關DataReader及Connection
            dr.Dispose()
            publicConnection.Close()
        End If

        Return albumName
    End Function

    '以AlbumID代號查詢相本名稱，以SqlParameter建立安全性數查詢
    Public Function queryAlbumNameParam(ByVal albumID As String) As String
        Dim albumName As String = Nothing

        If Not String.IsNullOrEmpty(albumID) Then
            albumID = HttpUtility.HtmlEncode(albumID)
            Dim strSql As String = "Select top 1 AlbumName from AlbumData where AlbumID=@paramAlbumID"
            Dim cmd As SqlCommand = getSqlCommand(strSql) '建立SqlCommand

            '設定SqlParameter，建立安全的參數
            Dim parameter As New SqlParameter()
            With parameter
                .ParameterName = "@paramAlbumID"
                .SqlDbType = SqlDbType.Int
                .Value = Convert.ToInt16(albumID)
                .Direction = ParameterDirection.Input
                cmd.Parameters.Add(parameter)
            End With

            Dim dr As SqlDataReader = cmd.ExecuteReader()

            While dr.Read()
                albumName = dr(0).ToString()
            End While

            '閉關DataReader及Connection
            dr.Close()
            dr.Dispose()
            cmd.Dispose()
            publicConnection.Close()
        End If

        Return albumName
    End Function

    '計算某相本下所有相片數，以AlbumID為計算基準
    Public Function countPhotos(ByVal albumID As String) As Integer
        Dim photos As Integer = 0
        If Not String.IsNullOrEmpty(albumID) Then
            albumID = HttpUtility.HtmlEncode(albumID)
            Dim strSql As String = String.Format("Select count(*) from PhotoData where AlbumID={0}", albumID)
            Dim dr As SqlDataReader = getDataReader(strSql)

            While dr.Read()
                photos = Convert.ToInt16(dr(0))
            End While

            '閉關DataReader及Connection
            dr.Dispose()
            publicConnection.Close()
        End If

        Return photos
    End Function

    '以PhotoGUID查詢相本之albumID
    Public Function queryAlbumID(ByVal photoGUID As String) As String
        Dim albumID As String = "-1"
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing

        Dim strSql As String = ""

        If Not String.IsNullOrEmpty(photoGUID) Then
            photoGUID = HttpUtility.HtmlEncode(photoGUID)
            '以photoGUID查詢PhotoData資料表中的albumID
            strSql = String.Format("SELECT Top 1 AlbumID FROM PhotoData Where PhotoGUID='{0}'", photoGUID)
            cmd = getSqlCommand(strSql)

            Try
                dr = cmd.ExecuteReader()
                If dr.Read Then
                    albumID = dr(0).ToString() '取得相簿AlbumID
                End If
            Finally
                dr.Close()
                dr.Dispose()
                cmd.Dispose()
                publicConnection.Close()
            End Try
        End If

        Return albumID
    End Function

    '根據AlbumID查詢相簿是否受保護
    Public Function queryAlbumProtection(ByVal photoGUID As String) As Boolean
        Dim protection As Boolean = True
        Dim albumID As Integer = -1
        Dim cmd As SqlCommand = Nothing
        Dim dr As SqlDataReader = Nothing
        Dim strSql As String = ""

        If Not String.IsNullOrEmpty(photoGUID) Then
            photoGUID = HttpUtility.HtmlEncode(photoGUID)
            '1.先以photoGUID查詢PhotoData資料表中的albumID
            strSql = String.Format("SELECT Top 1 AlbumID FROM PhotoData Where PhotoGUID='{0}'", photoGUID)
            cmd = getSqlCommand(strSql)

            Try
                dr = cmd.ExecuteReader()
                If dr.Read() Then
                    albumID = Convert.ToInt16(dr(0)) '取得相簿AlbumID
                End If
            Catch

            End Try

            '2.再以albumID查詢AlbumData中相簿是否有保護
            If albumID <> -1 Then
                strSql = String.Format("SELECT Top 1 AlbumID FROM AlbumData Where AlbumID={0} and (Protection='False' or Protection is null)", albumID)
                cmd.CommandText = strSql
                dr.Close()
                dr = cmd.ExecuteReader()
            End If

            If Not dr.Read() Then
                '如果沒有讀到任何資料，則表示相簿是有保護的
                protection = True
            End If
        End If

        dr.Close()
        dr.Dispose()
        cmd.Dispose()
        publicConnection.Close()
        publicConnection.Dispose()

        Return protection
    End Function

    Public Sub updateDefaultPic(ByVal albumID As String, ByVal fileName As String)
        If (Not String.IsNullOrEmpty(albumID) And Not String.IsNullOrEmpty(fileName)) Then
            albumID = HttpUtility.HtmlEncode(albumID)
            fileName = HttpUtility.HtmlEncode(fileName)
            Dim strSql As String = String.Format("Update AlbumData set DefaultPhotoGUID='{0}' where AlbumID={1}", fileName, albumID)
            Dim cmd As SqlCommand = getSqlCommand(strSql)

            Try
                cmd.ExecuteNonQuery()
            Finally
                cmd.Dispose()
                publicConnection.Close()
                publicConnection.Dispose()
            End Try
        End If
    End Sub
End Class

