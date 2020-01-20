using System;

public partial class rdoBloodType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //顯示使用者血型
    protected void rdoBlood_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtMsg.Text = "您的血型為：" + rdoBlood.SelectedItem.Text;
    }
}
