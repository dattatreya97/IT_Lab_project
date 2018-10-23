<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="coordinator.aspx.cs" Inherits="question_bank.coordinator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Questions from faculty"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" AllowPaging="True" PageSize="5">
            <Columns>
               
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:BoundField DataField="Id" HeaderText="Id"  SortExpression="Id" InsertVisible="False" ReadOnly="True" ShowHeader="False" />--%>
                <asp:BoundField DataField="question_name" HeaderText="question_name" SortExpression="question_name" />
                <asp:BoundField DataField="marks" HeaderText="marks" SortExpression="marks" />
                <asp:BoundField DataField="mcq" HeaderText="mcq" SortExpression="mcq" />
                <asp:BoundField DataField="faculty_id" HeaderText="faculty_id" SortExpression="faculty_id" ShowHeader="False" Visible="False" />
                <asp:BoundField DataField="faculty_name" HeaderText="faculty_name" SortExpression="faculty_name" />
                <asp:BoundField DataField="subject" HeaderText="subject" SortExpression="subject" />
                <asp:BoundField DataField="branch" HeaderText="branch" SortExpression="branch" />
                <asp:BoundField DataField="semester" HeaderText="semester" SortExpression="semester" />
                <asp:BoundField DataField="year" HeaderText="year" SortExpression="year" />
            </Columns>
        </asp:GridView>
&nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=mini_project;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Id], [question_name], [marks], [mcq], [faculty_id], [faculty_name], [subject], [branch], [semester], [year] FROM [questions] WHERE (([subject] = @subject)  AND ([branch] = @branch))">
            <SelectParameters>
                <asp:SessionParameter Name="subject" SessionField="subject" Type="String" />
                
                <asp:SessionParameter Name="branch" SessionField="branch" Type="String" />
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
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" DataKeyNames="Id">
            <Columns>
                <asp:CommandField ShowDeleteButton="true"  CausesValidation="false"/>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" InsertVisible="False" ReadOnly="True" Visible="False" />
                <asp:BoundField DataField="question_name" HeaderText="question_name" SortExpression="question_name" />
                <asp:BoundField DataField="marks" HeaderText="marks" SortExpression="marks" />
                <asp:BoundField DataField="mcq" HeaderText="mcq" SortExpression="mcq" />
                <asp:BoundField DataField="subject" HeaderText="subject" SortExpression="subject" />
                <asp:BoundField DataField="branch" HeaderText="branch" SortExpression="branch" />
                <asp:BoundField DataField="semester" HeaderText="semester" SortExpression="semester" />
                <asp:BoundField DataField="year" HeaderText="year" SortExpression="year" />
            </Columns>
        </asp:GridView>
&nbsp;<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=mini_project;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Id], [question_name], [marks], [mcq], [subject], [branch], [semester], [year] FROM [questions_final] WHERE (([subject] = @subject) AND ([branch] = @branch))"
    DeleteCommand="DELETE FROM questions_final WHERE id=@id">
            <SelectParameters>
                <asp:SessionParameter Name="subject" SessionField="subject" Type="String" />
                <asp:SessionParameter Name="branch" SessionField="branch" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
</asp:Content>
