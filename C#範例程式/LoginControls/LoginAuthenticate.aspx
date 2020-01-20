<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginAuthenticate.aspx.cs"
    Inherits="LoginAuthenticate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        Table[Title=登入控制項]
        {
            margin-left: auto;
            margin-right: auto;
            margin-top: 150px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Login ID="userLogin" runat="server" OnAuthenticate="Login1_Authenticate" BackColor="#FFFBD6"
            BorderColor="#FFDFAD" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px"
            Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" TextLayout="TextOnTop"
            DestinationPageUrl="~/LoginMessage.aspx" ToolTip="登入控制項">
            <LoginButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px"
                Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
            <TextBoxStyle Font-Size="0.8em" />
            <TitleTextStyle BackColor="#990000" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        </asp:Login>
    </div>
    </form>
</body>
</html>
