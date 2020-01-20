using System;

public partial class cbxControl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //顯示使用者興趣
    protected void btnOK_Click(object sender, EventArgs e)
    {
        txtMsg.Text = "";
        int counter = 1;
        for (int i = 0; i < cbxHabits.Items.Count; i++)
        {
            //判斷CheckBoxList項目是否被選取
            if (cbxHabits.Items[i].Selected == true)
            {
                //若被選取，則加入興趣文字列表
                txtMsg.Text += counter + "." + cbxHabits.Items[i].Text + "<BR/>";
                counter++;
            }
        }
    }
}
