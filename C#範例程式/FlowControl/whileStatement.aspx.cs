using System;

public partial class whileStatement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //動態加入DropDownList成員項目
        if (!IsPostBack)
        {
            dwnHeight.Items.Add("==請選擇身高==");
            int i = 160;

            //產生160~185 cm的身高項目
            while (i <= 185)
            {
                dwnHeight.Items.Add(i.ToString() + "cm");
                i++;
            }
        }
    }

    //顯示選擇的身高
    protected void dwnHeight_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dwnHeight.SelectedItem.Text != "==請選擇身高==")
        {
            txtMsg.Text = "您的身高為：" + dwnHeight.SelectedItem.Text;
        }
        else
        {
            txtMsg.Text = "";
        }
    }
}
