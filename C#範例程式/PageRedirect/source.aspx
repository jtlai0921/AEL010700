<%@ Page Language="C#" AutoEventWireup="true" CodeFile="source.aspx.cs" Inherits="source" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Input.jpg" />
        <br />
        請輸入基本資料<br />
    
        姓名：<asp:TextBox ID="txtName" runat="server" Width="150px"></asp:TextBox>
        <br />
        電話：<asp:TextBox ID="txtTel" runat="server" Width="150px"></asp:TextBox>
        <br />
        縣市：<asp:DropDownList ID="dwnCity" runat="server" Width="150px">
            <asp:ListItem Value="0">基隆</asp:ListItem>
            <asp:ListItem Value="1">台北</asp:ListItem>
            <asp:ListItem Value="2">桃園</asp:ListItem>
            <asp:ListItem Value="3">新竹</asp:ListItem>
            <asp:ListItem Value="4">苗栗</asp:ListItem>
            <asp:ListItem Value="5">台中</asp:ListItem>
            <asp:ListItem Value="6">彰化</asp:ListItem>
            <asp:ListItem Value="7">雲林</asp:ListItem>
            <asp:ListItem Value="8">嘉義</asp:ListItem>
            <asp:ListItem Value="9">台南</asp:ListItem>
            <asp:ListItem Value="10">高雄</asp:ListItem>
            <asp:ListItem Value="11">屏東</asp:ListItem>
        </asp:DropDownList>
    
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" Text="確定" />
    
    </div>
    </form>
</body>
</html>
