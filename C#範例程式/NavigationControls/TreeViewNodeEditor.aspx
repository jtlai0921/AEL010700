<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TreeViewNodeEditor.aspx.cs" Inherits="TreeViewNodeEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TreeView ID="TreeView1" runat="server" ShowLines="True" Font-Size="10pt">
            <Nodes>
                <asp:TreeNode NavigateUrl="~/Default.aspx" Text="電腦產品總覽" Value="電腦產品總覽">
                    <asp:TreeNode Text="CPU處理器" Value="CPU處理器">
                        <asp:TreeNode NavigateUrl="~/Intel.aspx" Text="INTEL處理器" Value="INTEL處理器"></asp:TreeNode>
                        <asp:TreeNode Text="AMD處理器" Value="AMD處理器"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="主機板" Value="主機板">
                        <asp:TreeNode NavigateUrl="~/ASUS.aspx" Text="華碩主機板" Value="華碩主機板"></asp:TreeNode>
                        <asp:TreeNode Text="技嘉主機板" Value="技嘉主機板"></asp:TreeNode>
                        <asp:TreeNode NavigateUrl="~/MSI.aspx" Text="微星主機板" Value="微星主機板"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="硬碟" Value="硬碟">
                        <asp:TreeNode NavigateUrl="~/Seagate.aspx" Text="Seagate硬碟" Value="Seagate硬碟"></asp:TreeNode>
                        <asp:TreeNode NavigateUrl="~/Maxtor.aspx" Text="Maxtor硬碟" Value="Maxtor硬碟"></asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
        </asp:TreeView>
    
    </div>
    </form>
</body>
</html>
