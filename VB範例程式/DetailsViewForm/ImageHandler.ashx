<%@ WebHandler Language="VB" Class="ImageHandler" %>
Imports System
Imports System.Web
Imports System.IO
Imports System.Configuration

Public Class ImageHandler : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        '取得員工代號
        Dim EmployeeID As String = context.Request.QueryString("EmployeeID")
        '透過ReadImage類別的GetImage()方法取得SQL Server中圖片資料
        '其圖片儲存在MemoryStream之中回傳
        Dim ms As MemoryStream = New ReadImage().GetImage(EmployeeID)
        
        If (ms IsNot Nothing) Then
            '取得影像MemoryStream大小
            Dim bufferSize As Integer = CType(ms.Length, Integer)
            '建立 buffer
            Dim buffer(bufferSize) As Byte
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