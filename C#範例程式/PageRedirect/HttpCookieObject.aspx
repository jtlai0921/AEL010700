<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HttpCookieObject.aspx.cs"
    Inherits="HttpCookieObject" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/C#" runat="server">
        void Page_PreLoad(object sender, EventArgs e)
        {
            Response.Write("<Img Src='Images/Cookie.jpg' /><BR/>");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        請輸入基本資料<br />
        姓名：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        血型：<asp:TextBox ID="txtBlood" runat="server"></asp:TextBox>
        <br />
        興趣：<asp:TextBox ID="txtHobby" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" 
            Text="儲存到Cookie" Width="150px" />
&nbsp;<asp:Button ID="btnRead" runat="server" onclick="btnRead_Click" Text="讀取Cookie" 
            Width="150px" />
&nbsp;<asp:Button ID="btnReadAll" runat="server" Text="讀取Cookies集合" 
            onclick="btnReadAll_Click" />
        <br />
        <br />
        <asp:Label ID="txtMsg" runat="server" ForeColor="Red"></asp:Label>
    
    </div>
    </form>
</body>
</html>
