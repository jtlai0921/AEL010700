<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuXML.aspx.cs" Inherits="MenuXML" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Menu ID="Menu1" runat="server" BackColor="#B5C7DE" DataSourceID="XmlDataSource1"
            DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98"
            StaticSubMenuIndent="10px">
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
            <DynamicMenuStyle BackColor="#B5C7DE" />
            <StaticSelectedStyle BackColor="#507CD1" />
            <DynamicSelectedStyle BackColor="#507CD1" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DataBindings>
                <asp:MenuItemBinding DataMember="Root" NavigateUrlField="url" TextField="name" ValueField="describe" />
                <asp:MenuItemBinding DataMember="Parent" NavigateUrlField="url" TextField="name"
                    ValueField="describe" />
                <asp:MenuItemBinding DataMember="Child" NavigateUrlField="url" TextField="name" ValueField="describe" />
            </DataBindings>
            <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
        </asp:Menu>
    
    </div>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/Computer.xml"></asp:XmlDataSource>
    </form>
</body>
</html>
