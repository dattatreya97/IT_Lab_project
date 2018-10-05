<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="question_bank.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style3 {
        margin-left: 400px;
    }
    .auto-style4 {
        margin-left: 520px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <p>
    <br />
</p>
<p class="auto-style3">
    <asp:Label ID="Label1" runat="server" Text="Username" CssClass="label label-default"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="username" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="username_validator" runat="server" ControlToValidate="username" ErrorMessage="Please enter username"></asp:RequiredFieldValidator>
</p>
<p class="auto-style3">
    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="password_validator" runat="server" ControlToValidate="username" ErrorMessage="Please enter password"></asp:RequiredFieldValidator>
</p>
<p class="auto-style3">
    &nbsp;</p>
<p class="auto-style4">
    <asp:Button ID="Button1" runat="server" CssClass="btn-primary focus" Text="Login" OnClick="submit_login" />
</p>
<p>
</p>
<p>
</p>
</asp:Content>

