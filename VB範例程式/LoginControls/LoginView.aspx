<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LoginView.aspx.vb" Inherits="LoginView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:LoginView ID="LoginView1" runat="server">
                <LoggedInTemplate>
                    <asp:LoginName ID="LoginName1" runat="server" FormatString="歡迎您：{0}" />
                    <asp:LoginStatus ID="LoginStatus1" runat="server" />
                </LoggedInTemplate>
                <AnonymousTemplate>
                    <asp:Label ID="Label2" runat="server" Text="請您登入"></asp:Label>
                    <asp:LoginStatus ID="LoginStatus2" runat="server" 
                        LoginImageUrl="~/Images/LoginImg.png" LogoutImageUrl="~/Images/LogoutImg.png" />
                </AnonymousTemplate>
            </asp:LoginView>
        </div>
    
    </div>
    </form>
</body>
</html>
