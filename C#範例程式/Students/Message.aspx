<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="Message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #content
        {
            height:450px;
        }
        
        #message
        {
            width: 300px;
            margin-left: auto;
            margin-right: auto;
            margin-top:150px;
            background-color: lightgreen;
            font-size: 16px;
            padding-top: 10px;
            padding-bottom: 10px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            //讀取Page內容的高度
            var x = $("#page").height();
            //讀取Login控制項的高度
            var y = $("#message").height();
            //計算Offset
            var offsetTop = (x - y) / 2 - 30;
            //設定Login控制項Offset位移
            $("#message").css("margin-top", offsetTop);
        })
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="message" style="text-align: center">
        你不具備使用該功能之權限！<br />
        請洽詢系統管理者<br />
        <asp:Label ID="txtMsg" runat="server" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>


