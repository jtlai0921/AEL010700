using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Range : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //設定存款餘額為1百萬元
            txtDeposit.Text = "1000000";

            //設定RangeValidator控制項的最小與最大值範圍
            //限定最小提款金額為100元
            RangeValidator1.MinimumValue = "1";
            //設定最大提款金額上限為存款總額
            RangeValidator1.MaximumValue = txtDeposit.Text;
            RangeValidator1.ErrorMessage = string.Format("*轉帳金額必須介於{0}到{1}元之間，且不得有英文字或小數點！", RangeValidator1.MinimumValue, RangeValidator1.MaximumValue);
        }
    }

    //轉帳之處理程序
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //總存款金額
        int deposit = Convert.ToInt32(txtDeposit.Text);
        int withDraw=new int(); //提款金額
        bool result=new bool(); //型別轉換是否通過

        if (!string.IsNullOrEmpty(txtWithDraw.Text))
        {
            //判斷提款金額是否通過RangeValidator控制項的驗證
            //若通過驗證，Page.IsValid為true，否則為false
            if (Page.IsValid)
            {
                result = int.TryParse(txtWithDraw.Text, out withDraw);
                if (result)
                {
                    txtMsg.Text = string.Format("您的轉帳金額為{0}元，存款餘額為{1}元。", withDraw, deposit - withDraw);
                }
            }
            else
            {
                txtMsg.Text = "";
            }
        }
        else
        {
            txtMsg.Text = "轉帳金額輸入不得為空白！";
        }
    }
}
