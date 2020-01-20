using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

public partial class LinqFiles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRead_Click(object sender, EventArgs e)
    {
        //取得虛擬目錄路徑
        string path = HttpContext.Current.Request.MapPath("~/");

        IEnumerable<System.IO.FileInfo> fileList = GetFiles(path);

        //以LINQ查詢延伸檔名為.aspx的檔案名稱
        var files = from file in fileList
                    where file.Extension == ".aspx"
                    select file.FullName;

        int i = 0;
        string result = "";
        foreach (var f in files)
        {
            result += String.Format("{0:00}.{1}<BR/>", i, f);
            i++;
        }

        Label txtMsg = new Label();
        txtMsg.Text = result;
        form1.Controls.Add(txtMsg);
    }

    //讀取檔案
    static IEnumerable<System.IO.FileInfo> GetFiles(string path)
    {
        if (!System.IO.Directory.Exists(path))
        {
            throw new System.IO.DirectoryNotFoundException();
        }

        string[] fileNames = null;
        List<System.IO.FileInfo> files = new List<System.IO.FileInfo>();

        fileNames = System.IO.Directory.GetFiles(path, "*.*", System.IO.SearchOption.AllDirectories);            
        foreach (string name in fileNames)
        {
            files.Add(new System.IO.FileInfo(name));
        }
        return files;
     }
}
