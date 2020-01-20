using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PhotoUpload : System.Web.UI.Page
{
    string UploadedMsg = "";    //上傳完成後之訊息

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["Permission"].ToString().Contains("R"))
        {
            Response.Redirect("Message.aspx?Reason=必須具備讀取權限");
        }
    }

    //圖片上傳
    protected void btnUpload_Click(object sender, ImageClickEventArgs e)
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
            UploadedMsg = "";
        }

    }

    //上載檔案方法
    protected void Upload(FileUpload myFileUpload)
    {
        //是否允許上載
        bool fileAllow = false;
        string[] allowExtensions = { ".jpg", ".gif", ".png" };

        //取得網站根目錄路徑
        string path = HttpContext.Current.Request.MapPath("~/Photos/");
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

            //允許上載
            if (fileAllow)
            {
                try
                {
                    //儲存照片檔案到磁碟
                    myFileUpload.SaveAs(path + myFileUpload.FileName);
                    UploadedMsg += "<li>" + myFileUpload.PostedFile.FileName + "</li>";

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

    //檢查FileUpload是否含有檔案
    protected bool hasFile()
    {
        //status為檢查FileUpload是否含有檔案，預設為false，若有檔案則為true
        bool status = false;
        status = FileUpload1.HasFile || FileUpload2.HasFile || FileUpload3.HasFile || FileUpload4.HasFile || FileUpload5.HasFile || FileUpload6.HasFile || FileUpload7.HasFile || FileUpload8.HasFile || FileUpload9.HasFile || FileUpload10.HasFile;
        //以上寫法等同下面寫法
        //status = FileUpload1.HasFile;
        //status = FileUpload2.HasFile;
        //status = FileUpload3.HasFile;
        //status = FileUpload4.HasFile;
        //status = FileUpload5.HasFile;
        //status = FileUpload6.HasFile;
        //status = FileUpload7.HasFile;
        //status = FileUpload8.HasFile;
        //status = FileUpload9.HasFile;
        //status = FileUpload10.HasFile;

        return status;
    }
}