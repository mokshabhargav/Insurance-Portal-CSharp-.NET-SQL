<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true"
    CodeBehind="BenefHomePage.aspx.cs" Inherits="DbmsProjUI.BenefHomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div align="center" style="background-color: #FFFFFF">
    <table>
        <tr>
            <td>
                <div>
                    <asp:GridView ID="GridViewBenefMessages" runat="server" AllowSorting="true" AllowPaging="true"
                        PageIndex="5" AutoGenerateColumns="false" EmptyDataText="No Messages" 
                        onpageindexchanging="GridViewBenefMessages_PageIndexChanging" 
                        onrowcancelingedit="GridViewBenefMessages_RowCancelingEdit" 
                        onrowdeleting="GridViewBenefMessages_RowDeleting" 
                        onrowediting="GridViewBenefMessages_RowEditing" 
                        onrowupdating="GridViewBenefMessages_RowUpdating" 
                        onsorting="GridViewBenefMessages_Sorting">
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
                            <%--<asp:CommandField HeaderText="View" UpdateText="update" EditText="View Message" ShowEditButton="true" />--%>
                            <%--<asp:CommandField HeaderText="Delete" DeleteText="delete" ShowDeleteButton="true" />--%>
                            <asp:BoundField DataField="MsgSubject" HeaderText="Message Subject" SortExpression="Subject"
                                ReadOnly="true" />
                            <asp:BoundField DataField="TimeOfMessage" HeaderText="Time Of Message" SortExpression="Date"
                                ReadOnly="true" />
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
            <td rowspan='2'align="right" valign="top">
                <div >
                    <asp:HyperLink ID="linkBenefViewClaims" runat="server" BackColor="White" BorderColor="Blue"
                        NavigateUrl="~/BenefClaims.aspx">View Claims</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="linkBenefViewPolicies" runat="server" BackColor="White" 
                        BorderColor="Blue" NavigateUrl="~/BenefPolicies.aspx">View Policies</asp:HyperLink>
                    <br />
                    <asp:HyperLink ID="linkBenefViewHospitals" runat="server" BackColor="White" 
                        BorderColor="Blue" NavigateUrl="~/BenefHospitals.aspx">View Hospitals</asp:HyperLink>
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
