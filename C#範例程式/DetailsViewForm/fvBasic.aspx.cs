using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class fvBasic : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		
	}

	//在資料FormView完成資料繫結後存取其內容資料
	protected void fvEmp_DataBound(object sender, EventArgs e)
	{
		if (fvEmp.CurrentMode==FormViewMode.ReadOnly)
		{
			//透過DataRowView來讀取資料欄位，這方法也適用於DetailsView
			DataRowView drView = (DataRowView)fvEmp.DataItem;
			txtMsg1.Text = "<Font Color='Red'>這是DataRowView</Font><BR>";
			txtMsg1.Text += drView["EmployeeID"].ToString() + "<BR>";
			txtMsg1.Text += drView["LastName"].ToString() + "<BR>";
			txtMsg1.Text += drView["FirstName"].ToString() + "<BR>";
			txtMsg1.Text += drView["City"].ToString() + "<BR>";
			txtMsg1.Text += drView["Country"].ToString() + "<BR>";

			//透過尋找Label控制項的方式來達成
			FormViewRow Row = fvEmp.Row;
			txtMsg2.Text = "<Font Color='Red'>這是FormViewRow</Font><BR>";
			txtMsg2.Text += ((Label)Row.FindControl("txtEmployeeID")).Text + "<BR>";
			txtMsg2.Text += ((Label)Row.FindControl("txtLastName")).Text + "<BR>";
			txtMsg2.Text += ((Label)Row.FindControl("txtFirstName")).Text + "<BR>";
			txtMsg2.Text += ((Label)Row.FindControl("txtCity")).Text + "<BR>";
			txtMsg2.Text += ((Label)Row.FindControl("txtCountry")).Text + "<BR>";
		}

		AddPagerIndex();	//加入Page索引
	}

    protected void fvEmp_PageIndexChanged(object sender, EventArgs e)
	{
		AddPagerIndex();	//加入Page索引
	}

	//建立及取得FormView的HeaderRow及HeaderRow
	protected void AddPagerIndex()
	{
		//目的是為了加入Page參考索引筆數
		FormViewRow headerRow = fvEmp.HeaderRow;
		FormViewRow footerRow = fvEmp.FooterRow;
		FormViewRow bottomPagerRow = fvEmp.BottomPagerRow;
		headerRow.BackColor = Color.Red;
		footerRow.BackColor = Color.LightBlue;

		Label txtPagerNo1 = new Label();
		Label txtPagerNo2 = new Label();
		txtPagerNo1.Text = "員工基本資料維護( " + (fvEmp.DataItemIndex + 1) + "/" + fvEmp.DataItemCount + " )";
		txtPagerNo2.Text = "資料項目索引( " + (fvEmp.DataItemIndex + 1) + "/" + fvEmp.DataItemCount + ")";
		headerRow.Cells[0].Controls.Add(txtPagerNo1);
		bottomPagerRow.Cells[0].Controls.Add(txtPagerNo2);
	}

	//取消刪除作業
    protected void fvEmp_ItemDeleting(object sender, FormViewDeleteEventArgs e)
	{
		e.Cancel = true;
        WebMessageBox.MessageBox.Show("已觸發刪除命令，但為確保原始資料故取消刪除命令！");
	}

    //判斷命令的選擇
    protected void fvEmp_ItemCommand(object sender, FormViewCommandEventArgs e)
	{
		switch (e.CommandName)
		{
			case "Edit":
				WebMessageBox.MessageBox.Show("您按下的是編輯按鈕!");
				break;
			case "New":
                WebMessageBox.MessageBox.Show("您按下的是新增按鈕!");
				break;
			case "Delete":
                WebMessageBox.MessageBox.Show("您按下的是刪除按鈕!");
				break;
			case "Cancel":
                WebMessageBox.MessageBox.Show("您按下的是取消按鈕!");
				break;
		}
	}
}