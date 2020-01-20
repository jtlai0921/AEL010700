using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class StringBasic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //進行字串處理作業
    protected void btnGo_Click(object sender, EventArgs e)
    {
        //判斷TextBox是否有輸入文字
        if (!string.IsNullOrEmpty(txtInput.Text))
        {
            //將int以ToString()轉換成String字串
            txtLength.Text = txtInput.Text.Length.ToString();
            //以Substring取得輸入字串位置2~5之子字串
            if (txtInput.Text.Length > 5)
            {
                txtSubString.Text = txtInput.Text.Substring(2, 5);
            }
            //將輸入字串以ToUpper轉換成大寫
            txtToUpper.Text = txtInput.Text.ToUpper();
            //將輸入字串以ToLower轉換成大寫
            txtToLower.Text = txtInput.Text.ToLower();
            //以IndexOf尋找字串中特定文字，並回傳起值位置
            txtIndexOf.Text = txtInput.Text.IndexOf("Dot").ToString();
            //以Trim將字串前後空白去除
            txtTrim.Text = txtInput.Text.Trim();
        }
    }
}
