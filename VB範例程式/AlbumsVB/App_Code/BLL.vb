Imports Microsoft.VisualBasic

Public Class BLL
    '取得所有Album相本數
    Public Function getAlbums() As Integer
        '呼叫資料存取層的countAlbums
        Dim myDal As New DAL()
        Return myDal.countAlbums()
    End Function

    '傳入AlbumID代號，回傳相本名稱
    Public Function getAlbumName(ByVal albumID As String) As String
        Dim albumName As String = ""

        If Not String.IsNullOrEmpty(albumID) Then
            albumName = New DAL().queryAlbumName(albumID)
        End If

        Return albumName
    End Function

    '傳入photoGUID代號，回傳相本AlbumID
    Public Function getAlbumID(ByVal photoGUID As String) As String
        Dim albumID As String = "-1"

        If Not String.IsNullOrEmpty(photoGUID) Then
            albumID = New DAL().queryAlbumID(photoGUID)
        End If

        Return albumID
    End Function

    '計算某相本下所有相片數，以AlbumID為計算基準
    Public Function getPhotos(ByVal albumID As String) As Integer
        Dim myDal As New DAL()
        Return myDal.countPhotos(albumID)
    End Function

    '根據PhotoGUID檢查相簿是否受保護,true為有保護
    Public Function checkAlbumProtection(ByVal photoGUID As String) As Boolean
        Dim protection As Boolean = True

        If Not String.IsNullOrEmpty(photoGUID) Then
            '回傳值若為True則為有保護，若為False則無保護
            protection = New DAL().queryAlbumProtection(photoGUID)
        End If

        Return protection
    End Function

    '儲存相簿之預設名稱
    Public Sub saveDefaultPic(ByVal albumID As String, ByVal fileName As String)
        Dim myDal As New DAL()
        myDal.updateDefaultPic(albumID, fileName)
    End Sub

End Class
