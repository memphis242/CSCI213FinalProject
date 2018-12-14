<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="ScheduleManagment.Email" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style3 {
        color: #009933;
        font-size: xx-large;
    }
    .auto-style4 {
        font-size: xx-large;
    }
    .auto-style5 {
        color: #006600;
    }
    .auto-style6 {
        color: #CC9900;
    }
    .auto-style7 {
        height: 30px;
    }
    .auto-style8 {
            width: 761px;
        }
    .auto-style9 {
        height: 30px;
        width: 761px;
    }
        .auto-style12 {
            width: 311px;
            height: 144px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="auto-style4"><span class="auto-style5">(NSASMS)&nbsp; </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
<asp:HyperLink ID="HyperLink1" runat="server" CssClass="auto-style3" NavigateUrl="~/HomePage.aspx">Home</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LoginStatus ID="LoginStatus1" runat="server" CssClass="auto-style4" />
<br />
<br />
<br />
<h2 class="auto-style6">Current Messages</h2>
<table style="width:100%;">
    <tr>
        <td class="auto-style8">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" DataKeyNames="Id,From,Body">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" InsertVisible="False" ReadOnly="True" Visible="False" />
                    <asp:BoundField DataField="To" HeaderText="To" SortExpression="To" Visible="False" />
                    <asp:BoundField DataField="From" HeaderText="From" SortExpression="From" />
                    <asp:BoundField DataField="Body" HeaderText="Body" SortExpression="Body" />
                </Columns>
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#330099" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                <SortedAscendingCellStyle BackColor="#FEFCEB" />
                <SortedAscendingHeaderStyle BackColor="#AF0101" />
                <SortedDescendingCellStyle BackColor="#F6F0C0" />
                <SortedDescendingHeaderStyle BackColor="#7E0000" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" SelectCommand="SELECT * FROM [MessageTable] WHERE ([To] = @To)" DeleteCommand="DELETE FROM [MessageTable] WHERE [Id] = @Id" InsertCommand="INSERT INTO [MessageTable] ([To], [From], [Body]) VALUES (@To, @From, @Body)" UpdateCommand="UPDATE [MessageTable] SET [To] = @To, [From] = @From, [Body] = @Body WHERE [Id] = @Id">
                <DeleteParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="To" Type="String" />
                    <asp:Parameter Name="From" Type="String" />
                    <asp:Parameter Name="Body" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:SessionParameter Name="To" SessionField="userName" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="To" Type="String" />
                    <asp:Parameter Name="From" Type="String" />
                    <asp:Parameter Name="Body" Type="String" />
                    <asp:Parameter Name="Id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </td>
        <td>
            &nbsp;</td>
        <td>
            <asp:Label ID="Label1" runat="server" Text="To :"></asp:Label>
&nbsp;
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Height="16px"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Message :"></asp:Label>
            <br />
            <textarea id="TextArea1" class="auto-style12" name="S1" spellcheck="true" runat="server"></textarea></td>
    </tr>
    <tr>
        <td class="auto-style9">
            <asp:Button ID="Button2" runat="server" Text="Reply to Message" OnClick="Button2_Click" />
            <br />
        </td>
        <td class="auto-style7"></td>
        <td class="auto-style7">
            <asp:Button ID="Button3" runat="server" Text="Send New Message" OnClick="Button3_Click" />
        </td>
    </tr>
    <tr>
        <td class="auto-style8">
            <asp:Button ID="Button1" runat="server" Text="Delete Message" OnClick="Button1_Click" />
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
<br class="auto-style2" />
<br class="auto-style2" />
<br class="auto-style2" />
<asp:HyperLink ID="HyperLink2" runat="server" CssClass="auto-style2" NavigateUrl="~/Scheduler/Scheduler.aspx">Schedule</asp:HyperLink>
</asp:Content>
