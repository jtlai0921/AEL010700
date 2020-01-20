<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PhotoUpload.aspx.cs" Inherits="PhotoUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #content
        {
            height: 450px;
        }
        
        #content ol
        {
            padding: 10px 0 0 50px;
        }
        
        input[type=file]
        {
            width: 600px;
            background-color: LightBlue;
        }
        
        input[type=file]:hover
        {
            background-color: pink;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <font size="5" style="font-weight: bold">
        <ol id="first">
            學生照片上傳</ol>
    </font>
    <ol id="second">
        <li>
            <asp:FileUpload ID="FileUpload1" runat="server" /></li>
        <li>
            <asp:FileUpload ID="FileUpload2" runat="server" /></li>
        <li>
            <asp:FileUpload ID="FileUpload3" runat="server" /></li>
        <li>
            <asp:FileUpload ID="FileUpload4" runat="server" /></li>
        <li>
            <asp:FileUpload ID="FileUpload5" runat="server" /></li>
        <li>
            <asp:FileUpload ID="FileUpload6" runat="server" /></li>
        <li>
            <asp:FileUpload ID="FileUpload7" runat="server" /></li>
        <li>
            <asp:FileUpload ID="FileUpload8" runat="server" /></li>
        <li>
            <asp:FileUpload ID="FileUpload9" runat="server" /></li>
        <li>
            <asp:FileUpload ID="FileUpload10" runat="server" /></li>
    </ol>
    <ol id="third">
        <asp:ImageButton ID="btnUpload" runat="server" Text="圖片上傳" Width="100px" 
            ImageUrl="~/images/UploadButton.png" onclick="btnUpload_Click" />
        <br />
        <asp:Label ID="txtMsg" runat="server"></asp:Label>
    </ol>
</asp:Content>
