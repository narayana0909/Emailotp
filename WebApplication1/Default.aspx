<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="txtMobile" runat="server" Width="300px" placeholder="Enter Mobile Number" /><br /><br />
    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Rows="4" Columns="50" placeholder="Enter your message" /><br /><br />
    <asp:Button ID="btnSend" runat="server" Text="Send Message" OnClick="btnSendMessage_Click" /><br /><br />
    <asp:Label ID="lblMessages" runat="server" ForeColor="Red" />
</asp:Content>
