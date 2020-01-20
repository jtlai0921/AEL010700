<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ValidationGroup.aspx.cs"
    Inherits="ValidationGroup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .column
        {
            border-style: double solid solid solid;
            border-width: 3px 1px 1px 1px;
            border-color: #CC0000;
            height: 250px;
            width: 300px;
            float: left;
            margin:0px 20px 0px 0px;
            background-color: #ADD8E6;
            padding: 10px;
        }
        
        fieldset
        {
            height: 230px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <h2>ValidationGroup驗證群組</h2>
    <div class="column">
        <fieldset>
            <legend>註冊</legend>姓名：<br />
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="rvName" runat="server" 
                ControlToValidate="txtName" ErrorMessage="*姓名必須輸入，不得為空白" 
                ValidationGroup="RegisterGroup">*必須輸入</asp:RequiredFieldValidator>
            <br />
            電子郵件：<br />
            <asp:TextBox ID="txtMail" runat="server" Width="250px"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="rvMail" runat="server" 
                ControlToValidate="txtMail" ErrorMessage="*電子郵件必須輸入，不得為空白" 
                ValidationGroup="RegisterGroup">*必須輸入</asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="btnRegister" runat="server" Text="註冊" Width="100px" 
                ValidationGroup="RegisterGroup" />
        </fieldset>
    </div>
    <div class="column">
        <fieldset>
            <legend>登入</legend>帳號：<br />
            <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="rvLogin" runat="server" 
                ControlToValidate="txtID" ErrorMessage="*帳號必須輸入，不得為空白" 
                ValidationGroup="LoginGroup">*必須輸入</asp:RequiredFieldValidator>
            <br />
            密碼：
             
            <br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="rvPassword" runat="server" 
                ControlToValidate="txtPassword" ErrorMessage="*密碼必須輸入，不得為空白" 
                ValidationGroup="LoginGroup">*必須輸入</asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="登入" Width="100px" 
                ValidationGroup="LoginGroup" />
        </fieldset>        
    </div>
    <div style="float: inherit;width:300px" >
        <asp:ValidationSummary ID="Summary1" runat="server" 
            DisplayMode="List" ValidationGroup="RegisterGroup" ForeColor="Red" />
        <asp:ValidationSummary ID="Summary2" runat="server" DisplayMode="List" 
            ValidationGroup="LoginGroup" ForeColor="Red" />
    </div>
    </form>

</body>
</html>
