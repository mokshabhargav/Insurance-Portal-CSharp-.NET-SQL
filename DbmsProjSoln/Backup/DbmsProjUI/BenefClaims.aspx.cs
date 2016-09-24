using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Configuration;
using DbmsProjUI;

namespace DbmsProjUI
{
    public partial class BenefClaims : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection("Data Source=MOKSHA-PC\\MSSQLINSTANCE;Initial Catalog=SJSU_DBMS_PROJ;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (((Label)Master.FindControl("lblErrMsg")).Text == "Welcome Beneficiary")
            //{
                if (!IsPostBack)
                {
                    bindGrid();
                }
            //}
            else
            {
                //((Label)Master.FindControl("lblErrMsg")).Text = "";
                //Response.Redirect("UserLogin.aspx");
            }
        }

        public void bindGrid()
        {
            try
            {
                //string txtBeneficiaryID=((Label)Master.FindControl("lblErrMsg")).Text;
                string txtBeneficiaryID = "20010";
                int BeneficiaryID=Convert.ToInt16(txtBeneficiaryID);
                SqlCommand listClaims = new SqlCommand("spBenefListOfClaims", connection);
                listClaims.CommandType = CommandType.StoredProcedure;
                listClaims.Parameters.AddWithValue("@BenefID", BeneficiaryID);
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(listClaims);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ViewState["VSTable"] = dt;
                GridViewBenefClaims.DataSource = dt;
                GridViewBenefClaims.DataBind();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        protected void GridViewBenefClaims_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable datatable = (DataTable)ViewState["table"];
            if (datatable != null)
            {
                DataView view = new DataView(datatable);
                if (Convert.ToString(ViewState["sort"]).Contains("ASC") || Convert.ToString(ViewState["sort"]) == "")
                {
                    view.Sort = e.SortExpression + " " + "DESC";
                    ViewState["sort"] = view.Sort.ToString();
                }
                else
                {
                    view.Sort = e.SortExpression + " " + "ASC";
                    ViewState["sort"] = view.Sort.ToString();
                }
                GridViewBenefClaims.DataSource = view;
                GridViewBenefClaims.DataBind();
            }
        }

        protected void GridViewBenefClaims_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewBenefClaims.PageIndex = e.NewPageIndex;
            bindGrid();
        }

        protected void GridViewBenefClaims_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridViewBenefClaims.Rows[e.RowIndex];
            int ID = Convert.ToInt16(row.Cells[2].Text);
            //int val = datawrapper(ID, "", "", "", "delete");
            //if (val > 0)
            //{
            //    bindGrid();
            //    Response.Write("Operation success");
            //}
            //else
            //{
            //    Response.Write("Operation failed");
            //}
        }

        protected void GridViewBenefClaims_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewBenefClaims.Rows[e.RowIndex];
            int HospitalID = Convert.ToInt16(row.Cells[2].Text);
            //TextBox tbHospitalID = (TextBox)row.FindControl("HospitalID");
            //int HospitalID = Convert.ToInt16(tbHospitalID.Text);
            TextBox tbHospitalName = (TextBox)row.Cells[3].FindControl("HospitalName");
            string HospitalName = tbHospitalName.Text;
            TextBox tbSpeciality = (TextBox)row.Cells[4].FindControl("Speciality");
            string Speciality = tbSpeciality.Text;
            TextBox tbAddress = (TextBox)row.Cells[5].FindControl("Address");
            string Address = tbAddress.Text;
            //datawrapper(HospitalID, HospitalName, Speciality, Address, "update");
            GridViewBenefClaims.EditIndex = -1;
            bindGrid();
        }

        protected void GridViewBenefClaims_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewBenefClaims.EditIndex = e.NewEditIndex;
            //HiddenField1.Value = e.NewEditIndex.ToString();
            bindGrid();
        }

        protected void GridViewBenefClaims_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewBenefClaims.EditIndex = -1;
            bindGrid();
        }

        protected void GridViewBenefClaims_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("RaiseClaim"))
            {
                int BeneficiaryID = Convert.ToInt16(((Label)Master.FindControl("lblErrMsg")).Text);
                TextBox txtClaimedOnPID = (TextBox)GridViewBenefClaims.FooterRow.FindControl("txtClaimedOnPID");
                int ClaimedOnPID = Convert.ToInt32(txtClaimedOnPID.Text);
                TextBox txtClaimedInHID = (TextBox)GridViewBenefClaims.FooterRow.FindControl("txtClaimedInHID");
                int ClaimedInHID = Convert.ToInt32(txtClaimedInHID.Text);
                TextBox txtClaimType = (TextBox)GridViewBenefClaims.FooterRow.FindControl("txtClaimType");
                string ClaimType = txtClaimType.Text;
                //Label lblClaimRaisedOn = (Label)GridViewBenefClaims.FooterRow.FindControl("lblClaimRaisedOn");
                DateTime DateClaimRaisedOn= DateTime.Now;
                //Label lblClaimRaisedOn = (Label)GridViewBenefClaims.FooterRow.FindControl("lblClaimRaisedOn");
                TextBox txtClaimAmount = (TextBox)GridViewBenefClaims.FooterRow.FindControl("txtClaimAmount");
                TextBox txtClaimStatus = (TextBox)GridViewBenefClaims.FooterRow.FindControl("txtClaimStatus");

                if ((txtClaimedOnPID.Text != "") && (txtClaimedInHID.Text != "") && (txtClaimType.Text != "") && (txtClaimAmount.Text != ""))
                {
                    datawrapper(0,BeneficiaryID, ClaimedOnPID, ClaimedInHID, ClaimType, DateClaimRaisedOn, Convert.ToInt16(txtClaimAmount.Text),"In Progress", "insert");
                }
                else
                {
                    string message = "Please enter valid text to add";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                }
                bindGrid();
            }
        }
        public int datawrapper(int ClaimID,int BenefID, int ClaimedOnPID, int ClaimedInHID, string ClaimType, DateTime ClaimRaisedOn, int ClaimAmount, string ClaimStatus, string flag)
        {
            try
            {
                SqlCommand gridUpdate = new SqlCommand("spBenefAddClaim", connection);
                gridUpdate.CommandType = CommandType.StoredProcedure;
                connection.Open();                
                gridUpdate.Parameters.AddWithValue("@BenefID", BenefID);
                gridUpdate.Parameters.AddWithValue("@ClaimedOnPID", ClaimedOnPID);
                gridUpdate.Parameters.AddWithValue("@ClaimedInHID", ClaimedInHID);
                gridUpdate.Parameters.AddWithValue("@ClaimType", ClaimType);
                gridUpdate.Parameters.AddWithValue("@ClaimRaisedOn", ClaimRaisedOn);
                gridUpdate.Parameters.AddWithValue("@ClaimAmount", ClaimAmount);
                int val = gridUpdate.ExecuteNonQuery();
                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}