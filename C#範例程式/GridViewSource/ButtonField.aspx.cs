using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ButtonField : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //建立GridView Button按鈕的RowCommand事件
    protected void gvProducts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //取得哪個Row的列索引
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow selectedRow = gvProducts.Rows[index];
        //取得該列Row的欄位產品名稱代號
        TableCell productName = selectedRow.Cells[1];
        //判斷使用者按下的是哪個種類的按鈕
        switch (e.CommandName)
        {
            case "Order":
                //將訂購的產品名稱加入ListBox
                lbOrders.Items.Add(productName.Text);
                break;
            case "CancelOrder":
                //將取消的產品名稱自ListBox移除
                if (lbOrders.Items.Count > 0)
                {
                    int i = 0;
                    while (i <= lbOrders.Items.Count - 1)
                    {
                        if (lbOrders.Items[i].Text == productName.Text)
                        {
                            lbOrders.Items.Remove(lbOrders.Items[i]);
                            break;
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
                break;
        }
    }
}
