using System;

public partial class DoWhile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        txtMsg.Text = "";
        int i;  //起始值
        //判斷TextBox輸入是否為阿拉伯數字
        if (int.TryParse(txtStart.Text, out i))
        {
            //執行迴圈
            do
            {
                txtMsg.Text += i + "\n";
                i++;
            } while (i <= 100);
        }
        else
        {
            Response.Write("<script>alert('限輸入阿拉伯數字!')</script>");
        }
    }
}
