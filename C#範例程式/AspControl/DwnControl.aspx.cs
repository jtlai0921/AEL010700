using System;
using System.Web.UI.WebControls;

public partial class DwnControl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListItem item = new ListItem("===請先選擇區域===", "0");
            dwnCity.Items.Add(item);
            dwnCity.Items[0].Selected = true;
            dwnCity.Enabled = false;
        }
    }

    //區域DropDownList選擇改變時，動態建立相對應之城市DropDownList項目
    protected void dwnRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        dwnCity.Items.Clear();  //清除DropDownList控制項之所有項目

        //依所選擇之地區，顯示該地區之城市
        switch (dwnRegion.SelectedValue)
        {
            case "0":
                //加入項目到DropDownList控制項
                dwnCity.Items.Add(new ListItem("===請先選擇區域===", "0"));
                dwnCity.Enabled = false;
                break;
            case "1":
                dwnCity.Items.Add(new ListItem("===請選擇城市===", "0"));
                dwnCity.Items.Add(new ListItem("紐約","1"));
                dwnCity.Items.Add(new ListItem("芝加哥","2"));
                dwnCity.Items.Add(new ListItem("拉斯維加斯","3"));
                dwnCity.Enabled = true;
                break;
            case "2":
                dwnCity.Items.Add(new ListItem("===請選擇城市===", "0"));
                dwnCity.Items.Add(new ListItem("北京", "1"));
                dwnCity.Items.Add(new ListItem("上海", "2"));
                dwnCity.Items.Add(new ListItem("香港", "3"));
                dwnCity.Enabled = true;
                break;
            case "3":
                dwnCity.Items.Add(new ListItem("===請選擇城市===", "0"));
                dwnCity.Items.Add(new ListItem("台北", "1"));
                dwnCity.Items.Add(new ListItem("台中", "2"));
                dwnCity.Items.Add(new ListItem("高雄", "3"));
                dwnCity.Enabled = true;
                break;
        }
    }

    //顯示居住所在地區及城市
    protected void dwnCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dwnCity.SelectedValue != "0")
        {
            txtMsg.Text = string.Format("您居住的地點為{0}，{1}", dwnRegion.SelectedItem.Text, dwnCity.SelectedItem.Text);
        }
        else
        {
            txtMsg.Text = "";
        }
    }
}
