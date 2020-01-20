<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RequiredFieldBasic.aspx.cs"
    Inherits="RequiredFieldBasic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>
        RequiredFieldValidator驗證控制項</h2>
        姓名：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtName" ErrorMessage="*姓名不可為空白" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        電話：<asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtTel" ErrorMessage="*電話不可為空白" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="btnSumbit" runat="server" onclick="btnSumbit_Click" Text="確定" 
            Width="100px" />
        <br />
        <br />
        <asp:Label ID="txtMsg" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
