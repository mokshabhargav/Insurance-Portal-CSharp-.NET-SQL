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
    public partial class UserPolicies : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection("Data Source=MOKSHA-PC\\MSSQLINSTANCE;Initial Catalog=SJSU_DBMS_PROJ;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGrid();
            }
        }

        public void bindGrid()
        {
            try
            {
                SqlCommand listPolicies = new SqlCommand("spListOfPolicies", connection);
                listPolicies.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(listPolicies);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ViewState["VSTable"] = dt;
                GridViewUserPolicies.DataSource = dt;
                GridViewUserPolicies.DataBind();
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

        protected void GridViewUserPolicies_Sorting(object sender, GridViewSortEventArgs e)
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
                GridViewUserPolicies.DataSource = view;
                GridViewUserPolicies.DataBind();
            }
        }

        protected void GridViewUserPolicies_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewUserPolicies.PageIndex = e.NewPageIndex;
            bindGrid();
        }

        protected void GridViewUserPolicies_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewUserPolicies.EditIndex = -1;
            bindGrid();
        }

        protected void GridViewUserPolicies_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridViewUserPolicies.Rows[e.RowIndex];
            int ID = Convert.ToInt16(row.Cells[2].Text);
            int val = datawrapper(ID, "", 0, 0, "", "delete");
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

        protected void GridViewUserPolicies_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewUserPolicies.Rows[e.RowIndex];
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
            datawrapper(PolicyID, PolicyName, PolicyPremium, MaximumLimit, Benefits, "update");
            GridViewUserPolicies.EditIndex = -1;
            bindGrid();
        }

        protected void GridViewUserPolicies_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewUserPolicies.EditIndex = e.NewEditIndex;
            //HiddenField1.Value = e.NewEditIndex.ToString();
            bindGrid();
        }

        protected void GridViewUserPolicies_RowCommand(object sender, GridViewCommandEventArgs e)
        {

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