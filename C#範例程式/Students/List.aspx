<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="Scripts/jquery-ui-1.8.1.custom.min.js" type="text/javascript"></script>
    <link href="css/ui-lightness/jquery-ui-1.8.1.custom.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #Content2
        {
            min-height:900px !important;
        }
        #content Table
        {
            margin-left: auto;
            margin-right: auto;
            margin-top: 15px;
            max-width: 800px;
        }
        
        Input[type=image]
        {
            padding: 0 3px 0 3px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("input[id$=txtBirthday]").datepicker({ dateFormat: 'yy/mm/dd' });
            /*mouseover and mouseout事件*/
            $("Table Tr:gt(0):even").mouseover(function (event) {
                $(this).css("background-color", "Pink");
            })

            $("Table Tr:gt(0):even").mouseout(function (event) {
                $(this).css("background-color", "inherit");
            })

            $("Table Tr:gt(0):odd").mouseover(function (event) {
                $(this).css("background-color", "LightBlue");
            })

            $("Table Tr:gt(0):odd").mouseout(function (event) {
                $(this).css("background-color", "inherit");
            })
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
        BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="ID" DataSourceID="SqlDataSource1"
        ForeColor="Black" AllowPaging="True" AllowSorting="True" Font-Size="10pt" Width="740px"
        Caption="&lt;div style='background-color:Orange'&gt;學生資料瀏覽與維護&lt;/div&gt;" 
        PageSize="6" ondatabound="gvStudents_DataBound" 
        onrowdatabound="gvStudents_RowDataBound" onrowediting="gvStudents_RowEditing">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:Button ID="btnUpdate" runat="server" CausesValidation="True" CommandName="Update"
                        Text="更新" />
                    &nbsp;<asp:Button ID="btnCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="取消" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" CausesValidation="False" CommandName="Edit"
                        Text="編輯" />
                    &nbsp;<asp:Button ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="刪除" OnClientClick="return confirm('確定要刪除此筆資料？');" />
                </ItemTemplate>
                <ItemStyle Wrap="False" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ID" SortExpression="ID">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="姓名">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="性別" SortExpression="Gender">
                <EditItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Gender") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="txtGender" runat="server" Text='<%# Eval("Gender") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="30px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="生日" SortExpression="Birthday">
                <EditItemTemplate>
                    <asp:TextBox ID="txtBirthday" runat="server" ClientIDMode="Static" Height="21px"
                        Text='<%# Bind("Birthday") %>' Width="79px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Birthday", "{0:d}") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="血型" SortExpression="Blood">
                <EditItemTemplate>
                    <asp:DropDownList ID="dwnBlood" runat="server" OnSelectedIndexChanged="dwnBlood_SelectedIndexChanged"
                        ToolTip='<%# Bind("Blood") %>'>
                        <asp:ListItem Value="0">==</asp:ListItem>
                        <asp:ListItem Value="1">A</asp:ListItem>
                        <asp:ListItem Value="2">B</asp:ListItem>
                        <asp:ListItem Value="3">AB</asp:ListItem>
                        <asp:ListItem Value="4">O</asp:ListItem>
                        <asp:ListItem Value="5">RH</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Blood") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="身高" SortExpression="Height">
                <EditItemTemplate>
                    <asp:DropDownList ID="dwnHeight" runat="server" OnLoad="dwnHeight_Load" OnSelectedIndexChanged="dwnHeight_SelectedIndexChanged"
                        ToolTip='<%# Bind("Height") %>'>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Height") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="30px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="體重" SortExpression="Weight">
                <EditItemTemplate>
                    <asp:DropDownList ID="dwnWeight" runat="server" OnLoad="dwnWeight_Load" OnSelectedIndexChanged="dwnWeight_SelectedIndexChanged"
                        ToolTip='<%# Bind("Weight") %>'>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Weight") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="30px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="縣市" SortExpression="City">
                <EditItemTemplate>
                    <asp:DropDownList ID="dwnCity" runat="server" AppendDataBoundItems="True" DataSourceID="XmlDataSource1"
                        DataTextField="CityName" DataValueField="CityID" Height="18px" OnSelectedIndexChanged="dwnCity_SelectedIndexChanged"
                        ToolTip="<%# Bind('City') %>">
                        <asp:ListItem Value="0">==</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="30px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="地址" SortExpression="Address">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="電話" SortExpression="Tel">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Tel") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("Tel") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="60px" />
            </asp:TemplateField>
            <asp:ImageField DataImageUrlField="PhotoUrl" DataImageUrlFormatString="Photos/{0}"
                HeaderText="照片">
                <ControlStyle Height="30px" Width="30px" />
            </asp:ImageField>
        </Columns>
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerSettings FirstPageImageUrl="~/images/First.gif" LastPageImageUrl="~/images/Last.gif"
            Mode="NextPreviousFirstLast" NextPageImageUrl="~/images/Next.gif" PreviousPageImageUrl="~/images/Previous.gif" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <SortedAscendingCellStyle BackColor="#FAFAE7" />
        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
        <SortedDescendingCellStyle BackColor="#E1DB9C" />
        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SchoolConnectionString %>"
        SelectCommand="SELECT ID, Name, Gender, CAST(Birthday AS Nvarchar(10)) AS Birthday, Blood, Height, Weight, City, Address, Tel, PhotoUrl FROM Students"
        DeleteCommand="DELETE FROM [Students] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Students] ([ID], [Name], [Gender], [Birthday], [Blood], [Height], [Weight], [City], [Address], [Tel], [PhotoUrl]) VALUES (@ID, @Name, @Gender, @Birthday, @Blood, @Height, @Weight, @City, @Address, @Tel, @PhotoUrl)"
        UpdateCommand="UPDATE [Students] SET [Name] = @Name, [Gender] = @Gender, [Birthday] = @Birthday, [Blood] = @Blood, [Height] = @Height, [Weight] = @Weight, [City] = @City, [Address] = @Address, [Tel] = @Tel, [PhotoUrl] = @PhotoUrl WHERE [ID] = @ID">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ID" Type="String" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Gender" Type="Boolean" />
            <asp:Parameter Name="Birthday" DbType="DateTime2" />
            <asp:Parameter Name="Blood" Type="String" />
            <asp:Parameter Name="Height" Type="Int32" />
            <asp:Parameter Name="Weight" Type="Int32" />
            <asp:Parameter Name="City" Type="String" />
            <asp:Parameter Name="Address" Type="String" />
            <asp:Parameter Name="Tel" Type="String" />
            <asp:Parameter Name="PhotoUrl" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Gender" Type="Boolean" />
            <asp:Parameter Name="Birthday" DbType="DateTime2" />
            <asp:Parameter Name="Blood" Type="String" />
            <asp:Parameter Name="Height" Type="Int32" />
            <asp:Parameter Name="Weight" Type="Int32" />
            <asp:Parameter Name="City" Type="String" />
            <asp:Parameter Name="Address" Type="String" />
            <asp:Parameter Name="Tel" Type="String" />
            <asp:Parameter Name="PhotoUrl" Type="String" />
            <asp:Parameter Name="ID" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/Cities.xml" CacheExpirationPolicy="Sliding">
    </asp:XmlDataSource>
</asp:Content>