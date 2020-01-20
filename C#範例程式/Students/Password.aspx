<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Password.aspx.cs" Inherits="Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #content
        {
            height:450px;
        }
        
        #content Table
        {
            margin-left: auto;
            margin-right: auto;
            margin-top: 30px;
            border-style: solid;
            border-color: Black;
        }
        
        #content Table tr td
        {
            padding: 0 0 0 10px;
        }
        
        input[type=Password]:hover
        {
            background-color: pink;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:DetailsView ID="dvAccount" runat="server" Height="50px" Width="300px" AutoGenerateRows="False"
        CellPadding="4" DataKeyNames="ID" DataSourceID="sqlPassword" ForeColor="#333333"
        HeaderText="&lt;div align='Center'&gt;密碼變更&lt;/div&gt;" DefaultMode="Edit">
        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
        <EditRowStyle BackColor="#2461BF" />
        <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="ID" HeaderText="帳號" ReadOnly="True" SortExpression="ID">
                <ItemStyle ForeColor="White" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="新密碼" SortExpression="Password">
                <EditItemTemplate>
                    <asp:TextBox ID="txtPassword" runat="server" MaxLength="12" Text='<%# Bind("Password") %>'
                        TextMode="Password" ToolTip="輸入新密碼後按更新按鈕"></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ButtonType="Button" ShowEditButton="True" />
        </Fields>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="Red" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
    </asp:DetailsView>
    <asp:SqlDataSource ID="sqlPassword" runat="server" ConnectionString="<%$ ConnectionStrings:SchoolConnectionString %>"
        SelectCommand="SELECT Top 1 [ID], [Password] FROM [UserAccount] Where ID=@paramID"
        
        UpdateCommand="UPDATE [UserAccount] SET [Password] = @Password WHERE [ID] = @ID" 
        onupdated="sqlPassword_Updated">
        <SelectParameters>
            <asp:Parameter Name="paramID" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="Password" Type="String" />
            <asp:Parameter Name="ID" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
