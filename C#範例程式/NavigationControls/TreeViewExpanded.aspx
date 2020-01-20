<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TreeViewExpanded.aspx.cs" Inherits="TreeViewExpanded" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>TreeView節點摺疊與展開事件</h2>
        <asp:TreeView ID="tvProduct" runat="server" BorderColor="Black" BorderStyle="Dashed"
            DataSourceID="SiteMapDataSource1" ImageSet="XPFileExplorer" NodeIndent="15"
            OnTreeNodeCollapsed="tvProduct_TreeNodeCollapsed" OnTreeNodeExpanded="tvProduct_TreeNodeExpanded"
            ShowCheckBoxes="Leaf" ShowLines="True" Width="200px">
            <ParentNodeStyle Font-Bold="False" />
            <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
            <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
                VerticalPadding="0px" />
            <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
                NodeSpacing="0px" VerticalPadding="2px" />
        </asp:TreeView>
    
    </div>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        &nbsp;&nbsp;<br />
        <br />
    </form>
</body>
</html>
