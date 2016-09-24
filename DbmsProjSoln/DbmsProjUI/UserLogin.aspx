<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true"
    CodeBehind="UserLogin.aspx.cs" Inherits="DbmsProjUI.UserLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-color: #FFFFFF">
        <table id="Login" align="center" runat="server" style="height: 247px;">
            <tr>
                <td rowspan="9" class="style3">
                    <asp:Image ID="imgLogin" runat="server" Height="237px" ImageUrl="~/images/login.jpg"
                        Width="197px" Style="margin-left: 25px; margin-top: 25px; margin-bottom: 25px;
                        margin-right: 23px" />
                </td>
            </tr>
            <%--<tr>
                <td class="style1">
                    <br />
                    <asp:Label ID="lblRole" runat="server" Text="Select Role"></asp:Label>
                </td>
                <td class="style2">
                    <br />
                    <asp:DropDownList ID="ddRole" runat="server" Width="130px" CausesValidation="True">
                        <asp:ListItem>customer</asp:ListItem>
                        <asp:ListItem>clerk</asp:ListItem>
                        <asp:ListItem>Administrator</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvRole" runat="server" ControlToValidate="ddRole"
                        ErrorMessage="*fields are mandatory" Font-Italic="True" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>--%>
            <tr>
                <td align="center" colspan="2" bgcolor="#66FF66">
                    <asp:Label ID="lblLoginHeader" runat="server" Text="Enrolled Member Login"></asp:Label>
                </td>
                <td rowspan="2" width="200px" align="center" valign="top">
                    <asp:HyperLink ID="linkUserSignup" runat="server" BackColor="White" BorderColor="Blue"
                        NavigateUrl="~/UserRegistration.aspx" ForeColor="Red">New User! Signup</asp:HyperLink>
                    
                </td>
                
            </tr>
            <tr>
                <td class="style1">
                    <br />
                    <asp:Label ID="lblUserName" runat="server" Text="UserName"></asp:Label>
                </td>
                <td class="style2">
                    <br />
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName"
                        Display="Dynamic" ErrorMessage="*" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <br />
                    <asp:Label ID="lblPassword" runat="server" Text="PassWord"></asp:Label>
                </td>
                <td class="style2">
                    <br />
                    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtpwd"
                        Display="Dynamic" ErrorMessage="*" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td rowspan="2" align="right">
                <asp:HyperLink ID="linkViewPolicies" runat="server" BackColor="White" BorderColor="Blue"
                        NavigateUrl="~/UserPolicies.aspx">View Available Policies</asp:HyperLink>
                </td>
            </tr>
            <%--<tr>
                <td class="style1">
                    <br />
                    <asp:Label ID="lblEmailId" runat="server" Text="E-MailId"></asp:Label>
                </td>
                <td class="style2">
                    <br />
                    <asp:TextBox ID="txtMailId" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmailId" runat="server" ControlToValidate="txtMailId"
                        ErrorMessage="* fields are mandatory" Font-Italic="True" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmailId" runat="server" ControlToValidate="txtMailId"
                        ErrorMessage="* invalid Email ID" Font-Italic="True" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>--%>
            <%--<tr>
                <td>
                </td>
                <td align="left">
                    <br />
                    <asp:CheckBox ID="rememberMe" runat="server" Text="Remember Me" />
                </td>
            </tr>--%>
            <tr>
                <td>
                </td>
                <td align="left" colspan="2">
                    <br />
                    <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click" />
                    <br />
                    <br />
                    <asp:Label ID="lblLogin" runat="server" Visible="False"></asp:Label>
                    <%--<asp:ImageButton ID="btnLogin" runat="server" OnClick="btnLogin_Click" ImageUrl="~/images/loginBtn.jpg"
                        Height="30px" Width="80px" />--%>
                </td>
            </tr>
            <%--<tr>
                <td align="right">
                <br />
                    <asp:LinkButton ID="lnkRegister" runat="server" Text="Sign up" OnClick="lnkRegister_Click"
                        Font-Bold="True" Font-Underline="false" ForeColor="#009933" CausesValidation="False"></asp:LinkButton>
                </td>
                <td align="left">
                <br />
                    &nbsp;&nbsp;<asp:LinkButton ID="lnkForgotPwd" runat="server" Text="Forgot Password" OnClick="lnkForgotPwd_Click"
                        Font-Bold="True" Font-Underline="false" ForeColor="#009933" CausesValidation="False"></asp:LinkButton>
                </td>
            </tr>--%>
        </table>
    </div>
</asp:Content>
