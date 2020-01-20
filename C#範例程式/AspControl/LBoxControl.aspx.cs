using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LBoxControl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //加入ListBox之項目
            lbxSource.Items.Add("CPU處理器");
            lbxSource.Items.Add("主機板");
            lbxSource.Items.Add("記憶體");
            lbxSource.Items.Add("顯示卡");
            lbxSource.Items.Add("硬碟");
            lbxSource.Items.Add("DVD燒錄器");
            lbxSource.Items.Add("滑鼠");
            lbxSource.Items.Add("LCD夜晶螢幕");
            lbxSource.Items.Add("電源延長線插座");
            lbxSource.Items.Add("散熱風扇");
            lbxSource.Items.Add("喇叭");
            lbxSource.Items.Add("投影機");

            /* 同時指定Text與Value之寫法
            lbxSource.Items.Add(new ListItem("CPU處理器", "0"));
            lbxSource.Items.Add(new ListItem("主機板", "1"));
            lbxSource.Items.Add(new ListItem("記憶體", "2"));
            lbxSource.Items.Add(new ListItem("顯示卡", "3"));
            lbxSource.Items.Add(new ListItem("硬碟", "4"));
            lbxSource.Items.Add(new ListItem("DVD燒錄器", "5"));
            lbxSource.Items.Add(new ListItem("滑鼠", "6"));
            lbxSource.Items.Add(new ListItem("LCD夜晶螢幕", "7"));
            lbxSource.Items.Add(new ListItem("電源延長線插座", "8"));
            lbxSource.Items.Add(new ListItem("散熱風扇", "9"));
            lbxSource.Items.Add(new ListItem("喇叭", "10"));
            lbxSource.Items.Add(new ListItem("投影機", "11"));
             * */
        }
    }

    //將商品加入選購清單之中
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        //將商品加入選購清單之中
        for (int i = 0; i < lbxSource.Items.Count; i++)
        {
            if (lbxSource.Items[i].Selected == true)
            {
                lbxTarget.Items.Add(lbxSource.Items[i].Text);
                lbxSource.Items[i].Enabled = false;
            }
        }

        //移除已加入之商品，從最後一筆Item向前移除
        for (int i = lbxSource.Items.Count - 1; i >= 0; i--)
        {
            if (lbxSource.Items[i].Enabled == false)
            {
                lbxSource.Items.RemoveAt(i);
            }
        }
    }

    //將所有商品加入選購清單之中
    protected void btnAddAll_Click(object sender, ImageClickEventArgs e)
    {
        if (lbxSource.Items.Count > 0)
        {
            for (int i = 0; i < lbxSource.Items.Count; i++)
            {
                lbxTarget.Items.Add(lbxSource.Items[i].Text);
            }
        }

        lbxSource.Items.Clear();    //清除所有項目
    }

    //將商品自選購清單中移除
    protected void btnRemove_Click(object sender, ImageClickEventArgs e)
    {
        //將商品自選購清單中移除
        for (int i = 0; i < lbxTarget.Items.Count; i++)
        {
            if (lbxTarget.Items[i].Selected == true)
            {
                lbxSource.Items.Add(lbxTarget.Items[i].Text);
                lbxTarget.Items[i].Enabled = false;
            }
        }

        //移除選購清單之商品，從最後一筆Item向前移除
        for (int i = lbxTarget.Items.Count - 1; i >= 0; i--)
        {
            if (lbxTarget.Items[i].Enabled == false)
            {
                lbxTarget.Items.RemoveAt(i);
            }
            
        }
    }

    //將所有商品自選購清單中移除
    protected void btnRemoveAll_Click(object sender, ImageClickEventArgs e)
    {
        if (lbxTarget.Items.Count > 0)
        {
            for (int i = 0; i < lbxTarget.Items.Count; i++)
            {
                lbxSource.Items.Add(lbxTarget.Items[i].Text);
            }
        }

        lbxTarget.Items.Clear();    //清除所有項目
    }

    //顯示最後確定購買之商品項目
    protected void btnBuy_Click(object sender, EventArgs e)
    {
        //Response.Write(lbxTarget.Items.Count);
        if (lbxTarget.Items.Count > 0)
        {
            int i = 1;
            foreach (ListItem item in lbxTarget.Items)
            {
                txtMsg.Text += string.Format("{0:00}.{1}<BR/>", i, item.Text);
                i++;
            }
        }
        else
        {
            Response.Write("<script>alert('請先選購商品！')</script>");
        }
    }
}
