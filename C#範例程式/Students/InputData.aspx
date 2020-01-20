<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InputData.aspx.cs" Inherits="InputData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="Scripts/jquery-ui-1.8.1.custom.min.js" type="text/javascript"></script>
    <link href="css/ui-lightness/jquery-ui-1.8.1.custom.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #dvStudent
        {
            margin-left: auto;
            margin-right: auto;
        }
        
        input[type=Text]:hover
        {
            background-color: pink;
        }
        
        #rdoGender Label
        {
            padding: 0 6px 0 3px;
        }
        
        #rdoBlood Label
        {
            padding: 0 6px 0 3px;
        }
        
        #message
        {
            width: 740px;
            margin-left: auto;
            margin-right: auto;
            margin-top: 5px;
        }
        
        #message li
        {
            display: inline;
            padding: 0 5px 0 5px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("#txtBirthday").datepicker({ dateFormat: 'yy/mm/dd' });
            $("#txtBirthday")[0].onmouseover = function () { $("#txtBirthday").css("background-color", "LightBlue"); }
            $("#txtBirthday")[0].onmouseout = function () { $("#txtBirthday").css("background-color", "white"); }

            $("#content").css("padding-top", "10px");
        });

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:DetailsView ID="dvStudent" runat="server" AutoGenerateRows="False" CellPadding="4"
        DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="#333333" Height="50px"
        Width="740px" ClientIDMode="Static" DefaultMode="Insert" Font-Size="10pt" 
        HeaderText="&lt;div align='center'&gt;學生基本資料新增&lt;/div&gt;" 
        oniteminserted="dvStudent_ItemInserted" 
        oniteminserting="dvStudent_ItemInserting">
        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="#FFFFC0" Font-Bold="True" />
        <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True" />
        <Fields>
            <asp:TemplateField HeaderText="ID" SortExpression="ID">
                <InsertItemTemplate>
                    <asp:TextBox ID="txtID" runat="server" Text='<%# Bind("ID") %>' MaxLength="15"></asp:TextBox>
                </InsertItemTemplate>
                <ControlStyle Width="200px" />
                <HeaderStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="姓名" SortExpression="Name">
                <InsertItemTemplate>
                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>' MaxLength="10"></asp:TextBox>
                </InsertItemTemplate>
                <ControlStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="性別">
                <InsertItemTemplate>
                    <asp:RadioButtonList ID="rdoGender" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoGender_SelectedIndexChanged"
                        ToolTip='<%# Bind("Gender") %>'>
                        <asp:ListItem Value="1">男</asp:ListItem>
                        <asp:ListItem Value="0">女</asp:ListItem>
                    </asp:RadioButtonList>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="生日" SortExpression="Birthday">
                <InsertItemTemplate>
                    <asp:TextBox ID="txtBirthday" runat="server" ClientIDMode="Static" Text='<%# Bind("Birthday") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ControlStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="血型" SortExpression="Blood">
                <InsertItemTemplate>
                    <asp:RadioButtonList ID="rdoBlood" runat="server" CellSpacing="5" RepeatDirection="Horizontal"
                        OnSelectedIndexChanged="rdoBlood_SelectedIndexChanged" ToolTip='<%# Bind("Blood") %>'>
                        <asp:ListItem Value="A">A</asp:ListItem>
                        <asp:ListItem>B</asp:ListItem>
                        <asp:ListItem>AB</asp:ListItem>
                        <asp:ListItem>O</asp:ListItem>
                        <asp:ListItem>RH</asp:ListItem>
                    </asp:RadioButtonList>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Blood") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="身高" SortExpression="Height">
                <InsertItemTemplate>
                    <asp:DropDownList ID="dwnHeight" runat="server" OnSelectedIndexChanged="dwnHeight_SelectedIndexChanged"
                        ToolTip='<%# Bind("Height") %>'>
                    </asp:DropDownList>
                    &nbsp;cm
                </InsertItemTemplate>
                <ControlStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="體重" SortExpression="Weight">
                <InsertItemTemplate>
                    <asp:DropDownList ID="dwnWeight" runat="server" OnSelectedIndexChanged="dwnWeight_SelectedIndexChanged"
                        ToolTip='<%# Bind("Weight") %>'>
                    </asp:DropDownList>
                    &nbsp;Kg
                </InsertItemTemplate>
                <ControlStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="縣市" SortExpression="City">
                <InsertItemTemplate>
                    <asp:DropDownList ID="dwnCity" runat="server" DataSourceID="XmlDataSource1" Height="18px"
                        AppendDataBoundItems="True" DataTextField="CityName" DataValueField="CityID"
                        ToolTip="<%# Bind('City') %>" 
                        OnSelectedIndexChanged="dwnCity_SelectedIndexChanged">
                        <asp:ListItem Value="0">=請選擇=</asp:ListItem>
                    </asp:DropDownList>
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="地址" SortExpression="Address">
                <InsertItemTemplate>
                    <asp:TextBox ID="txtAddress" runat="server" Text='<%# Bind("Address") %>' MaxLength="255"></asp:TextBox>
                </InsertItemTemplate>
                <ControlStyle Width="600px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="電話" SortExpression="Tel">
                <InsertItemTemplate>
                    <asp:TextBox ID="txtTel" runat="server" Text='<%# Bind("Tel") %>' MaxLength="15"></asp:TextBox>
                </InsertItemTemplate>
                <ControlStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="照片檔名" SortExpression="PhotoUrl">
                <InsertItemTemplate>
                    <asp:TextBox ID="txtPhotoUrl" runat="server" Text='<%# Bind("PhotoUrl") %>' MaxLength="255"></asp:TextBox>
                </InsertItemTemplate>
                <ControlStyle Width="600px" />
            </asp:TemplateField>
            <asp:CommandField ShowInsertButton="True" ButtonType="Button">
                <ItemStyle BackColor="#CC3300" />
            </asp:CommandField>
        </Fields>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#FF9900" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#CCFF99" ForeColor="#333333" />
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SchoolConnectionString %>"
        SelectCommand="SELECT * FROM [Students]" DeleteCommand="DELETE FROM [Students] WHERE [ID] = @ID"
        InsertCommand="INSERT INTO [Students] ([ID], [Name], [Gender], [Birthday], [Blood], [Height], [Weight], [City], [Address], [Tel], [PhotoUrl]) VALUES (@ID, @Name, @Gender, @Birthday, @Blood, @Height, @Weight, @City, @Address, @Tel, @PhotoUrl)"
        UpdateCommand="UPDATE [Students] SET [Name] = @Name, [Gender] = @Gender, [Birthday] = @Birthday, [Blood] = @Blood, [Height] = @Height, [Weight] = @Weight, [City] = @City, [Address] = @Address, [Tel] = @Tel, [PhotoUrl] = @PhotoUrl WHERE [ID] = @ID">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ID" Type="String" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Gender" Type="Boolean" />
            <asp:Parameter DbType="DateTime2" Name="Birthday" />
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
            <asp:Parameter DbType="DateTime2" Name="Birthday" />
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
    <div id="message">
        <asp:Label ID="txtMsg" runat="server" ForeColor="#3333FF"></asp:Label>
    </div>
</asp:Content>
