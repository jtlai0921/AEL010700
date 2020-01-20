using System;
using System.Data;
using System.Web.Security;
using System.Web.UI.WebControls;

public partial class Accounts : System.Web.UI.Page
{
    string InputMsg = "";   //輸入驗證之訊息
    protected void Page_Load(object sender, EventArgs e)
    {
        //判斷是否身份通過驗證
        if (User.Identity.IsAuthenticated == false)
        {
            FormsAuthentication.RedirectToLoginPage();
        }
        else
        {
            if (Session["Role"].ToString() != "Admin")
            {
                txtMsg.Text = "你沒有瀏覽權限，限管理者使用！";
                txtMsg.Visible = true;
                plAccount.Visible = false;
            }
        }
    }

    //
    protected void sqlAccount_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        //檢查是否具有Admin管理者權限，才允許瀏覽帳號資料
        if (Session["Role"].ToString() != "Admin")
        {
            e.Cancel = true;
        }
    }

    //角色改變時，更新到資料庫
    protected void dwnRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList dwnRole = (DropDownList)sender;
        if (dwnRole.SelectedValue != "0")
        {
            dwnRole.ToolTip = dwnRole.SelectedItem.Text;
        }
    }

    protected void dwnRole_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DropDownList dwnRole = (DropDownList)sender;
        if (dwnRole.SelectedValue != "0")
        {
            dwnRole.ToolTip = dwnRole.SelectedItem.Text;
        }
    }

    //CRUD權限勾選改變時，將權限更新到資料庫
    protected void cbxPermission_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckBoxList cbxPermission = (CheckBoxList)sender;
        string permission = getPermission(cbxPermission);
        Label txtPermission = (Label)cbxPermission.Parent.FindControl("txtPermission");
        txtPermission.Text = permission;
    }

    protected string getPermission(CheckBoxList cbxPermission)
    {
        string permission = "";
        //判斷CheckBoxList項目是否被勾選
        for (int i = 0; i <= cbxPermission.Items.Count - 1; i++)
        {
            switch (cbxPermission.Items[i].Value)
            {
                case "C":
                    if (cbxPermission.Items[i].Selected)
                    {
                        permission += "C";
                    }
                    break;
                case "R":
                    if (cbxPermission.Items[i].Selected)
                    {
                        permission += "R";
                    }
                    break;
                case "U":
                    if (cbxPermission.Items[i].Selected)
                    {
                        permission += "U";
                    }
                    break;
                case "D":
                    if (cbxPermission.Items[i].Selected)
                    {
                        permission += "D";
                    }
                    break;
            }
        }


        return (permission == "" ? "" : permission);
    }

    //GridView資料繫結時，將CRUD資料還原到CheckBoxList控制項
    protected void gvAccount_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView view = (DataRowView)e.Row.DataItem;
            if (view != null)
            {
                //取得permission欄位資料
                string permission = view[1].ToString();
                //取得CheckBoxList控制項
                CheckBoxList cbxPermission = (CheckBoxList)e.Row.Cells[1].FindControl("cbxPermission");

                //根據CRUD還勾選顯示CheckBoxList控制項
                var y = permission.GetEnumerator();
                while (y.MoveNext())
                {
                    RestoreCheckBox(cbxPermission, y.Current);
                }
            }
        }
    }

    //依據CRUD還原勾選CheckBoxList的項目
    protected void RestoreCheckBox(CheckBoxList cbxPermission, char p)
    {
        //計算CheckBoxList中有幾個項目
        int count = cbxPermission.Items.Count;
        for (int i = 0; i < count; i++)
        {
            if (cbxPermission.Items[i].Value == p.ToString())
            {
                cbxPermission.Items[i].Selected = true;
            }
        }
    }

    //新增帳號資料
    protected void btnNew_Click(object sender, EventArgs e)
    {
        //寫入ADO.NET之前，先進行防呆檢查
        txtResult.Text = "";

        if (CheckInput())
        {
            try
            {
                sqlAccount.InsertParameters["ID"].DefaultValue = txtID.Text;
                sqlAccount.InsertParameters["Password"].DefaultValue = txtPassword.Text;
                sqlAccount.InsertParameters["Permission"].DefaultValue = getPermission(cblPermission);
                sqlAccount.InsertParameters["Role"].DefaultValue = dwnRole.SelectedItem.Text;
                //sqlAccount.InsertParameters["Active"].DbType = DbType.Boolean;
                sqlAccount.InsertParameters["Active"].DefaultValue = "true";
                sqlAccount.Insert();
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.ToString();
            }
        }
        else
        {
            txtResult.Text = InputMsg;
        }
    }

    protected bool CheckInput()
    {
        //Input輸入合法性檢查,預設為True
        bool status = true;
        if (String.IsNullOrEmpty(txtID.Text))
        {
            status = false;
            InputMsg += "＊帳號不得為零或空白<BR/>";
        }

        if (String.IsNullOrEmpty(txtPassword.Text))
        {
            status = false;
            InputMsg += "＊密碼不得為零或空白<BR/>";
        }

        if (dwnRole.SelectedValue == "0")
        {
            status = false;
            InputMsg += "＊必須選擇角色群組<BR/>";
        }

        return status;
    }

    //顯示帳號建立成功或失敗訊息
    protected void sqlAccount_Inserted(object sender, SqlDataSourceStatusEventArgs e)
    {
        if (e.AffectedRows > 0)
        {
            //寫入成功，顯示成功之訊息
            txtResult.Text = "帳號建立成功！";
            txtID.Text = "";
            txtPassword.Text = "";
            cblPermission.ClearSelection();
            dwnRole.ClearSelection();
            //GridView必須再重新繫結，才能顯示新增的帳號
            gvAccount.DataBind();
        }
        else
        {
            txtResult.Text = "帳號建立失敗！";
        }
    }
}