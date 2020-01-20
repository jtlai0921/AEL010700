﻿Imports System.Data
Imports System.Data.SqlClient

Partial Class UpdateProducts
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            showProducts()
        End If
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim conn As SqlConnection = Nothing
        Dim cmd As SqlCommand = Nothing

        Try
            conn = New SqlConnection("Data Source=.;Initial Catalog=myDB;User Id=sa;Password=test")
            conn.Open() '開啓資料庫連線

            '建立SqlCommand查詢命令
            cmd = New SqlCommand("Update myProducts Set Quantity=120,Price=28 Where ProductID='M0001'  ", conn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Response.Write(ex.ToString() )  '顯示錯誤訊息
        Finally
            '釋放物件及連線資源
            cmd.Dispose()
            conn.Close()
            conn.Dispose()
        End Try

        showProducts() '顯示產品資料
    End Sub

    Protected Sub showProducts()
        '建立資料庫連線
        Dim conn As New SqlConnection("Data Source=.;Initial Catalog=myDB;User Id=sa;Password=test")
        conn.Open() '開啓資料庫連線

        '建立SqlCommand查詢命令
        Dim cmd As New SqlCommand("Select * From myProducts ", conn)
        Dim dr As SqlDataReader = cmd.ExecuteReader()   '執行查詢

        gvProducts.DataSource = dr  '指定GridView控制項之資料來源
        gvProducts.DataBind()   '資料繫結

        '釋放物件及連線資源
        dr.Dispose()
        cmd.Dispose()
        conn.Close()
        conn.Dispose()
    End Sub
End Class
