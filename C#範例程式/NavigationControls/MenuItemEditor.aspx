<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuItemEditor.aspx.cs" Inherits="MenuItemEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Menu ID="Menu1" runat="server">
            <Items>
                <asp:MenuItem Text="電腦產品總覽" Value="電腦產品總覽">
                    <asp:MenuItem Text="CPU" Value="CPU">
                        <asp:MenuItem NavigateUrl="~/INTEL.aspx" Text="INTEL" Value="INTEL"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/AMD.aspx" Text="AMD" Value="AMD"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="主機板" Value="主機板">
                        <asp:MenuItem Text="華碩" Value="華碩"></asp:MenuItem>
                        <asp:MenuItem Text="技嘉" Value="技嘉"></asp:MenuItem>
                        <asp:MenuItem Text="微星" Value="微星"></asp:MenuItem>
                    </asp:MenuItem>
                    <asp:MenuItem Text="硬碟" Value="硬碟">
                        <asp:MenuItem Text="Seagate" Value="Seagate"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Maxtor.aspx" Text="Maxtor" Value="Maxtor"></asp:MenuItem>
                    </asp:MenuItem>
                </asp:MenuItem>
            </Items>
        </asp:Menu>
    
    </div>
    </form>
</body>
</html>
