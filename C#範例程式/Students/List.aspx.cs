using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["Permission"].ToString().Contains("R"))
        {
            Response.Redirect("Message.aspx?Reason=必須具備讀取權限");
        }
    }

    //如果沒有編輯或刪除權限，則將對應的Button按鈕隱藏
    protected void gvStudents_DataBound(object sender, EventArgs e)
    {
        string permission = Session["Permission"].ToString();
        if (!permission.Contains("U") || !permission.Contains("D"))
        {
            Button btnEdit, btnDelete;
            for (int i = 0; i <= gvStudents.Rows.Count - 1; i++)
            {
                if (!permission.Contains("U"))
                {
                    btnEdit = (Button)gvStudents.Rows[i].Cells[0].Controls[1];
                    if (btnEdit.Text == "編輯")
                    {
                        btnEdit.Enabled = false;
                    }
                }

                if (!permission.Contains("D"))
                {
                    btnDelete = (Button)gvStudents.Rows[i].Cells[0].Controls[3];
                    if (btnDelete.Text == "刪除")
                    {
                        btnDelete.Enabled = false;
                    }
                }
            }
        }
    }

    //將Gender性別的Boolean，由true或false轉換成男或女
    protected void gvStudents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView view = (DataRowView)e.Row.DataItem;

            if (view != null)
            {
                //取得Gender欄位資料
                if (!String.IsNullOrEmpty(view[2].ToString()))
                {
                    bool gender = (bool)view[2];
                    Label txtGender = (Label)e.Row.Cells[3].FindControl("txtGender");
                    if (txtGender != null)
                    {
                        if (gender == true)
                        {
                            txtGender.Text = "男";
                        }
                        else
                        {
                            txtGender.Text = "女";
                        }
                    }
                }
            }
        }
    }

    //編輯模式時，設定欄位的寬度
    protected void gvStudents_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvStudents.Columns[2].ControlStyle.Width = 55;
        gvStudents.Columns[4].ControlStyle.Width = 65;
        gvStudents.Columns[6].ControlStyle.Width = 50;
        gvStudents.Columns[7].ControlStyle.Width = 50;
        gvStudents.Columns[10].ControlStyle.Width = 50;
    }

    //替身高的DropDownList加入項目
    protected void dwnHeight_Load(object sender, EventArgs e)
    {
        DropDownList dwnHeight = (DropDownList)sender;
        dwnHeight.Items.Add("==");
        for (int i = 155; i <= 185; i++)
        {
            dwnHeight.Items.Add(i.ToString());
        }
    }

    //替體重的DropDownList加入項目
    protected void dwnWeight_Load(object sender, EventArgs e)
    {
        DropDownList dwnWeight = (DropDownList)sender;
        dwnWeight.Items.Add("==");
        for (int i = 50; i <= 90; i++)
        {
            dwnWeight.Items.Add(i.ToString());
        }
    }

    //ToolTips屬性會Bind("Blood")，故選擇索引改變時，
    //設定ToolTip內容為選取文字，然後自動繫結回寫資料庫
    protected void dwnBlood_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList dwnBlood = (DropDownList)sender;
        if (dwnBlood.SelectedValue != "0")
        {
            dwnBlood.ToolTip = dwnBlood.SelectedItem.Text;
        }
    }

    //ToolTips屬性會Bind("Height")，故選擇索引改變時，
    //設定ToolTip內容為選取文字，然後自動繫結回寫資料庫
    protected void dwnHeight_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList dwnHeight = (DropDownList)sender;
        if (dwnHeight.SelectedValue != "0")
        {
            dwnHeight.ToolTip = dwnHeight.SelectedItem.Text;
        }
    }

    //ToolTips屬性會Bind("Weight")，故選擇索引改變時，
    //設定ToolTip內容為選取文字，然後自動繫結回寫資料庫
    protected void dwnWeight_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList dwnWeight = (DropDownList)sender;
        if (dwnWeight.SelectedValue != "0")
        {
            dwnWeight.ToolTip = dwnWeight.SelectedItem.Text;
        }
    }

    //ToolTips屬性會Bind("City")，故選擇索引改變時，
    //設定ToolTip內容為選取文字，然後自動繫結回寫資料庫
    protected void dwnCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList dwnCity = (DropDownList)sender;
        if (dwnCity.SelectedValue != "0")
        {
            dwnCity.ToolTip = dwnCity.SelectedItem.Text;
        }
    }
}