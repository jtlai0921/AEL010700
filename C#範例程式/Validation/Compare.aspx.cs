using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Compare : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtTotalBonus.Text = "10000";
        }
    }

    //將紅利兌換成現金
    protected void btnConvert_Click(object sender, EventArgs e)
    {
        int bonus=0;  //兌換之紅利點利
        int? cash;  //現金
        bool? result;    //將string轉換為int的結果，成功為true,失敗為false
        string message="紅利{0}點兌換成現金為{1}元，剩餘之紅利點數為{2}點。";

        if (!string.IsNullOrEmpty(txtBonus.Text))
        {
            if (Page.IsValid)
            {
                //將紅利由字串轉換為int型態
                result = int.TryParse(txtBonus.Text, out bonus);
                //20點紅利兌換成1元現金
                cash = Math.Abs(Convert.ToInt32(txtBonus.Text) / 20);
                txtMsg.Text = string.Format(message, bonus, cash, Convert.ToInt16(txtTotalBonus.Text) - cash * 20);
                txtMsg.Visible = true;
            }
            else
            {
                txtMsg.Text = "";
            }
        }
        else
        {
            txtMsg.Text = "紅利輸入不得為空白！";
        }
    }
}
