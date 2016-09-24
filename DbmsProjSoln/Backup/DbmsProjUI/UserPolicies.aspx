<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true" CodeBehind="UserPolicies.aspx.cs" Inherits="DbmsProjUI.UserPolicies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div align="center" style="background-color: #FFFFFF">
<asp:GridView ID="GridViewUserPolicies" runat="server" CellPadding="4" ForeColor="#333333"
            GridLines="None" AllowSorting="True" AutoGenerateColumns="False" 
            AllowPaging="True" 
        onpageindexchanging="GridViewUserPolicies_PageIndexChanging"         
        onsorting="GridViewUserPolicies_Sorting" 
        onrowcancelingedit="GridViewUserPolicies_RowCancelingEdit" 
        onrowcommand="GridViewUserPolicies_RowCommand" 
        onrowdeleting="GridViewUserPolicies_RowDeleting" 
        onrowediting="GridViewUserPolicies_RowEditing" 
        onrowupdating="GridViewUserPolicies_RowUpdating" >
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
                <%--<asp:TemplateField HeaderText="Enroll" ShowHeader="False" HeaderStyle-HorizontalAlign="Left"> 
                <ItemTemplate> 
                    <asp:LinkButton ID="linkEnroll" runat="server" CausesValidation="False" CommandName="Enroll" Text="Enroll"></asp:LinkButton> 
                </ItemTemplate> 
            </asp:TemplateField>                --%>
                <%--<asp:CommandField HeaderText="Edit" UpdateText="Update" EditText="Edit" CancelText="Cancel" ShowEditButton="true" />--%>
                <%--<asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />--%>
                <%--<asp:BoundField DataField="PolicyID" HeaderText="PolicyID" SortExpression="PolicyID" ReadOnly="true" />--%>
                <asp:TemplateField HeaderText="PolicyName" SortExpression="PolicyName">
                    <ItemTemplate>
                        <asp:Label ID="PolicyName" runat="server" Text='<%#Eval("PolicyName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="PolicyName" runat="server" Text='<%#Eval("PolicyName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <%--<FooterTemplate>
                    <asp:TextBox ID="txtPolicyName" runat="server" ></asp:TextBox>
                    </FooterTemplate>--%>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PolicyPremium" SortExpression="PolicyPremium">
                    <ItemTemplate>
                        <asp:Label ID="PolicyPremium" runat="server" Text='<%#Eval("PolicyPremium") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="PolicyPremium" runat="server" Text='<%#Eval("PolicyPremium") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <%--<FooterTemplate>
                    <asp:TextBox ID="txtPolicyPremium" runat="server" ></asp:TextBox>
                    </FooterTemplate>--%>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MaximumLimit" SortExpression="MaximumLimit">
                    <ItemTemplate>
                        <asp:Label ID="MaximumLimit" runat="server" Text='<%#Eval("MaximumLimit") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="MaximumLimit" runat="server" Text='<%#Eval("MaximumLimit") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <%--<FooterTemplate>
                    <asp:TextBox ID="txtMaximumLimit" runat="server" ></asp:TextBox>
                    </FooterTemplate>--%>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Benefits" SortExpression="Benefits">
                    <ItemTemplate>
                        <asp:Label ID="Benefits" runat="server" Text='<%#Eval("Benefits") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="Benefits" runat="server" Text='<%#Eval("Benefits") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <%--<FooterTemplate>
                    <asp:TextBox ID="txtBenefits" runat="server" ></asp:TextBox>
                    </FooterTemplate>--%>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </div>
</asp:Content>
