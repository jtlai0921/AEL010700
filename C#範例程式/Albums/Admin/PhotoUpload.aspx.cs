using System;
using System.Web;
using System.Web.UI.WebControls;

public partial class PhotoUpload : System.Web.UI.Page
{
    string UploadedMsg = "";

    //圖片上傳
    protected void btnUpload_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        txtMsg.Text = "";
        try
        {
            Upload(FileUpload1);
            Upload(FileUpload2);
            Upload(FileUpload3);
            Upload(FileUpload4);
            Upload(FileUpload5);
            Upload(FileUpload6);
            Upload(FileUpload7);
            Upload(FileUpload8);
            Upload(FileUpload9);
            Upload(FileUpload10);
            
            //檢查至少必須指定一個上載檔案
            if (hasFile())
            {
                txtMsg.Text = "完成檔案上載如下：<BR>" + UploadedMsg;
            }
            else
            {
                txtMsg.Text = "*必須至少指定一個檔案！";
            }

        }
        catch (Exception ex)
        {
            txtMsg.Text = ex.Message;
        }
        finally
        {
            UploadedMsg = null;
        }
    }

    //上載檔案方法
    private void Upload(FileUpload myFileUpload)
    {
        //是否允許上載
        bool fileAllow = false;
        //設定允許上載的延伸檔名類型
        string[] allowExtensions = { ".jpg", ".gif" ,".png" };

        //取得網站根目錄路徑
        string path = HttpContext.Current.Request.MapPath("~/Photos/");
        //檢查是否有檔案
        if (myFileUpload.HasFile)
        {
            //取得上載檔案之延伸檔名，並轉換成小寫字母
            string fileExtension = System.IO.Path.GetExtension(myFileUpload.FileName).ToLower();
            //檢查延伸檔名是否符合限定類型
            for (int i = 0; i < allowExtensions.Length; i++)
            {
                if (fileExtension == allowExtensions[i])
                {
                    fileAllow = true;
                }
            }

            if (fileAllow)
            {
                try
                {
                    //儲存檔案到磁碟，檔案名稱須做唯一性處理
                    //指定相片的GUID檔名
                    Guid PhotoGuid = Guid.NewGuid();
                    myFileUpload.SaveAs(path + PhotoGuid.ToString() + fileExtension);
                    UploadedMsg += "<li>" + myFileUpload.PostedFile.FileName + "</li>";
                    //Insert寫入到PhotoData資料表
                    sqlPhotoData.InsertParameters["paramGUID"].DefaultValue = PhotoGuid.ToString() + fileExtension;
                    sqlPhotoData.InsertParameters["paramFileName"].DefaultValue = myFileUpload.FileName;
                    sqlPhotoData.InsertParameters["paramUploadTime"].DefaultValue = DateTime.Now.ToLongTimeString();
                    sqlPhotoData.Insert();
                }
                catch (Exception ex)
                {
                    txtMsg.Text += ex.Message;
                }
            }
            else
            {
                UploadedMsg += "<li>不允許上載：" + myFileUpload.PostedFile.FileName + "</li>";
            }
        }
    }

    //檢查是否有檔案，若十個FileUpload控制項無指定檔案則回傳false
    private bool hasFile()
    {
        //status為檢查FileUpload是否含有檔案，預設為false，若有檔案則為true
        bool status = false;

        status = FileUpload1.HasFile || FileUpload2.HasFile || FileUpload3.HasFile || FileUpload4.HasFile || FileUpload5.HasFile || FileUpload6.HasFile || FileUpload7.HasFile || FileUpload8.HasFile || FileUpload9.HasFile || FileUpload10.HasFile;

        /*以上寫法等同下面寫法
        status = FileUpload1.HasFile;
        status = FileUpload2.HasFile;
        status = FileUpload3.HasFile;
        status = FileUpload4.HasFile;
        status = FileUpload5.HasFile;
        status = FileUpload6.HasFile;
        status = FileUpload7.HasFile;
        status = FileUpload8.HasFile;
        status = FileUpload9.HasFile;
        status = FileUpload10.HasFile;
         * */
        return status;
    }

    //登出
    protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
    {
        Session["AllowAlbumID"] = null;
        Response.Redirect("~/Albums.aspx");
    }
}
