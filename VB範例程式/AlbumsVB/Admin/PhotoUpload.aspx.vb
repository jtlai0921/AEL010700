
Partial Class Admin_PhotoUpload
    Inherits System.Web.UI.Page
    Dim UploadedMsg As String = ""

    '圖片上傳
    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnUpload.Click
        txtMsg.Text = ""

        Try
            Upload(FileUpload1)
            Upload(FileUpload2)
            Upload(FileUpload3)
            Upload(FileUpload4)
            Upload(FileUpload5)
            Upload(FileUpload6)
            Upload(FileUpload7)
            Upload(FileUpload8)
            Upload(FileUpload9)
            Upload(FileUpload10)

            '檢查至少必須指定一個上載檔案
            If hasFile() Then
                txtMsg.Text = "完成檔案上載如下：<BR>" & UploadedMsg
            Else
                txtMsg.Text = "*必須至少指定一個檔案！"
            End If
        Catch ex As Exception
            txtMsg.Text = ex.Message
        Finally
            UploadedMsg = Nothing
        End Try
    End Sub

    '上載檔案方法
    Protected Sub Upload(ByVal myFileUpload As FileUpload)
        '是否允許上載
        Dim fileAllow As Boolean = False
        '設定允許上載的延伸檔名類型
        Dim allowExtensions() As String = {".jpg", ".gif", ".png"}

        '取得網站根目錄路徑
        Dim path As String = HttpContext.Current.Request.MapPath("~/Photos/")
        '檢查是否有檔案
        If myFileUpload.HasFile Then
            '取得上載檔案之延伸檔名，並轉換成小寫字母
            Dim fileExtension As String = System.IO.Path.GetExtension(myFileUpload.FileName).ToLower()

            '檢查延伸檔名是否符合限定類型
            For i = 0 To allowExtensions.Length - 1
                If fileExtension = allowExtensions(i) Then
                    fileAllow = True
                End If
            Next

            '允許上載
            If fileAllow Then
                Try
                    '儲存檔案到磁碟，檔案名稱須做唯一性處理
                    '指定相片的GUID檔名
                    Dim PhotoGuid As Guid = Guid.NewGuid()
                    myFileUpload.SaveAs(path & PhotoGuid.ToString() & fileExtension)
                    UploadedMsg &= "<li>" & myFileUpload.PostedFile.FileName & "</li>"
                    'Insert寫入到PhotoData資料表
                    sqlPhotoData.InsertParameters("paramGUID").DefaultValue = PhotoGuid.ToString() & fileExtension
                    sqlPhotoData.InsertParameters("paramFileName").DefaultValue = myFileUpload.FileName
                    sqlPhotoData.InsertParameters("paramUploadTime").DefaultValue = DateTime.Now.ToLongTimeString()
                    sqlPhotoData.Insert()
                Catch ex As Exception
                    txtMsg.Text &= ex.Message
                End Try
            Else
                UploadedMsg &= "<li>不允許上載：" & myFileUpload.PostedFile.FileName & "</li>"
            End If
        End If
    End Sub

    Function hasFile() As Boolean
        'status為檢查FileUpload是否含有檔案，預設為False，若有檔案則為True
        Dim status As Boolean = False
        status = FileUpload1.HasFile Or FileUpload2.HasFile Or FileUpload3.HasFile Or FileUpload4.HasFile Or FileUpload5.HasFile Or FileUpload6.HasFile Or FileUpload7.HasFile Or FileUpload8.HasFile Or FileUpload9.HasFile Or FileUpload10.HasFile
        '以上寫法等同下面寫法
        'status = FileUpload1.HasFile
        'status = FileUpload2.HasFile
        'status = FileUpload3.HasFile
        'status = FileUpload4.HasFile
        'status = FileUpload5.HasFile
        'status = FileUpload6.HasFile
        'status = FileUpload7.HasFile
        'status = FileUpload8.HasFile
        'status = FileUpload9.HasFile
        'status = FileUpload10.HasFile
        Return status
    End Function

    '登出
    Protected Sub LoginStatus1_LoggedOut(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginStatus1.LoggedOut
        Session("AllowAlbumID") = Nothing
        Response.Redirect("~/Albums.aspx")
    End Sub
End Class
