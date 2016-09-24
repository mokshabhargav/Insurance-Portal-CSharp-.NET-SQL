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
    public partial class BenefHomePage : System.Web.UI.Page
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
                //Response.Redirect("UserLogin.aspx");
            }
        }
        public void bindGrid()
        {
            try
            {
                SqlCommand listHospitals = new SqlCommand("spAdminMessages", connection);
                listHospitals.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(listHospitals);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ViewState["VSTable"] = dt;
                GridViewBenefMessages.DataSource = dt;
                GridViewBenefMessages.DataBind();
                //lblTimeOfMessage.Text = DateTime.Now.ToString();
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
        protected void GridViewBenefMessages_Sorting(object sender, GridViewSortEventArgs e)
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
                GridViewBenefMessages.DataSource = view;
                GridViewBenefMessages.DataBind();
            }
        }

        protected void GridViewBenefMessages_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewBenefMessages.Rows[e.RowIndex];
            int BeneficiaryID = Convert.ToInt16(row.Cells[2].Text);
            //TextBox tbHospitalID = (TextBox)row.FindControl("HospitalID");
            //int HospitalID = Convert.ToInt16(tbHospitalID.Text);
            TextBox tbMsgSubject = (TextBox)row.Cells[3].FindControl("MsgSubject");
            string MsgSubject = tbMsgSubject.Text;
            //TextBox tbTimeOfMessage = (TextBox)row.Cells[4].FindControl("txtTimeOfMessage");
            //tbTimeOfMessage.Text = DateTime.Now.ToString();
            //string TimeOfMessage = tbTimeOfMessage.Text;
            Label lblTimeOfMessage = (Label)GridViewBenefMessages.FooterRow.FindControl("lblTimeOfMessage");
            lblTimeOfMessage.Text = DateTime.Now.ToString();
            string TimeOfMessage = lblTimeOfMessage.Text;
            //datawrapper(BeneficiaryID, MsgSubject, TimeOfMessage, "AddMessage");
            GridViewBenefMessages.EditIndex = -1;
            bindGrid();
        }

        protected void GridViewBenefMessages_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewBenefMessages.PageIndex = e.NewPageIndex;
            bindGrid();
        }

        protected void GridViewBenefMessages_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewBenefMessages.EditIndex = -1;
            bindGrid();
        }

        protected void GridViewBenefMessages_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridViewBenefMessages.Rows[e.RowIndex];
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

        protected void GridViewBenefMessages_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewBenefMessages.EditIndex = e.NewEditIndex;
            //HiddenField1.Value = e.NewEditIndex.ToString();
            bindGrid();
        }
    }
}