<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TreeViewXML.aspx.cs" Inherits="TreeViewXML" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TreeView ID="TreeView1" runat="server" DataSourceID="XmlDataSource1" 
            Font-Size="10pt">
            <DataBindings>
                <asp:TreeNodeBinding DataMember="Root" NavigateUrlField="url" TextField="name" ValueField="describe" />
                <asp:TreeNodeBinding DataMember="Parent" NavigateUrlField="url"
                    ValueField="describe" TextField="name" />
                <asp:TreeNodeBinding DataMember="Child" NavigateUrlField="url" TextField="name" ValueField="describe" />
            </DataBindings>
        </asp:TreeView>
    
    </div>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/Computer.xml"></asp:XmlDataSource>
    </form>
</body>
</html>
