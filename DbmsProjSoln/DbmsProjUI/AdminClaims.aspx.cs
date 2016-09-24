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

namespace DbmsProjUI
{
    public partial class AdminClaims : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection("Data Source=MOKSHA-PC\\MSSQLINSTANCE;Initial Catalog=SJSU_DBMS_PROJ;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (((Label)Master.FindControl("lblErrMsg")).Text == "Welcome Admin")
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
                SqlCommand listClaims = new SqlCommand("spAdminListOfClaims", connection);
                listClaims.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(listClaims);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ViewState["VSTable"] = dt;
                GridViewAdminClaims.DataSource = dt;
                GridViewAdminClaims.DataBind();
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

        protected void GridViewAdminClaims_Sorting(object sender, GridViewSortEventArgs e)
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
                GridViewAdminClaims.DataSource = view;
                GridViewAdminClaims.DataBind();
            }
        }

        protected void GridViewAdminClaims_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewAdminClaims.PageIndex = e.NewPageIndex;
            bindGrid();
        }

        protected void GridViewAdminClaims_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridViewAdminClaims.Rows[e.RowIndex];
            int ID = Convert.ToInt16(row.Cells[2].Text);
            int val = datawrapper(ID, "","delete");
            if (val > 0)
            {
                bindGrid();
                Response.Write("Operation success");
            }
            else
            {
                Response.Write("Operation failed");
            }
        }

        protected void GridViewAdminClaims_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                //GridViewRow row = GridViewAdminClaims.Rows[e.RowIndex];
                Label lblClaimID = (Label)GridViewAdminClaims.Rows[e.RowIndex].FindControl("lblClaimID");
                int ClaimID = Convert.ToInt16(lblClaimID.Text);
                //Label lblClaimID = (Label)GridViewAdminClaims.Rows[e.RowIndex].FindControl("lblClaimID");
                DropDownList ddlClaimStatus = (DropDownList)GridViewAdminClaims.Rows[e.RowIndex].FindControl("ddlClaimStatus");
                string ClaimStatus = ddlClaimStatus.SelectedValue;
                int val=datawrapper(ClaimID, ClaimStatus, "update");
                //string sql = "update Claim set ClaimStatus='" + ddlClaimStatus.SelectedValue.ToString() + "'where ClaimID=" + ClaimID + "";
                //SqlCommand cmd = new SqlCommand(sql, connection);
                //cmd.CommandType = CommandType.Text;
                //connection.Open();
                //cmd.ExecuteNonQuery();
                GridViewAdminClaims.EditIndex = -1;
                bindGrid();
            }
            catch (Exception exc)
            {
                throw exc;
            }            
        }

        protected void GridViewAdminClaims_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewAdminClaims.EditIndex = e.NewEditIndex;
            //HiddenField1.Value = e.NewEditIndex.ToString();
            bindGrid();
        }

        protected void GridViewAdminClaims_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewAdminClaims.EditIndex = -1;
            bindGrid();
        }

        public int datawrapper(int ClaimID, string ClaimStatus, string flag)
        {
            try
            {
                SqlCommand gridUpdate = new SqlCommand("update Claim set ClaimStatus='"+ClaimStatus+"' where ClaimID="+ClaimID, connection);
                gridUpdate.CommandType = CommandType.Text;
                connection.Open();
                //gridUpdate.Parameters.AddWithValue("@ClaimID", ClaimID);
                //gridUpdate.Parameters.AddWithValue("@ClaimStatus", ClaimStatus);
                int val = (int)gridUpdate.ExecuteNonQuery();
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