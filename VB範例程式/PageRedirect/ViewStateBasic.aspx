﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ViewStateBasic.aspx.vb"
    Inherits="ViewStateBasic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/VB" runat="server">
        Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
            Response.Write("<Img Src='Images/ViewState.jpg' /><BR/>")
        End Sub
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        請輸入基本資料<br />
        姓名：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        血型：<asp:TextBox ID="txtBlood" runat="server"></asp:TextBox>
        <br />
        興趣：<asp:TextBox ID="txtHobby" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="儲存到ViewState狀態中"
            Width="200px" />
        &nbsp;<asp:Button ID="btnRead" runat="server" OnClick="btnRead_Click" Text="讀取ViewState狀態資料"
            Width="200px" />
        <br />
        <br />
        <asp:Label ID="txtMsg" runat="server" ForeColor="Red"></asp:Label>
    </div>
    </form>
</body>
</html>
