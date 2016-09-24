<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true"
    CodeBehind="AdminHomePage.aspx.cs" Inherits="DbmsProjUI.AdminHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <table>
            <tr>
                <td>
                    <div>
                        <asp:GridView ID="GridViewAdminMessages" runat="server" CellPadding="4" ForeColor="#333333"
                            GridLines="None" AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True"
                            ShowFooter="True" OnPageIndexChanging="GridViewAdminMessages_PageIndexChanging"
                            OnRowCancelingEdit="GridViewAdminMessages_RowCancelingEdit" OnRowCommand="GridViewAdminMessages_RowCommand"
                            OnRowDeleting="GridViewAdminMessages_RowDeleting" OnRowEditing="GridViewAdminMessages_RowEditing"
                            OnRowUpdating="GridViewAdminMessages_RowUpdating" 
                            OnSorting="GridViewAdminMessages_Sorting" EmptyDataText="No Messages" 
                            onload="GridViewAdminMessages_Load">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
                                    <%--<EditItemTemplate> 
                    <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton> 
                    <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton> 
                </EditItemTemplate> --%>
                                    <FooterTemplate>
                                        <asp:LinkButton ID="lnkReply" runat="server" CausesValidation="False" CommandName="Reply"
                                            Text="Add New Message"></asp:LinkButton>
                                    </FooterTemplate>
                                    <%--<ItemTemplate>
                                        <asp:LinkButton ID="lnkView" runat="server" CausesValidation="False" CommandName="View"
                                            Text="View"></asp:LinkButton>
                                    </ItemTemplate>--%>
                                </asp:TemplateField>
                                <%--<asp:CommandField HeaderText="Edit" UpdateText="Update" EditText="Edit" CancelText="Cancel" ShowEditButton="true" />--%>
                                <%--<asp:BoundField DataField="HospitalID" HeaderText="HospitalID" SortExpression="HospitalID" ReadOnly="true" />--%>
                                <asp:TemplateField HeaderText="BeneficiaryID" SortExpression="BeneficiaryID">
                                    <ItemTemplate>
                                        <asp:Label ID="BeneficiaryID" runat="server" Text='<%#Eval("BeneficiaryID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <%--<EditItemTemplate>
                        <asp:TextBox ID="BeneficiaryID" runat="server" Text='<%#Eval("BeneficiaryID") %>'></asp:TextBox>
                    </EditItemTemplate>--%>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtBeneficiaryID" runat="server"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MsgSubject" SortExpression="MsgSubject">
                                    <ItemTemplate>
                                        <asp:Label ID="MsgSubject" runat="server" Text='<%#Eval("MsgSubject") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="MsgSubject" runat="server" Text='<%#Eval("MsgSubject") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtMsgSubject" runat="server"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TimeOfMessage" SortExpression="TimeOfMessage">
                                    <ItemTemplate>
                                        <asp:Label ID="TimeOfMessage" runat="server" Text='<%#Eval("TimeOfMessage") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TimeOfMessage" runat="server" Text='<%#Eval("TimeOfMessage") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                    <asp:Label ID="lblTimeOfMessage" runat="server" ></asp:Label>
                                        <%--<asp:TextBox ID="txtTimeOfMessage" runat="server"></asp:TextBox>--%>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <%--<asp:GridView ID="GridViewAdminHome" runat="server" AllowSorting="true" AllowPaging="true"
                        PageIndex="5" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="BeneficiaryID" HeaderText="Beneficiary ID" SortExpression="Subject"
                                ReadOnly="true" />
                            <asp:BoundField DataField="Subject" HeaderText="Message Subject" SortExpression="Subject"
                                ReadOnly="true" />
                            <asp:CommandField SelectText="View Message" />
                            <asp:CommandField DeleteText="delete" ShowDeleteButton="true" />
                            <asp:BoundField DataField="Date" HeaderText="Time Of Message" SortExpression="Date"
                                ReadOnly="true" />
                        </Columns>
                    </asp:GridView>--%>
                    </div>
                </td>
                <td rowspan='2'>
                    <div>
                        <asp:HyperLink ID="HyperLink1" runat="server" BackColor="White" BorderColor="Blue"
                            NavigateUrl="~/AdminClaims.aspx">View Claims</asp:HyperLink>
                    </div>
                    <div>
                        <asp:HyperLink ID="HyperLink2" runat="server" BackColor="White" BorderColor="Blue"
                            NavigateUrl="~/AdminPolicies.aspx">View Policies</asp:HyperLink>
                    </div>
                    <div>
                        <asp:HyperLink ID="HyperLink3" runat="server" BackColor="White" BorderColor="Blue"
                            NavigateUrl="~/AdminHospitals.aspx">View Hospitals</asp:HyperLink>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <asp:GridView ID="GridViewAdminNotifications" runat="server" AllowSorting="true"
                            AllowPaging="true" PageIndex="5" AutoGenerateColumns="false" EmptyDataText="No Notifications">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            <Columns>
                                <%--<asp:CommandField HeaderText="VIEW" UpdateText="update" EditText="View Message" ShowEditButton="true" />--%>
                                <%--<asp:CommandField HeaderText="DELETE" DeleteText="delete" ShowDeleteButton="true" />--%>
                                <asp:BoundField DataField="ClaimID" HeaderText="ClaimID" SortExpression="ClaimID"
                                    ReadOnly="true" />
                                <asp:BoundField DataField="BeneficiaryID" HeaderText="BeneficiaryID" SortExpression="BeneficiaryID"
                                    ReadOnly="true" />
                                <asp:BoundField DataField="Notification" HeaderText="Notification" SortExpression="Notification"
                                    ReadOnly="true" />
                                <asp:BoundField DataField="Date" HeaderText="Time Of Notification" SortExpression="TimeOfNotification"
                                    ReadOnly="true" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan='2'>
                    <div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
