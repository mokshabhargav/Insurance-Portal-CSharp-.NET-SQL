<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true"
    CodeBehind="AdminClaims.aspx.cs" Inherits="DbmsProjUI.AdminClaims" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 1100px; height: Auto;" align="center">
        <asp:GridView ID="GridViewAdminClaims" runat="server" CellPadding="4" ForeColor="#333333"
            GridLines="None" AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True"
            DataKeyNames="ClaimID" Width="1100px" OnPageIndexChanging="GridViewAdminClaims_PageIndexChanging"
            OnRowCancelingEdit="GridViewAdminClaims_RowCancelingEdit" OnRowDeleting="GridViewAdminClaims_RowDeleting"
            OnRowEditing="GridViewAdminClaims_RowEditing" OnRowUpdating="GridViewAdminClaims_RowUpdating"
            OnSorting="GridViewAdminClaims_Sorting">
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
                <asp:TemplateField HeaderText="Edit" ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
                    <EditItemTemplate>
                        <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update"
                            Text="Update"></asp:LinkButton>
                        <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="Edit"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:CommandField HeaderText="Edit" UpdateText="Update" EditText="Edit" CancelText="Cancel" ShowEditButton="true" />--%>
                <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
                <%--<asp:BoundField DataField="ClaimID" HeaderText="ClaimID" SortExpression="ClaimID"
                    ReadOnly="true" />--%>
                    <asp:TemplateField HeaderText="ClaimID" SortExpression="ClaimID">
                    <ItemTemplate>
                        <asp:Label ID="lblClaimID" runat="server" Text='<%#Eval("ClaimID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="BeneficiaryID" HeaderText="BeneficiaryID" SortExpression="BeneficiaryID"
                    ReadOnly="true" />
                <asp:BoundField DataField="ClaimedOnPID" HeaderText="Claimed On Policy ID" SortExpression="ClaimedOnPID"
                    ReadOnly="true" />
                <asp:BoundField DataField="ClaimedInHID" HeaderText="Claimed In Hospital ID" SortExpression="ClaimedInHID"
                    ReadOnly="true" />
                <asp:BoundField DataField="ClaimType" HeaderText="Type Of Claim" SortExpression="ClaimType"
                    ReadOnly="true" />
                <asp:BoundField DataField="ClaimRaisedOn" HeaderText="Date Of Claim Raised" SortExpression="ClaimRaisedOn"
                    ReadOnly="true" />
                <asp:BoundField DataField="ClaimAmount" HeaderText="Claimed Amount" SortExpression="ClaimAmount"
                    ReadOnly="true" />
                <asp:TemplateField HeaderText="Status Of Claim" SortExpression="ClaimStatus">
                    <ItemTemplate>
                        <asp:Label ID="ClaimStatus" runat="server" Text='<%#Eval("ClaimStatus") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlClaimStatus" runat="server" Text='<%#Eval("ClaimStatus") %>'
                            Width="100px">
                            <asp:ListItem>Approved</asp:ListItem>
                            <asp:ListItem>Rejected</asp:ListItem>
                            <asp:ListItem>In Progress</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="HospitalName" SortExpression="HospitalName">
                    <ItemTemplate>
                        <asp:Label ID="HospitalName" runat="server" Text='<%#Eval("HospitalName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="HospitalName" runat="server" Text='<%#Eval("HospitalName") %>'></asp:TextBox>
                    </EditItemTemplate>                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Speciality" SortExpression="Speciality">
                    <ItemTemplate>
                        <asp:Label ID="Speciality" runat="server" Text='<%#Eval("Speciality") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="Speciality" runat="server" Text='<%#Eval("Speciality") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address" SortExpression="Address">
                    <ItemTemplate>
                        <asp:Label ID="Address" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="Address" runat="server" Text='<%#Eval("Address") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
