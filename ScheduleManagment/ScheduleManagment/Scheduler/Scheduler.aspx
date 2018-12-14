<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Scheduler.aspx.cs" Inherits="ScheduleManagment.Scheduler" %>
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
            width: 217px;
        }
        .auto-style7 {
            color: #CCCC00;
        }
        .auto-style8 {
            width: 217px;
            height: 42px;
        }
        .auto-style9 {
            height: 42px;
        }
        .auto-style10 {
            height: 42px;
            width: 251px;
        }
        .auto-style11 {
            width: 251px;
        }
        .auto-style12 {
            width: 191px;
            height: 42px;
        }
        .auto-style13 {
            width: 191px;
        }
        .auto-style14 {
            width: 191px;
            text-align: center;
        }
        .auto-style15 {
            width: 128px;
            height: 42px;
        }
        .auto-style16 {
            width: 128px;
        }
        .auto-style17 {
            width: 158px;
            height: 42px;
        }
        .auto-style18 {
            width: 158px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="auto-style4"><span class="auto-style5">(NSASMS)</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
<asp:HyperLink ID="HyperLink1" runat="server" CssClass="auto-style3" NavigateUrl="~/HomePage.aspx">Home</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LoginStatus ID="LoginStatus1" runat="server" CssClass="auto-style4" />
<br />
<table style="width:100%;">
    <tr>
        <td class="auto-style8">
            <asp:Label ID="lblAdvisorName" runat="server" Text="Advisor/Students Name(s)"></asp:Label>
        </td>
        <td class="auto-style15">
            &nbsp;</td>
        <td class="auto-style17">
            &nbsp;</td>
        <td class="auto-style10"></td>
        <td class="auto-style12">
            <asp:TextBox ID="DebugTextBox" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style9">&nbsp;</td>
        <td class="auto-style9">&nbsp;</td>
        <td class="auto-style9">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">
            <h2 class="auto-style7">
                <asp:DropDownList ID="StudentsDropDownList" runat="server" Height="22px" Width="208px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
            </h2>
            <h2 class="auto-style7">Scheduled Meetings&nbsp;</h2>
        </td>
        <td class="auto-style16">
            &nbsp;</td>
        <td class="auto-style18">
            &nbsp;</td>
        <td class="auto-style11">&nbsp;</td>
        <td class="auto-style13">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">
            &nbsp;</td>
        <td class="auto-style16">
            &nbsp;</td>
        <td class="auto-style18">
            &nbsp;</td>
        <td class="auto-style11">
            &nbsp;</td>
        <td class="auto-style14">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">
    <asp:Button ID="CancelMeetingButton" runat="server" Text="Cancel Meeting" OnClick="CancelMeetingButton_Click" />
        </td>
        <td class="auto-style16">
            &nbsp;</td>
        <td class="auto-style18">
    <asp:Button ID="RescheduleButton" runat="server" Text="Reschedule" OnClick="RescheduleButton_Click" />
        </td>
        <td class="auto-style11">
            &nbsp;</td>
        <td class="auto-style14">
            <asp:Button ID="ChangeAvailabilityButton" runat="server" Height="26px" Text="Change Availiability" OnClick="ChangeAvailabilityButton_Click" />
        </td>
        <td>
            <asp:Label ID="unavailableStatus" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Button ID="ScheduleNewButton" runat="server" Text="Schedule New Meeting" OnClick="ScheduleNewButton_Click" />
        </td>
        <td>
            <asp:Label ID="newAppStatus" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">
            <asp:GridView ID="AppointmentsGridView" runat="server" AutoGenerateColumns="True" DataKeyNames="AppointmentID"></asp:GridView>
        </td>
        <td class="auto-style16">
            <br />
            <br />
            <asp:Label ID="Label9" runat="server" Text="New Date"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label10" runat="server" Text="New Time"></asp:Label>
            <br />
            <br />
            <br />
            <br />
        </td>
        <td class="auto-style18">
            <br />
            <br />
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
        </td>
        <td class="auto-style11">
            <br />
            <br />
            <asp:GridView ID="WeeklyScheduleGridView" runat="server" OnSelectedIndexChanged="WeeklyScheduleGridView_SelectedIndexChanged">
            </asp:GridView>
            <br />
            <br />
        </td>
        <td class="auto-style14">
            <asp:Label ID="Label1" runat="server" Text="Time Unavailable (Hour)"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Day of Month"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
        </td>
        <td>
            <br />
&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
&nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
&nbsp;
            <br />
            <br />
            <br />
        </td>
        <td>
            <asp:Label ID="Label4" runat="server" Text="Appointment Date (Day of Month)"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Appointment Time (Hour of Day)"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Student"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label8" runat="server" Text="Student ID"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Reason"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        </td>
    </tr>
</table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="auto-style2" NavigateUrl="~/Messages/Messages.aspx">Messages</asp:HyperLink>
</asp:Content>
