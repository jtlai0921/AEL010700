using System;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class dvAppearance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

	protected void dvEmps_ModeChanging(object sender, DetailsViewModeEventArgs e)
	{
		//依不同模式顯示Headertext及背景色
		switch (e.NewMode)
		{
			case DetailsViewMode.Edit:
				dvEmp.HeaderText="編輯員工基本資料";
				dvEmp.HeaderStyle.HorizontalAlign=HorizontalAlign.Center;
				dvEmp.HeaderStyle.BackColor = Color.Red;
				//若為編輯模式，則改變其背景色及各個Fields設定其寬度為100
				dvEmp.EditRowStyle.BackColor = Color.LightPink;
				for (int i = 0; i < dvEmp.Fields.Count-1; i++)
				{
					dvEmp.Fields[i].ControlStyle.Width = 150;
				}
				break;
			case DetailsViewMode.Insert:
				dvEmp.HeaderText = "新增員工基本資料";
				dvEmp.HeaderStyle.HorizontalAlign=HorizontalAlign.Center;
				dvEmp.HeaderStyle.BackColor = Color.DeepSkyBlue;
				//若為新增模式，則改變其背景色及各個Fields設定其寬度為100
				dvEmp.InsertRowStyle.BackColor = Color.LightCyan;
				for (int i = 0; i < dvEmp.Fields.Count-1; i++)
				{
					dvEmp.Fields[i].ControlStyle.Width = 150;
					dvEmp.Fields[i].ControlStyle.Height = 35;
				}
				break;
			default :
				dvEmp.HeaderStyle.BackColor = Color.Tan;
				break;
		}
	}

	//改變TextBox為MultiLine及改變背景顏色
	protected void dvEmp_DataBound(object sender, EventArgs e)
	{
		//在編輯及新增模式下將TextBox改為MultiLine及改變背景顏色
		if (dvEmp.Rows[1].Cells[1].Controls.Count > 0)
		{
			((TextBox)dvEmp.Rows[1].Cells[1].Controls[0]).TextMode = TextBoxMode.MultiLine;
			((TextBox)dvEmp.Rows[1].Cells[1].Controls[0]).BackColor = Color.LightBlue;
			((TextBox)dvEmp.Rows[2].Cells[1].Controls[0]).TextMode = TextBoxMode.MultiLine;
			((TextBox)dvEmp.Rows[2].Cells[1].Controls[0]).BackColor = Color.LightCoral;
			((TextBox)dvEmp.Rows[3].Cells[1].Controls[0]).TextMode = TextBoxMode.MultiLine;
			((TextBox)dvEmp.Rows[3].Cells[1].Controls[0]).BackColor = Color.LightGreen;
			((TextBox)dvEmp.Rows[4].Cells[1].Controls[0]).TextMode = TextBoxMode.MultiLine;
			((TextBox)dvEmp.Rows[4].Cells[1].Controls[0]).BackColor = Color.LightYellow;
		}
	}

	//判斷使用者所按下的命令欄位按鈕
	protected void dvEmp_ItemCommand(object sender, DetailsViewCommandEventArgs e)
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
			default :
				txtMsg.Text = "";
				break;
		}
	}
	
	//取消刪除
	protected void dvEmp_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
	{
		e.Cancel = true;
        WebMessageBox.MessageBox.Show("已觸發刪除命令，但為確保原始資料故取消刪除命令！");
	}
}
