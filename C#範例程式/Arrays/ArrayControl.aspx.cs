using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ArrayControl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //將陣列中的產品資料加入到ASP.NET控制項之中
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string[] products = new string[] {"電腦","LCD螢幕","HDD硬碟","CPU處理器","RAM記憶體" };

        //以迴圈將陣列元素加入到DropDownList控制項之中
        foreach (string p in products)
        {
            dwnProducts.Items.Add(p);
        }

        //透過DropDownList的DataSource屬性，指定資料來源為陣列
        dwnProducts1.DataSource = products;
        dwnProducts1.DataBind();    //資料繫結

        //將資料繫結到GridView控制項之中
        gvProducts.DataSource = products;
        gvProducts.DataBind();
    }

    protected void dwnProducts_SelectedIndexChanged(object sender, EventArgs e)
    {
        //將sender轉換成DropDownList控制項，
        //當成參數傳入showProduct()方法之中
        showProduct((DropDownList)sender);  
    }

    protected void dwnProducts1_SelectedIndexChanged(object sender, EventArgs e)
    {
        showProduct((DropDownList)sender);
    }

    //顯示產品名稱
    protected void showProduct(DropDownList product)
    {
        txtMsg.Text = "您選擇的產品是：" + product.SelectedItem.Text;
    }
}
