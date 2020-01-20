<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Overloading.aspx.cs" Inherits="Overloading" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="dwnFormat" runat="server" 
            onselectedindexchanged="dwnFormat_SelectedIndexChanged" 
            AutoPostBack="True">
            <asp:ListItem Value="無">==請選擇格式化方式==</asp:ListItem>
            <asp:ListItem Value="一">呼叫多載方法一</asp:ListItem>
            <asp:ListItem Value="二">呼叫多載方法二</asp:ListItem>
            <asp:ListItem Value="三">呼叫多載方法三</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" 
            Width="221px">
        <Columns>
            <asp:TemplateField HeaderText="編號" ItemStyle-Wrap="false">
                <ItemTemplate>
                    <%= i++ %>
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:TemplateField HeaderText="姓名" ItemStyle-Wrap="false">
                <ItemTemplate>
                    <%# Container.DataItem.ToString() %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
