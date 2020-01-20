using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
{
    string filter = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["Permission"].ToString().Contains("R"))
        {
            Response.Redirect("Message.aspx?Reason=必須具備讀取權限");
        }
        txtID.Focus();
    }

    //如果兩個TextBox都沒有輸入任何資料，則取消SqlDataSource查詢動作
    protected void sqlStudents_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        if (String.IsNullOrEmpty(txtID.Text) && String.IsNullOrEmpty(txtName.Text))
        {
            e.Cancel = true;
        }
    }

    //查詢資料
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtID.Text) && String.IsNullOrEmpty(txtName.Text))
        {
            txtMsg.Text = "請至少輸入一個查詢！";
        }
        else
        {
            //加入Where條件式-ID
            if (!String.IsNullOrEmpty(txtID.Text))
            {
                filter = " Where ID like @paramID";
                sqlStudents.SelectCommand = sqlStudents.SelectCommand + filter;
                if (sqlStudents.SelectParameters["paramID"]==null)
                {
                    sqlStudents.SelectParameters.Add("paramID", TypeCode.String, "");
                }

                sqlStudents.SelectParameters["paramID"].DefaultValue = "%" + txtID.Text + "%";
            }

            //加入Where條件式-Name
            if (!String.IsNullOrEmpty(txtName.Text))
            {
                if (filter == "")
                {
                    filter = " Where Name like @paramName";
                }
                else
                {
                    filter = " " + dwnAndOr.SelectedValue + " Name like @paramName";
                }
                sqlStudents.SelectCommand = sqlStudents.SelectCommand + filter;

                if (sqlStudents.SelectParameters["paramName"] ==null)
                {
                    sqlStudents.SelectParameters.Add("paramName", TypeCode.String, "");
                }
                sqlStudents.SelectParameters["paramName"].DefaultValue = "%" + txtName.Text + "%";
                //進行查詢
                sqlStudents.Select(DataSourceSelectArguments.Empty);
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
}