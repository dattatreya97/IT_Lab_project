<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="add_branch.aspx.cs" Inherits="question_bank.add_branch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p class="auto-style1">
        &nbsp;</p>
    <p class="auto-style1">
        <asp:Label ID="Label2" runat="server" Text="Branch"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="branch" runat="server" DataSourceID="SqlDataSource1" DataTextField="branch" DataValueField="branch">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Subject"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="subject" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="subject_vld" runat="server" ControlToValidate="subject" ErrorMessage="Please enter subject name" ValidationGroup="one"></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-warning" OnClick="add_subject" Text="Add subject" ValidationGroup="one" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" OnClick="add_user" Text="Add user" />
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=mini_project;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT DISTINCT [branch] FROM [subjects]"></asp:SqlDataSource>
    </p>
    <p class="auto-style1">
        <asp:Label ID="Label4" runat="server" Text="If branch is not in the list"></asp:Label>
    </p>
    <p class="auto-style1">
        <asp:Label ID="Label5" runat="server" Text="Choose branch"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="branch_new" runat="server">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" Text="Subject"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="subject_new" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" CssClass="btn btn-warning" OnClick="add_branch_name" Text="Add branch" ValidationGroup="two" />
    </p>
    <p class="auto-style1">
        &nbsp;</p>
    <p class="auto-style1">
        <asp:Label ID="result" runat="server" Enabled="False" Text="Label" Visible="False"></asp:Label>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
