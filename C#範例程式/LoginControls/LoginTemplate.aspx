<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginTemplate.aspx.cs" Inherits="LoginTemplate" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Login ID="UserLogin" runat="server" BackColor="#FFFBD6" 
            BorderColor="#FFDFAD" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" 
            Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" 
            TextLayout="TextOnTop" FailureText="驗證失敗，請重新輸入帳號密碼" 
            OnLoggedIn="UserLogin_LoggedIn" OnLoggingIn="UserLogin_LoggingIn" 
            OnLoginError="UserLogin_LoginError" Width="344px">
            <LayoutTemplate>
                <div align="center">Login控制項的自訂樣板</div><br />
                <asp:Label ID="lbUserName" runat="server" Text="帳號："></asp:Label>
                <asp:TextBox ID="UserName" runat="server" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV1" runat="server" ControlToValidate="UserName"
                    ErrorMessage="*帳號不可為空白" Enabled="False" Display="Dynamic" 
                    ValidationGroup="LoginGroup">*帳號不可為空白</asp:RequiredFieldValidator><br />
                <asp:Label ID="lbPassword" runat="server" Text="密碼："></asp:Label>
                <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV2" runat="server" ControlToValidate="Password"
                    ErrorMessage="*密碼不可為空白" Enabled="False" Display="Dynamic" 
                    ValidationGroup="LoginGroup">*密碼不可為空白</asp:RequiredFieldValidator><br />
                <asp:CheckBox ID="RememberME" runat="server" Text="記得我" />
                <asp:ImageButton ID="btnLogin" runat="server" CommandName="Login" 
                    ImageUrl="~/Images/LoginImg.png" ValidationGroup="LoginGroup" />&nbsp;<asp:ImageButton
                    ID="btnSignout" runat="server" ImageUrl="~/Images/LogoutImg.png" 
                    OnClick="btnSignout_Click" ValidationGroup="LogoutGroup" />&nbsp;
                <asp:Label ID="txtUserName" runat="server"></asp:Label><br />
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
             </LayoutTemplate>
            <LoginButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px"
                Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
            <TextBoxStyle Font-Size="0.8em" />
            <TitleTextStyle BackColor="#990000" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        </asp:Login>
    </form>
</body>
</html>
