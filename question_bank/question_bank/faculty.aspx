<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="faculty.aspx.cs" Inherits="question_bank.faculty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 120px;
        }
        .auto-style2 {
            margin-left: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Add Question"></asp:Label>
    </p>
    <p>
        &nbsp;<asp:Label ID="Label3" runat="server" Text="Question"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="question" runat="server" CssClass="offset-sm-0" Width="582px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="question_validator" runat="server" ControlToValidate="question" ErrorMessage="Please enter the question"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Label ID="Label4" runat="server" Text="Marks"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="marks" runat="server">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="marks_validator" runat="server" ControlToValidate="marks" ErrorMessage="Please choose the marks"></asp:RequiredFieldValidator>
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="mcq" runat="server" Text="MCQ" />
    </p>
    <p>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="add_question" Text="Add" />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="result" runat="server" Enabled="False" Text="Label" Visible="False"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label5" runat="server" Text="Questions added"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p class="auto-style2">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-striped" DataSourceID="questions_added">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="question_name" HeaderText="question" SortExpression="question_name" />
                <asp:BoundField DataField="marks" HeaderText="marks" SortExpression="marks" />
                <asp:BoundField DataField="mcq" HeaderText="mcq" SortExpression="mcq" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:SqlDataSource ID="questions_added" runat="server" ConnectionString="Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=mini_project;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [question_name], [marks], [mcq] FROM [questions] WHERE ([faculty_name] = @faculty_name)">
            <SelectParameters>
                <asp:QueryStringParameter Name="faculty_name" QueryStringField="username" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p class="auto-style1">
        &nbsp;</p>
    <p class="auto-style1">
        &nbsp;</p>
</asp:Content>
