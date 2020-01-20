using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class dvDataItemCode : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        //以程式動態設定PagerSetting分頁圖片
        dvEmployee.PagerSettings.Mode = PagerButtons.NextPreviousFirstLast;
        dvEmployee.PagerSettings.Position = PagerPosition.Bottom;
        dvEmployee.PagerSettings.FirstPageImageUrl = "~/Images/First.gif";
        dvEmployee.PagerSettings.LastPageImageUrl = "~/Images/Last.gif";
        dvEmployee.PagerSettings.PreviousPageImageUrl = "~/Images/Previous.gif";
        dvEmployee.PagerSettings.NextPageImageUrl = "~/Images/Next.gif";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        dvEmployee.DataBind();	//為了自訂分頁數字按鈕的繫結

        if (!IsPostBack)
        {
            if (dvEmployee.DataItemCount > 0)
            {
                ListItem myListItem;
                myListItem = new ListItem("請選擇", "0");
                dwnPageIndex.Items.Add(myListItem);

                //依資料來源資料筆數建立DropDownList中的頁碼
                for (int i = 1; i <= dvEmployee.DataItemCount; i++)
                {
                    myListItem = new ListItem(i.ToString(), i.ToString());
                    dwnPageIndex.Items.Add(myListItem);
                }
            }
        }
    }

    protected void dvEmployee_DataBound(object sender, EventArgs e)
    {
        DataRowView drView = (DataRowView)dvEmployee.DataItem;
        //將英文國家名稱轉換成中文名稱
        switch (drView["Country"].ToString().ToUpper())
        {
            case "USA":
                drView["Country"] = "美國";
                break;
            case "UK":
                drView["Country"] = "英國";
                break;
            case "TAIWAN":
                drView["Country"] = "台灣";
                break;
        }

        //上面將Country由英文替換成中文國家後必須再繫結一次
        dvEmployee.Rows[4].DataBind();

        AddPagerIndex();

        //Pager列
        DetailsViewRow bottomPagerRow = dvEmployee.BottomPagerRow;

        //動態建立分頁按鈕
        for (int i = 0; i < dvEmployee.PagerSettings.PageButtonCount; i++)
        {
            LinkButton PageNo = new LinkButton();
            PageNo.Text = Convert.ToString(i + 1);
            PageNo.ID = (PageNo + i.ToString());
            PageNo.CommandArgument = i.ToString();
            PageNo.Click += new EventHandler(PageNo_Click);
            bottomPagerRow.Cells[0].Controls.Add(PageNo);
            Literal blank = new Literal();
            blank.Text = " ";
            bottomPagerRow.Cells[0].Controls.Add(blank);
        }
    }

    //建立及取得DetailsView的HeaderRow及HeaderRow
    protected void AddPagerIndex()
    {
        //目的是為了加入Page參考索引筆數
        DetailsViewRow headerRow = dvEmployee.HeaderRow;
        DetailsViewRow bottomPagerRow = dvEmployee.BottomPagerRow;

        Label txtPagerNo1 = new Label();
        Label txtPagerNo2 = new Label();
        txtPagerNo1.Text = "員工基本資料維護( " + (dvEmployee.DataItemIndex + 1) + "/" + dvEmployee.DataItemCount + " )";
        txtPagerNo2.Text = "資料項目索引( " + (dvEmployee.DataItemIndex + 1) + "/" + dvEmployee.DataItemCount + ")";
        headerRow.Cells[0].Controls.Add(txtPagerNo1);
        bottomPagerRow.Cells[0].Controls.Add(txtPagerNo2);

        Literal blank = new Literal();
        blank.Text = "<BR/>";
        bottomPagerRow.Cells[0].Controls.Add(blank);

        //讀取欄位標題及資訊內容
        //方法一
        txtMsg1.Text = "<Font Color='Red'>這是Rows.Cell</Font><BR>";
        txtMsg1.Text += dvEmployee.HeaderRow.Cells[0].Text + "<br/>";
        txtMsg1.Text += dvEmployee.Rows[0].Cells[0].Text + "：" + dvEmployee.Rows[0].Cells[1].Text + "<br/>";
        txtMsg1.Text += dvEmployee.Rows[1].Cells[0].Text + "：" + dvEmployee.Rows[1].Cells[1].Text + "<br/>";
        txtMsg1.Text += dvEmployee.Rows[2].Cells[0].Text + "：" + dvEmployee.Rows[2].Cells[1].Text + "<br/>";
        txtMsg1.Text += dvEmployee.Rows[3].Cells[0].Text + "：" + dvEmployee.Rows[3].Cells[1].Text + "<br/>";
        txtMsg1.Text += dvEmployee.Rows[4].Cells[0].Text + "：" + dvEmployee.Rows[4].Cells[1].Text + "<br/>";

        //方法二
        DataRowView drView = (DataRowView)dvEmployee.DataItem;
        txtMsg2.Text = "<Font Color='Red'>這是DataRowView</Font><BR>";
        txtMsg2.Text += drView["EmployeeID"].ToString() + "<BR>";
        txtMsg2.Text += drView["LastName"].ToString() + "<BR>";
        txtMsg2.Text += drView["FirstName"].ToString() + "<BR>";
        txtMsg2.Text += drView["City"].ToString() + "<BR>";
        txtMsg2.Text += drView["Country"].ToString() + "<BR>";
    }

    //建立分頁按鈕事件
    void PageNo_Click(object sender, EventArgs e)
    {
        dvEmployee.PageIndex = Convert.ToInt16(((LinkButton)sender).CommandArgument);
    }

    //前往選擇的頁碼
    protected void dwnPageIndex_SelectedIndexChanged(object sender, EventArgs e)
    {
        dvEmployee.PageIndex = dwnPageIndex.SelectedIndex - 1;
    }

    //取消刪除資料
    protected void dvEmployee_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
    {
        e.Cancel = true;
        WebMessageBox.MessageBox.Show("已觸發刪除命令，但為確保原始資料故取消刪除命令！");
    }
}
