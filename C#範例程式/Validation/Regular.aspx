<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Regular.aspx.cs" Inherits="Regular" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>RegularExpressionValidator控制項</h2>
        請輸入基本資料<br />
        <br />
        姓名：<asp:TextBox ID="txtName" runat="server" Width="188px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtName" EnableClientScript="False" 
            ErrorMessage="*姓名不得為空白" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
                電子郵件： 
        <asp:TextBox ID="txtMail" runat="server" Width="280px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="txtMail" EnableClientScript="False" 
            ErrorMessage="*電子郵件輸入格式錯誤" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
            ForeColor="Red"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtMail" Display="Dynamic" EnableClientScript="False" 
            ErrorMessage="*電子郵件不得為空白" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" Text="確定" 
            Width="100px" />
        <br />
        <br />
        <asp:Label ID="txtMsg" runat="server" ForeColor="Red"></asp:Label>
    </div>
    </form>
</body>
</html>
