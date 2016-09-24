<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true"
    CodeBehind="AdminHospitals.aspx.cs" Inherits="DbmsProjUI.AdminHospitals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 996px; height: Auto;" align="center">
        <asp:GridView ID="GridViewAdminHospitals" runat="server" CellPadding="4" ForeColor="#333333"
            GridLines="None" AllowSorting="True" AutoGenerateColumns="False" 
            AllowPaging="True" DataKeyNames="HospitalID" OnPageIndexChanging="GridViewAdminHospitals_PageIndexChanging"
            OnRowCancelingEdit="GridViewAdminHospitals_RowCancelingEdit" OnRowDeleting="GridViewAdminHospitals_RowDeleting"
            OnRowEditing="GridViewAdminHospitals_RowEditing" OnRowUpdating="GridViewAdminHospitals_RowUpdating"
            OnSorting="GridViewAdminHospitals_Sorting" ShowFooter="True" 
            onrowcommand="GridViewAdminHospitals_RowCommand">
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
                    <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton> 
                    <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton> 
                </EditItemTemplate> 
                <FooterTemplate> 
                    <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="False" CommandName="Insert" Text="Add New Hospital"></asp:LinkButton> 
                </FooterTemplate> 
                <ItemTemplate> 
                    <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton> 
                </ItemTemplate> 
            </asp:TemplateField>                
                <%--<asp:CommandField HeaderText="Edit" UpdateText="Update" EditText="Edit" CancelText="Cancel" ShowEditButton="true" />--%>
                <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
                <asp:BoundField DataField="HospitalID" HeaderText="HospitalID" SortExpression="HospitalID" ReadOnly="true" />
                <asp:TemplateField HeaderText="HospitalName" SortExpression="HospitalName">
                    <ItemTemplate>
                        <asp:Label ID="HospitalName" runat="server" Text='<%#Eval("HospitalName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="HospitalName" runat="server" Text='<%#Eval("HospitalName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                    <asp:TextBox ID="txtHospitalName" runat="server" ></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Speciality" SortExpression="Speciality">
                    <ItemTemplate>
                        <asp:Label ID="Speciality" runat="server" Text='<%#Eval("Speciality") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="Speciality" runat="server" Text='<%#Eval("Speciality") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                    <asp:TextBox ID="txtSpeciality" runat="server" ></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address" SortExpression="Address">
                    <ItemTemplate>
                        <asp:Label ID="Address" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="Address" runat="server" Text='<%#Eval("Address") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                    <asp:TextBox ID="txtAddress" runat="server" ></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <%--<asp:HiddenField ID="HiddenField1" runat="server" />--%>
        <%--DataSourceID="SqlDataSourceAdminHospitals" 
        <asp:SqlDataSource ID="SqlDataSourceAdminHospitals" runat="server" 
            ConnectionString="<%$ ConnectionStrings:SJSU_DBMS_PROJConnectionString %>" >            
        </asp:SqlDataSource>--%>
    </div>
</asp:Content>
