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
    public partial class AdminPolicies : System.Web.UI.Page
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
                SqlCommand listPolicies = new SqlCommand("spAdminListOfPolicies", connection);
                listPolicies.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(listPolicies);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ViewState["VSTable"] = dt;
                GridViewAdminPolicies.DataSource = dt;
                GridViewAdminPolicies.DataBind();
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

        protected void GridViewAdminPolicies_Sorting(object sender, GridViewSortEventArgs e)
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
                GridViewAdminPolicies.DataSource = view;
                GridViewAdminPolicies.DataBind();
            }
        }

        protected void GridViewAdminPolicies_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewAdminPolicies.PageIndex = e.NewPageIndex;
            bindGrid();
        }

        protected void GridViewAdminPolicies_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridViewAdminPolicies.Rows[e.RowIndex];
            int ID = Convert.ToInt16(row.Cells[2].Text);
            int val = datawrapper(ID, "", 0,0, "", "delete");
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

        protected void GridViewAdminPolicies_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewAdminPolicies.Rows[e.RowIndex];
            int PolicyID = Convert.ToInt16(row.Cells[2].Text);
            //TextBox tbHospitalID = (TextBox)row.FindControl("HospitalID");
            //int HospitalID = Convert.ToInt16(tbHospitalID.Text);
            TextBox tbPolicyName = (TextBox)row.Cells[3].FindControl("PolicyName");
            string PolicyName = tbPolicyName.Text;

            //TextBox tbPolicyPremium = (TextBox)row.Cells[4].FindControl("PolicyPremium");
            //string PolicyPremium = tbPolicyPremium.Text;

            int PolicyPremium = Convert.ToInt16(row.Cells[4].Text);
            
            //TextBox tbMaximumLimit = Convert.ToInt16(row.Cells[5].FindControl("MaximumLimit"));
            //int MaximumLimit = tbMaximumLimit.Text;
            
            int MaximumLimit = Convert.ToInt16(row.Cells[5].Text);
            TextBox tbBenefits = (TextBox)row.Cells[3].FindControl("Benefits");
            string Benefits = tbBenefits.Text;
            datawrapper(PolicyID,PolicyName,PolicyPremium,MaximumLimit,Benefits, "update");
            GridViewAdminPolicies.EditIndex = -1;
            bindGrid();
        }

        protected void GridViewAdminPolicies_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewAdminPolicies.EditIndex = e.NewEditIndex;
            //HiddenField1.Value = e.NewEditIndex.ToString();
            bindGrid();
        }

        protected void GridViewAdminPolicies_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewAdminPolicies.EditIndex = -1;
            bindGrid();
        }

        protected void GridViewAdminPolicies_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                TextBox txtPolicyName = (TextBox)GridViewAdminPolicies.FooterRow.FindControl("txtPolicyName");
                string PolicyName = txtPolicyName.Text;
                TextBox txtPolicyPremium = (TextBox)GridViewAdminPolicies.FooterRow.FindControl("txtPolicyPremium");
                int PolicyPremium = Convert.ToInt16(txtPolicyPremium.Text);
                TextBox txtMaximumLimit = (TextBox)GridViewAdminPolicies.FooterRow.FindControl("txtMaximumLimit");
                int MaximumLimit = Convert.ToInt32(txtMaximumLimit.Text);
                TextBox txtBenefits = (TextBox)GridViewAdminPolicies.FooterRow.FindControl("txtBenefits");
                string Benefits = txtBenefits.Text;
                if ((PolicyName != "") && (PolicyPremium != null) && (MaximumLimit != null) && (Benefits != ""))
                {
                    datawrapper(0, PolicyName, PolicyPremium, MaximumLimit, Benefits, "insert");
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

        public int datawrapper(int PolicyID, string PolicyName, int PolicyPremium, int MaximumLimit, string Benefits, string flag)
        {
            try
            {
                SqlCommand gridUpdate = new SqlCommand("spAdminManagePolicies", connection);
                gridUpdate.CommandType = CommandType.StoredProcedure;
                connection.Open();
                gridUpdate.Parameters.AddWithValue("@PolicyID", PolicyID);
                gridUpdate.Parameters.AddWithValue("@PolicyName", PolicyName);
                gridUpdate.Parameters.AddWithValue("@PolicyPremium", PolicyPremium);
                gridUpdate.Parameters.AddWithValue("@MaximumLimit", MaximumLimit);
                gridUpdate.Parameters.AddWithValue("@Benefits", Benefits);
                gridUpdate.Parameters.AddWithValue("@flag", flag);
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