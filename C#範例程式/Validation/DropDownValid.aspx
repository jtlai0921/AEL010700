<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DropDownValid.aspx.cs" Inherits="DropDownValid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .basic
        {
            width: 150px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>DropDownList控制項結合RequiredFieldValidator的運用</h2>
        姓名：<asp:TextBox ID="txtName" runat="server" CssClass="basic"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtName" ErrorMessage="*姓名不可為空白" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        縣市：<asp:DropDownList ID="dwnCity" runat="server" CssClass="basic">
            <asp:ListItem Value="請選擇居住縣市">請選擇居住縣市</asp:ListItem>
            <asp:ListItem>基隆</asp:ListItem>
            <asp:ListItem>台北</asp:ListItem>
            <asp:ListItem>桃園</asp:ListItem>
            <asp:ListItem>新竹</asp:ListItem>
            <asp:ListItem>苗栗</asp:ListItem>
            <asp:ListItem>台中</asp:ListItem>
            <asp:ListItem>彰化</asp:ListItem>
            <asp:ListItem>雲林</asp:ListItem>
            <asp:ListItem>嘉義</asp:ListItem>
            <asp:ListItem>台南</asp:ListItem>
            <asp:ListItem>高雄</asp:ListItem>
            <asp:ListItem>屏東</asp:ListItem>
            <asp:ListItem>花蓮</asp:ListItem>
            <asp:ListItem>台東</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="dwnCity" ErrorMessage="*請選擇您所居住的縣市" 
            InitialValue="請選擇居住縣市" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="btnSumbit" runat="server" onclick="btnSumbit_Click" Text="確定" 
            Width="80px" />
        <br />
        <br />
        <asp:Label ID="txtMsg" runat="server" ForeColor="Red"></asp:Label>
    
    </div>
    </form>
</body>
</html>
