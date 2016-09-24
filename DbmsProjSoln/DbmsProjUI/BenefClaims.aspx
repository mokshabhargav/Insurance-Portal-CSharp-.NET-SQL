<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true"
    CodeBehind="BenefClaims.aspx.cs" Inherits="DbmsProjUI.BenefClaims" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:GridView ID="GridViewBenefClaims" runat="server" CellPadding="4" ForeColor="#333333"
            GridLines="None" AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True"
            DataKeyNames="ClaimID" ShowFooter="True" OnPageIndexChanging="GridViewBenefClaims_PageIndexChanging"
            OnRowCancelingEdit="GridViewBenefClaims_RowCancelingEdit" OnRowCommand="GridViewBenefClaims_RowCommand"
            OnRowDeleting="GridViewBenefClaims_RowDeleting" OnRowEditing="GridViewBenefClaims_RowEditing"
            OnRowUpdating="GridViewBenefClaims_RowUpdating" OnSorting="GridViewBenefClaims_Sorting">
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
                <%--<asp:TemplateField HeaderText="Edit" ShowHeader="False" HeaderStyle-HorizontalAlign="Left">
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
            </asp:TemplateField>--%>
                <%--<asp:CommandField HeaderText="Edit" UpdateText="Update" EditText="Edit" CancelText="Cancel" ShowEditButton="true" />--%>
                <%--<asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />--%>
                <%--<asp:BoundField DataField="ClaimID" HeaderText="ClaimID" SortExpression="ClaimID"
                ReadOnly="true" />--%>
                <asp:TemplateField HeaderText="ClaimID" SortExpression="ClaimID">
                    <ItemTemplate>
                        <asp:Label ID="ClaimID" runat="server" Text='<%#Eval("ClaimID") %>'></asp:Label>
                    </ItemTemplate>
                    <%--<EditItemTemplate>
                        <asp:TextBox ID="ClaimID" runat="server" Text='<%#Eval("ClaimID") %>'></asp:TextBox>
                    </EditItemTemplate>--%>
                    <FooterTemplate>
                        <asp:LinkButton ID="linkRaiseClaim" runat="server" CausesValidation="False" CommandName="RaiseClaim"
                            Text="Raise New Claim"></asp:LinkButton>
                    </FooterTemplate>
                </asp:TemplateField>
                <%--<asp:BoundField DataField="BeneficiaryID" HeaderText="BeneficiaryID" SortExpression="BeneficiaryID"
                ReadOnly="true" />--%>
                <%--<asp:BoundField DataField="ClaimedOnPID" HeaderText="Claimed On Policy ID" SortExpression="ClaimedOnPID"
                ReadOnly="true" />--%>
                <asp:TemplateField HeaderText="Claimed On Policy ID" SortExpression="ClaimedOnPID">
                    <ItemTemplate>
                        <asp:Label ID="ClaimedOnPID" runat="server" Text='<%#Eval("ClaimedOnPID") %>'></asp:Label>
                    </ItemTemplate>
                    <%--<EditItemTemplate>
                        <asp:TextBox ID="ClaimID" runat="server" Text='<%#Eval("ClaimID") %>'></asp:TextBox>
                    </EditItemTemplate>--%>
                    <FooterTemplate>
                        <asp:TextBox ID="txtClaimedOnPID" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <%--<asp:BoundField DataField="ClaimedInHID" HeaderText="Claimed In Hospital ID" SortExpression="ClaimedInHID"
                ReadOnly="true" />--%>
                <asp:TemplateField HeaderText="Claimed in Hospital ID" SortExpression="ClaimedInHID">
                    <ItemTemplate>
                        <asp:Label ID="ClaimedInHID" runat="server" Text='<%#Eval("ClaimedInHID") %>'></asp:Label>
                    </ItemTemplate>
                    <%--<EditItemTemplate>
                        <asp:TextBox ID="ClaimID" runat="server" Text='<%#Eval("ClaimID") %>'></asp:TextBox>
                    </EditItemTemplate>--%>
                    <FooterTemplate>
                        <asp:TextBox ID="txtClaimedInHID" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <%--<asp:BoundField DataField="ClaimType" HeaderText="Type Of Claim" SortExpression="ClaimType"
                ReadOnly="true" />--%>
                <asp:TemplateField HeaderText="ClaimType" SortExpression="ClaimType">
                    <ItemTemplate>
                        <asp:Label ID="ClaimType" runat="server" Text='<%#Eval("ClaimType") %>'></asp:Label>
                    </ItemTemplate>
                    <%--<EditItemTemplate>
                        <asp:TextBox ID="ClaimID" runat="server" Text='<%#Eval("ClaimID") %>'></asp:TextBox>
                    </EditItemTemplate>--%>
                    <FooterTemplate>
                        <asp:TextBox ID="txtClaimType" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <%--<asp:BoundField DataField="ClaimRaisedOn" HeaderText="Date Of Claim Raised" SortExpression="ClaimRaisedOn"
                ReadOnly="true" />--%>
                <asp:TemplateField HeaderText="Date Claim is Raised On" SortExpression="ClaimRaisedOn">
                    <ItemTemplate>
                        <asp:Label ID="ClaimRaisedOn" runat="server" Text='<%#Eval("ClaimRaisedOn") %>'></asp:Label>
                    </ItemTemplate>
                    <%--<EditItemTemplate>
                        <asp:TextBox ID="ClaimID" runat="server" Text='<%#Eval("ClaimID") %>'></asp:TextBox>
                    </EditItemTemplate>--%>
                    <FooterTemplate>
                        <asp:Label ID="lblClaimRaisedOn" Width="100px" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <%--<asp:BoundField DataField="ClaimAmount" HeaderText="Claimed Amount" SortExpression="ClaimAmount"
                ReadOnly="true" />--%>
                <asp:TemplateField HeaderText="Claimed Amount" SortExpression="ClaimAmount">
                    <ItemTemplate>
                        <asp:Label ID="ClaimAmount" runat="server" Text='<%#Eval("ClaimAmount") %>'></asp:Label>
                    </ItemTemplate>
                    <%--<EditItemTemplate>
                        <asp:TextBox ID="ClaimID" runat="server" Text='<%#Eval("ClaimID") %>'></asp:TextBox>
                    </EditItemTemplate>--%>
                    <FooterTemplate>
                        <asp:TextBox ID="txtClaimAmount" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Claim Status" SortExpression="ClaimStatus">
                    <ItemTemplate>
                        <asp:Label ID="ClaimStatus" runat="server" Text='<%#Eval("ClaimStatus") %>'></asp:Label>
                    </ItemTemplate>
                    <%--<EditItemTemplate>
                        <asp:TextBox ID="ClaimID" runat="server" Text='<%#Eval("ClaimID") %>'></asp:TextBox>
                    </EditItemTemplate>--%>
                    <FooterTemplate>
                        <asp:Label ID="lblClaimStatus" runat="server" ></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
