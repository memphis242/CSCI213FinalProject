<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="ScheduleManagment.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
            color: #006600;
        }
        .auto-style2 {
            font-size: small;
        }
        .auto-style3 {
            width: 410px;
            height: 258px;
        }
        .auto-style4 {
            width: 305px;
        }
        .auto-style6 {
            font-size: xx-large;
            color: #009933;
        }
        .auto-style7 {
            width: 425px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            NDSU Student/Advisor Schedule Management System (NSASMS)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LoginStatus ID="LoginStatus1" runat="server" />
            <br />
            <table style="width:100%;">
                <tr class="auto-style2">
                    <td class="auto-style4">
                        <img alt="" class="auto-style3" src="Images/NDSULogo.jpg" /></td>
                    <td class="auto-style7">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td>&nbsp;</td>
                </tr>
                <tr class="auto-style2">
                    <td class="auto-style4">
                        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="auto-style6" NavigateUrl="~/Scheduler/Scheduler.aspx">Scheduler</asp:HyperLink>
                        <br />
                        <br />
                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="auto-style6" NavigateUrl="~/Messages/Messages.aspx">Messages</asp:HyperLink>
                        <br />
                    </td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
