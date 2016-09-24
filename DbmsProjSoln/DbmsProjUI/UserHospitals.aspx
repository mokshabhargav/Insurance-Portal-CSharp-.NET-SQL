<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true" CodeBehind="UserHospitals.aspx.cs" Inherits="DbmsProjUI.UserHospitals" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div align="center">
        <%--<asp:GridView ID="GridView1" runat="server" AllowSorting="True" AllowPaging="True" PageIndex="5">
            <Columns>
                <asp:BoundField DataField="HospitalName" HeaderText="HospitalName" 
                    SortExpression="HospitalName" />
                <asp:BoundField DataField="Speciality" HeaderText="Speciality" 
                    SortExpression="Speciality" />
                <asp:BoundField DataField="Address" HeaderText="Address" 
                    SortExpression="Address" />
            </Columns>
        </asp:GridView>--%>
        <asp:GridView ID="GridViewListHospitals" runat="server" AllowSorting="true" 
            AllowPaging="true" PageIndex="5" AutoGenerateColumns="false" 
            onpageindexchanging="GridViewListHospitals_PageIndexChanging" 
            onrowdeleting="GridViewListHospitals_RowDeleting" onrowediting="GridViewListHospitals_RowEditing" 
            onrowupdating="GridViewListHospitals_RowUpdating" onsorting="GridViewListHospitals_Sorting" 
            onrowcancelingedit="GridViewListHospitals_RowCancelingEdit">
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
       <%--<asp:CommandField Headertext="EDIT" UpdateText="update" EditText="edit" CancelText="cancel" ShowEditButton="true" />
       <asp:CommandField HeaderText="DELETE" DeleteText="delete" ShowDeleteButton="true" />--%>
       <%--<asp:BoundField DataField="HospitalID" HeaderText="HospitalID" SortExpression="HospitalID" ReadOnly="true" />--%>
        <asp:BoundField DataField="HospitalName" HeaderText="HospitalName" SortExpression="HospitalName" ReadOnly="true" />
        
        <asp:BoundField DataField="Speciality" HeaderText="Speciality" SortExpression="Speciality" ReadOnly="true" />
        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" ReadOnly="true" />

       <%--<asp:TemplateField HeaderText="FIRSTNAME" SortExpression="Firstname">
       <ItemTemplate>
       <asp:Label ID="Fstname" runat="server" Text='<%#Eval("Firstname") %>'></asp:Label>
       </ItemTemplate>
       <EditItemTemplate>
               <asp:TextBox ID="FN" runat="server" Text='<%#Eval("Firstname") %>'>
               </asp:TextBox>
               </EditItemTemplate>
       </asp:TemplateField>
       <asp:TemplateField HeaderText="LASTNAME" SortExpression="Lastname">
       <ItemTemplate>
       <asp:Label ID="LSTname" runat="server" Text='<%#Eval("Lastname") %>'></asp:Label>
       </ItemTemplate>
       <EditItemTemplate>
               <asp:TextBox ID="Lsnme" runat="server" Text='<%#Eval("Lastname") %>'>
               </asp:TextBox>
               </EditItemTemplate>
       </asp:TemplateField>
       <asp:TemplateField HeaderText="EMAILID" SortExpression="Emailid">
       <ItemTemplate>
       <asp:Label ID="EMID" runat="server" Text='<%#Eval("Emailid") %>'></asp:Label>
       </ItemTemplate>
       <EditItemTemplate>
               <asp:TextBox ID="txtEMID" runat="server" Text='<%#Eval("Emailid") %>'>
               </asp:TextBox>
               </EditItemTemplate>
       </asp:TemplateField>
        <asp:BoundField DataField="Gender" HeaderText="GENDER" SortExpression="Gender" ReadOnly="true" />
        <asp:BoundField DataField="Marital" HeaderText="MARITAL" SortExpression="Marital" ReadOnly="true" />
        <asp:BoundField DataField="DateOfBirth" HeaderText="DATEOFBIRTH" SortExpression="DateOfBirth" ReadOnly="true" />
        <asp:BoundField DataField="Mobile" HeaderText="MOBILE" SortExpression="Mobile" ReadOnly="true" />
        <asp:BoundField DataField="Address" HeaderText="ADDRESS" SortExpression="Address" ReadOnly="true" />--%>
        </Columns>
        </asp:GridView>
    </div>
</asp:Content>
