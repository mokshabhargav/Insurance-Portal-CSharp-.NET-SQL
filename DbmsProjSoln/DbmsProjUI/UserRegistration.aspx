<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true"
    CodeBehind="UserRegistration.aspx.cs" Inherits="DbmsProjUI.UserRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
    <script type="text/javascript" ></script>
    <script language="javascript" src="Calender.js" type="text/javascript"></script>
    <link href="Calender.css" rel="stylesheet" type="text/css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center" style="background-color: #FFFFFF">
        <table align="center" cellpadding="10" cellspacing="10">
            <tr>
                <td colspan="2">
                    <h1>
                        User Registration Form</h1>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="FirstName_label" runat="server" Text="First Name"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="firstname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LastName_label" runat="server" Text="Last Name"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="lastname" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSsn" runat="server" Text="Ssn"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtSsn" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Gender_label" runat="server" Text="Gender"></asp:Label>
                </td>
                <td align="left">
                    <asp:RadioButtonList ID="Gender" runat="server">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="DateOfBirth_label" runat="server" Text="DateOfBirth"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtDateOfBirth" runat="server"></asp:TextBox>
                    <a onclick="showCalendarControl(txtDateOfBirth)" href="#"><img src="Images/calendar.gif" alt="Images/calendar.gif" style="width: 20px; height: 20px"
                            border="0" /></a>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="EmailId_label" runat="server" Text="Email Id"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="EmailId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="MobileNo_label" runat="server" Text="Mobile No."></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="MobileNo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="password_label" runat="server" Text="Password"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="confirmPassword_label" runat="server" Text="Confirm Password"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="confirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="message_label" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="submit" runat="server" OnClick="submit_Click1" Text="Submit" />
                </td>
                <td>
                    <asp:Button ID="login_button" runat="server" OnClick="login_button_Click" Text="Login" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
