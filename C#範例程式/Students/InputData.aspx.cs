using System;
using System.Web.UI.WebControls;

public partial class InputData : System.Web.UI.Page
{
    string InputMsg = "";   //欄位輸入驗證之訊息
    protected void Page_Load(object sender, EventArgs e)
    {
        //檢查是否具有學生資料讀取權限
        string permission = Session["Permission"].ToString();
        if (!(permission.Contains("R") && permission.Contains("C")))
        {
            Response.Redirect("Message.aspx?Reason=必須同時具備讀取與新增權限");
        }

        //產生控制項資料
        DropDownList dwnHeight = (DropDownList)dvStudent.FindControl("dwnHeight");
        DropDownList dwnWeight = (DropDownList)dvStudent.FindControl("dwnWeight");
        dwnHeight.Items.Add("=請選擇=");
        for (int i = 155; i < 185; i++)
        {
            dwnHeight.Items.Add(i.ToString());
        }

        dwnWeight.Items.Add("=請選擇=");
        for (int i = 50; i < 90; i++)
        {
            dwnWeight.Items.Add(i.ToString());
        }

        RadioButtonList rdo = (RadioButtonList)dvStudent.FindControl("rdoGender");
    }

    protected void dvStudent_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        //檢查是否有新增資料之權限
        if (!Session["Permission"].ToString().Contains("C"))
        {
            e.Cancel = true;     //若沒有新增權限，則取消插入動作
        }
        else
        {
            //新增資料前，進行輸入資料之檢查
            if (CheckInput() == false)
            {
                txtMsg.Text = "<ul>" + InputMsg + "</ul>";
                e.Cancel = true;
            }
        }
    }

    //顯示新增資料成功或失敗訊息
    protected void dvStudent_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        if (e.AffectedRows > 0)
        {
            txtMsg.Text = "新增資料成功！";
        }
        else
        {
            txtMsg.Text = "新增資料失敗！";
        }
    }

    protected bool CheckInput()
    {
        //Input輸入合法性檢查,預設為True
        bool status = true;
        //檢查ID帳號不得為空白
        if (String.IsNullOrEmpty(((TextBox)dvStudent.FindControl("txtID")).Text.Trim()))
        {
            status = false;
            InputMsg += "<li>＊請輸入ID帳號</li>";
        }

        //檢查姓名不得為空白
        if (String.IsNullOrEmpty(((TextBox)dvStudent.FindControl("txtName")).Text.Trim()))
        {
            status = false;
            InputMsg += "<li>＊請輸入姓名</li>";
        }

        //檢查性別是否有選擇
        RadioButtonList rdoGender = (RadioButtonList)dvStudent.FindControl("rdoGender");
        if (rdoGender.SelectedIndex == -1)
        {
            status = false;
            InputMsg += "<li>＊請輸入性別</li>";
        }

        //檢查血型是否有選擇
        RadioButtonList rdoBlood = (RadioButtonList)dvStudent.FindControl("rdoBlood");
        if (rdoBlood.SelectedIndex == -1)
        {
            status = false;
            InputMsg += "<li>＊請輸入血型</li>";
        }

        //身高
        if (((DropDownList)dvStudent.FindControl("dwnHeight")).SelectedIndex == 0)
        {
            status = false;
            InputMsg += "<li>＊請輸入身高</li>";
        }

        //體重
        if (((DropDownList)dvStudent.FindControl("dwnWeight")).SelectedIndex == 0)
        {
            status = false;
            InputMsg += "<li>＊請輸入體重</li>";
        }

        //縣市
        if (((DropDownList)dvStudent.FindControl("dwnCity")).SelectedIndex == 0)
        {
            status = false;
            InputMsg += "<li>＊請輸入縣市</li>";
        }

        //檢查地址不得為空白
        if (String.IsNullOrEmpty((((TextBox)dvStudent.FindControl("txtAddress")).Text.Trim())))
        {
                        status = false;
            InputMsg += "<li>＊請輸入地址</li>";
        }

        //檢查電話不得為空白
        if (String.IsNullOrEmpty((((TextBox)dvStudent.FindControl("txtAddress")).Text.Trim())))
        {
            status = false;
            InputMsg += "<li>＊請輸入地址</li>";
        }

        return status;
    }
    //性別,ToolTip屬性與資料來源欄位是Bind雙向繫結
    protected void rdoGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        //故將DropDownList選取項目指定給ToolTip屬性
        //在Insert到資料庫時，它會自動寫入到欄位
        RadioButtonList rdoGender = (RadioButtonList)sender;
        rdoGender.ToolTip = (rdoGender.SelectedItem.Text == "男" ? "true" : "false");
    }

    //血型,ToolTip屬性與資料來源欄位是Bind雙向繫結
    protected void rdoBlood_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadioButtonList rdoBlood = (RadioButtonList)sender;
        rdoBlood.ToolTip = rdoBlood.SelectedItem.Text;
    }

    //身高,ToolTip屬性與資料來源欄位是Bind雙向繫結
    protected void dwnHeight_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList dwnHeight = (DropDownList)sender;
        dwnHeight.ToolTip = dwnHeight.SelectedItem.Text;
    }

    //體重,ToolTip屬性與資料來源欄位是Bind雙向繫結
    protected void dwnWeight_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList dwnWeight = (DropDownList)sender;
        dwnWeight.ToolTip = dwnWeight.SelectedItem.Text;
    }

    //城市,ToolTip屬性與資料來源欄位是Bind雙向繫結
    protected void dwnCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList dwnCity = (DropDownList)sender;
        dwnCity.ToolTip = dwnCity.SelectedItem.Text;
    }
}