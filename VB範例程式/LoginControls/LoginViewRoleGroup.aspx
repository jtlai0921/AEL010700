<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LoginViewRoleGroup.aspx.vb"
    Inherits="LoginViewRoleGroup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LoginView ID="LoginView1" runat="server">
            <LoggedInTemplate>
                &nbsp;<asp:Label ID="Label1" runat="server" Text="歡迎您"></asp:Label>
                <asp:LoginStatus ID="LoginStatus2" runat="server" LoginImageUrl="~/Images/LoginImg.png"
                    LogoutImageUrl="~/Images/LogoutImg.png" />
            </LoggedInTemplate>
            <AnonymousTemplate>
                &nbsp;<asp:Label ID="Label2" runat="server" Text="請您登入"></asp:Label>
                <asp:LoginStatus ID="LoginStatus1" runat="server" LoginImageUrl="~/Images/LoginImg.png"
                    LogoutImageUrl="~/Images/LogoutImg.png" />
            </AnonymousTemplate>
            <RoleGroups>
                <asp:RoleGroup Roles="Sales">
                    <ContentTemplate>
                        <asp:Label ID="Label3" runat="server" Text="月底銷售全力衝刺!" Width="200px"></asp:Label>
                        <asp:LoginStatus ID="LoginStatus3" runat="server" LoginImageUrl="~/Images/LoginImg.png"
                            LogoutImageUrl="~/Images/LogoutImg.png" />
                    </ContentTemplate>
                </asp:RoleGroup>
                <asp:RoleGroup Roles="MIS">
                    <ContentTemplate>
                        <asp:Label ID="Label4" runat="server" Text="BI系統導入大家多努力!" Width="210px"></asp:Label>
                        <asp:LoginStatus ID="LoginStatus4" runat="server" LoginImageUrl="~/Images/LoginImg.png"
                            LogoutImageUrl="~/Images/LogoutImg.png" />
                    </ContentTemplate>
                </asp:RoleGroup>
                <asp:RoleGroup Roles="RD">
                    <ContentTemplate>
                        <asp:Label ID="Label5" runat="server" Text="新產品加速研發!" Width="200px"></asp:Label>
                        <asp:LoginStatus ID="LoginStatus5" runat="server" LoginImageUrl="~/Images/LoginImg.png"
                            LogoutImageUrl="~/Images/LogoutImg.png" />
                    </ContentTemplate>
                </asp:RoleGroup>
            </RoleGroups>
        </asp:LoginView>
    </div>
    </form>
</body>
</html>
