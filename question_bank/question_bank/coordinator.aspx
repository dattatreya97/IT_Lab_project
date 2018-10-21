<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="coordinator.aspx.cs" Inherits="question_bank.coordinator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Questions from faculty"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>  
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="question_name" HeaderText="question_name" SortExpression="question_name" />
                <asp:BoundField DataField="marks" HeaderText="marks" SortExpression="marks" />
                <asp:BoundField DataField="mcq" HeaderText="mcq" SortExpression="mcq" />
                <asp:BoundField DataField="faculty_name" HeaderText="faculty_name" SortExpression="faculty_name" />
                <asp:BoundField DataField="year" HeaderText="year" SortExpression="year" />
                <asp:BoundField DataField="subject" HeaderText="subject" SortExpression="subject" />
                <asp:BoundField DataField="branch" HeaderText="branch" SortExpression="branch" />
                <asp:BoundField DataField="semester" HeaderText="semester" SortExpression="semester" />
            </Columns>
        </asp:GridView>
&nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=mini_project;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Id], [question_name], [marks], [mcq], [faculty_name], [year], [faculty_id], [subject], [branch], [semester] FROM [questions] WHERE (([subject] = @subject) AND ([year] = @year))">
            <SelectParameters>
                <asp:SessionParameter Name="subject" SessionField="subject" Type="String" />
                <asp:SessionParameter Name="year" SessionField="year" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        <asp:Button ID="add" runat="server" OnClick="add_questions" Text="Add questions" />
    &nbsp;&nbsp;
        <asp:Label ID="result" runat="server" Enabled="False" Text="Label" Visible="False"></asp:Label>
    </p>
    <p>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Question chosen by you"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
&nbsp;<asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
    </p>
</asp:Content>
