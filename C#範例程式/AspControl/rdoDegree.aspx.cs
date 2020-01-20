using System;

public partial class rdoDegree : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    //顯示最高學歷
    protected void btnSumbit_Click(object sender, EventArgs e)
    {
        //判斷選擇的RadioButton控制項
        if (rdoSenior.Checked)
        {
            txtMsg.Text = "你的最高學歷為：" + rdoSenior.Text;
        }
        else if (rdoUniversity.Checked)
        {
            txtMsg.Text = "你的最高學歷為：" + rdoUniversity.Text;
        }
        else if (rdoMaster.Checked)
        {
            txtMsg.Text = "你的最高學歷為：" + rdoMaster.Text;
        }
        else if (rdoDoctor.Checked)
        {
            txtMsg.Text = "你的最高學歷為：" + rdoDoctor.Text;
        }
        else
        {
            txtMsg.Text = "請至少選擇一個學歷選項！";
        }
    }
}
