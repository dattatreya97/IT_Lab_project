<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="paper.aspx.cs" Inherits="question_bank.paper" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Branch" CssClass="labelinfo"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="branch" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="branch" DataValueField="branch">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=mini_project;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT DISTINCT [branch] FROM [questions_final]"></asp:SqlDataSource>
    </p>
    <p class="auto-style1">
        <asp:Label ID="Label3" runat="server" Text="Subject" CssClass="labelinfo"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="subject" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="subject" DataValueField="subject">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=mini_project;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT DISTINCT [subject] FROM [questions_final] WHERE ([branch] = @branch)">
            <SelectParameters>
                <asp:ControlParameter ControlID="branch" Name="branch" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <p class="auto-style1">
        <asp:Label ID="Label4" runat="server" Text="Semester" CssClass="labelinfo"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="semester" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="semester" DataValueField="semester">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=mini_project;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT DISTINCT [semester] FROM [questions_final] WHERE (([branch] = @branch) AND ([subject] = @subject))">
            <SelectParameters>
                <asp:ControlParameter ControlID="branch" Name="branch" PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="subject" Name="subject" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <p class="auto-style1">
        <asp:Label ID="Label5" runat="server" Text="Year" CssClass="labelinfo"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="year" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource4" DataTextField="year" DataValueField="year">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=mini_project;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT DISTINCT [year] FROM [questions_final] WHERE (([branch] = @branch) AND ([subject] = @subject) AND ([semester] = @semester))">
            <SelectParameters>
                <asp:ControlParameter ControlID="branch" Name="branch" PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="subject" Name="subject" PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="semester" Name="semester" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <p class="auto-style1">
        &nbsp;</p>
    <p class="auto-style1">
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource5">
        </asp:GridView>
    </p>
    <p class="auto-style1">
        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=mini_project;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [question_name], [marks], [mcq] FROM [questions_final] WHERE (([branch] = @branch) AND ([semester] = @semester) AND ([subject] = @subject) AND ([year] = @year))">
            <SelectParameters>
                <asp:ControlParameter ControlID="branch" Name="branch" PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="semester" Name="semester" PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="subject" Name="subject" PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="year" Name="year" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
</asp:Content>
