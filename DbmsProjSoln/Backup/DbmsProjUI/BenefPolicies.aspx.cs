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
    public partial class BenefPolicies : System.Web.UI.Page
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
                SqlCommand listPolicies = new SqlCommand("spListOfPolicies", connection);
                listPolicies.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(listPolicies);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ViewState["VSTable"] = dt;
                GridViewBenefPolicies.DataSource = dt;
                GridViewBenefPolicies.DataBind();
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

        protected void GridViewBenefPolicies_Sorting(object sender, GridViewSortEventArgs e)
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
                GridViewBenefPolicies.DataSource = view;
                GridViewBenefPolicies.DataBind();
            }
        }

        protected void GridViewBenefPolicies_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewBenefPolicies.PageIndex = e.NewPageIndex;
            bindGrid();
        }

        protected void GridViewBenefPolicies_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridViewBenefPolicies.Rows[e.RowIndex];
            int ID = Convert.ToInt16(row.Cells[2].Text);
            int val = datawrapper(0, 0,"delete");
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

        protected void GridViewBenefPolicies_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewBenefPolicies.Rows[e.RowIndex];
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
            datawrapper(0,0, "update");
            GridViewBenefPolicies.EditIndex = -1;
            bindGrid();
        }

        protected void GridViewBenefPolicies_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewBenefPolicies.EditIndex = e.NewEditIndex;
            //HiddenField1.Value = e.NewEditIndex.ToString();
            bindGrid();
        }

        protected void GridViewBenefPolicies_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewBenefPolicies.EditIndex = -1;
            bindGrid();
        }

        protected void GridViewBenefPolicies_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Enroll"))
            {
                string txtBeneficiaryID = ((Label)Master.FindControl("lblSession")).Text;
                txtBeneficiaryID = "20010";
                int BeneficiaryID = Convert.ToInt16(txtBeneficiaryID);
                int PolicyID = Convert.ToInt32(e.CommandArgument);
                
                //TextBox txtPolicyID = (TextBox)GridViewBenefPolicies.FindControl("PolicyID");
                //int index = Convert.ToInt32(e.CommandArgument);
                //int index = Convert.ToInt32(e.CommandArgument.ToString());
                //int index = int.Parse(e.CommandArgument.ToString());
                //GridViewRow row = GridViewBenefPolicies.Rows[index];

                //int index = Convert.ToInt32(e.CommandArgument.ToString());
                //TextBox txtPolicyID = (TextBox)GridViewBenefPolicies.Rows[index].FindControl("PolicyID");
                //int ID = Convert.ToInt16(row.Cells[2].Text);
                //int PolicyID = Convert.ToInt16(row.Cells[1].Text);
                //int PolicyID = Convert.ToInt16(txtPolicyID.Text);
                //TextBox txtTimeOfMessage = (TextBox)GridViewAdminMessages.FooterRow.FindControl("txtTimeOfMessage");
                //Label lblTimeOfMessage = (Label)GridViewAdminMessages.FooterRow.FindControl("lblTimeOfMessage");
                //lblTimeOfMessage.Text = DateTime.Now.ToString();
                //string txtTimeOfMessage = lblTimeOfMessage.Text;
                
                if ((BeneficiaryID != null) && (PolicyID != null))
                {
                    int val = datawrapper(BeneficiaryID, PolicyID, "enroll");
                    if (val > 0)
                    {
                        Response.Write("Beneficiary:"+BeneficiaryID+" enrolled in Policy:"+PolicyID+" for one year.");
                    }
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

        public int datawrapper(int BeneficiaryID,int PolicyID, string flag)
        {
            try
            {
                SqlCommand gridUpdate = new SqlCommand("spBenefEnrollPolicies", connection);
                gridUpdate.CommandType = CommandType.StoredProcedure;
                connection.Open();
                gridUpdate.Parameters.AddWithValue("@BeneficiaryID", BeneficiaryID);
                gridUpdate.Parameters.AddWithValue("@PolicyID", PolicyID);
                //gridUpdate.Parameters.AddWithValue("@PolicyName", PolicyName);
                //gridUpdate.Parameters.AddWithValue("@PolicyPremium", PolicyPremium);
                //gridUpdate.Parameters.AddWithValue("@MaximumLimit", MaximumLimit);
                //gridUpdate.Parameters.AddWithValue("@Benefits", Benefits);
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