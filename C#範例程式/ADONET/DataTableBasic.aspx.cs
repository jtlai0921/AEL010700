using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class DataTableBasic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //建立並顯示DataTable資料表
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        //建立DataTable
        DataTable dtMembers = new DataTable("Members");

        //宣告DataTable四個DataColumn欄位定義
        dtMembers.Columns.Add(new DataColumn("會員編號",typeof(string)));
        dtMembers.Columns.Add(new DataColumn("姓名", typeof(string)));
        dtMembers.Columns.Add(new DataColumn("電話", typeof(string)));
        dtMembers.Columns.Add(new DataColumn("居住縣市", typeof(string)));

        //加入第一個會員資料
        DataRow row1 = dtMembers.NewRow();
        row1["會員編號"] = "A001";
        row1["姓名"] = "王仁義";
        row1["電話"] = "0922123456";
        row1["居住縣市"] = "台北市";
        dtMembers.Rows.Add(row1);   //將DataRow記錄加到DataTable中

        //加入第二個會員資料
        DataRow row2 = dtMembers.NewRow();
        row2["會員編號"] = "A002";
        row2["姓名"] = "林秀琴";
        row2["電話"] = "0933478152";
        row2["居住縣市"] = "桃園縣";
        dtMembers.Rows.Add(row2);

        //加入第三個會員資料
        DataRow row3 = dtMembers.NewRow();
        row3["會員編號"] = "A003";
        row3["姓名"] = "林明月";
        row3["電話"] = "0968325182";
        row3["居住縣市"] = "台中市縣";
        dtMembers.Rows.Add(row3);


        //加入第四個會員資料
        DataRow row4 = dtMembers.NewRow();
        row4["會員編號"] = "A004";
        row4["姓名"] = "陳玉玫";
        row4["電話"] = "0935456822";
        row4["居住縣市"] = "高雄縣";
        dtMembers.Rows.Add(row4);   

        //顯示DataTable資料
        gvMembers.DataSource = dtMembers;
        gvMembers.DataBind();
    }
}
