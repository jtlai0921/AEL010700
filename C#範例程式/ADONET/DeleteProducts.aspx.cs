﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class DeleteProducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showProducts();
        }
    }

    //刪除產品記錄
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //建立資料庫連線
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=myDB;User Id=sa;Password=test");
        conn.Open();    //開啓資料庫連線

        //建立SqlCommand查詢命令
        SqlCommand cmd = new SqlCommand("Delete From myProducts Where ProductID='M0001' ", conn);
        int rows=cmd.ExecuteNonQuery();

        //釋放物件及連線資源
        cmd.Dispose();
        conn.Close();
        conn.Dispose();

        txtMsg.Text = string.Format("已刪除{0}筆產品資料記錄！",rows);
        showProducts();
    }

    //顯示產品資料
    protected void showProducts()
    {
        //建立資料庫連線
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=myDB;User Id=sa;Password=test");
        conn.Open();    //開啓資料庫連線

        //建立SqlCommand查詢命令
        SqlCommand cmd = new SqlCommand("Select * From myProducts ", conn);
        SqlDataReader dr = cmd.ExecuteReader(); //執行查詢

        gvProducts.DataSource = dr; //指定GridView控制項之資料來源
        gvProducts.DataBind();  //資料繫結

        //釋放物件及連線資源
        dr.Dispose();
        cmd.Dispose();
        conn.Close();
        conn.Dispose();
    }
}
