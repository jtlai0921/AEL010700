<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginView.aspx.cs" Inherits="LoginView" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LoginView ID="LoginView1" runat="server">
            <LoggedInTemplate>
                <asp:LoginName ID="LoginName1" runat="server" FormatString="歡迎您：{0}" />
                <asp:LoginStatus ID="LoginStatus1" runat="server" 
                    LoginImageUrl="~/Images/LoginImg.png" LogoutImageUrl="~/Images/LogoutImg.png" />
            </LoggedInTemplate>
            <AnonymousTemplate>
                <asp:Label ID="Label2" runat="server" Text="請您登入"></asp:Label>
                <asp:LoginStatus ID="LoginStatus2" runat="server" 
                    LoginImageUrl="~/Images/LoginImg.png" LogoutImageUrl="~/Images/LogoutImg.png" />
            </AnonymousTemplate>
        </asp:LoginView>
        </div>
    </form>
</body>
</html>
