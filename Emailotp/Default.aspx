<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Emailotp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <h2>Send Otp to Email and MobileNumber</h2>

    <asp:Label Text="Email:" runat="server" />
    <asp:TextBox ID="txtEmail" runat="server" Width="300px" /> <br /><br />

    <asp:Label Text="MobileNumber:" runat="server" />
    <asp:TextBox ID="txtMobile" runat="server" Width="300px" /> <br /><br />

    <asp:Button ID="Submit" runat="server" text="Send OTP" OnClick="btnSendOTP_Click" /><br /><br />

   <asp:Label Text="Enter OTP" runat="server" />
   <asp:TextBox ID="txtOTP" runat="server" />

   <asp:Button ID="btnVerifyOTP" runat="server" Text="Verify OTP" OnClick="btnVerifyOTP_Click" />

    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Bold="true" />


</asp:Content>

