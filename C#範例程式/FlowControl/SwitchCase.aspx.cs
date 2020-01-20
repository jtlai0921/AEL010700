using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class SwitchCase : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //當DropDownList選擇項目變換時之事件處理
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //第一種方式，SelectedItem.Value來判斷，可以達到唯一識別
        switch (dwnJob.SelectedItem.Value)
        {
            case "1":
                txtSalary.Text = "每月薪資100,000元";
                break;
            case "2":
                txtSalary.Text = "每月薪資60,000元";
                break;
            case "3":
                txtSalary.Text = "每月薪資35,000元";
                break;
            case "4":
                txtSalary.Text = "每月薪資20,000元";
                break;
            default:
                txtSalary.Text = "";
                break;
        }
         
        //第二種方式，以SelectedItem.Text來判斷，Text不一定有唯一識別
        /*
        switch (dwnJob.SelectedItem.Text)
        {
            case "總經理":
                txtSalary.Text = "每月薪資100,000元";
                break;
            case "經理":
                txtSalary.Text = "每月薪資60,000元";
                break;
            case "工程師":
                txtSalary.Text = "每月薪資35,000元";
                break;
            case "助理":
                txtSalary.Text = "每月薪資20,000元";
                break;
        }*/
    }
}
