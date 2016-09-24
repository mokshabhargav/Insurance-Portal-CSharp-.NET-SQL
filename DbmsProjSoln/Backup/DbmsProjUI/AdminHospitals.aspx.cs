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
    public partial class AdminHospitals : System.Web.UI.Page
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
                SqlCommand listHospitals = new SqlCommand("spAdminListOfHospitals", connection);
                listHospitals.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(listHospitals);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ViewState["VSTable"] = dt;
                GridViewAdminHospitals.DataSource = dt;
                GridViewAdminHospitals.DataBind();
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

        protected void GridViewAdminHospitals_Sorting(object sender, GridViewSortEventArgs e)
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
                GridViewAdminHospitals.DataSource = view;
                GridViewAdminHospitals.DataBind();
            }
        }

        protected void GridViewAdminHospitals_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewAdminHospitals.PageIndex = e.NewPageIndex;
            bindGrid();
        }

        protected void GridViewAdminHospitals_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridViewAdminHospitals.Rows[e.RowIndex];
            int ID = Convert.ToInt16(row.Cells[2].Text);
            int val = datawrapper(ID, "", "", "", "delete");
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

        public int datawrapper(int HospitalID, string HospitalName, string Speciality, string Address, string flag)
        {
            try
            {
                SqlCommand gridUpdate = new SqlCommand("spAdminManageHospitals", connection);
                gridUpdate.CommandType = CommandType.StoredProcedure;
                connection.Open();
                gridUpdate.Parameters.AddWithValue("@HospitalID", HospitalID);
                gridUpdate.Parameters.AddWithValue("@HospitalName", HospitalName);
                gridUpdate.Parameters.AddWithValue("@Speciality", Speciality);
                gridUpdate.Parameters.AddWithValue("@Address", Address);
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

        protected void GridViewAdminHospitals_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewAdminHospitals.Rows[e.RowIndex];
            int HospitalID = Convert.ToInt16(row.Cells[2].Text);
            //TextBox tbHospitalID = (TextBox)row.FindControl("HospitalID");
            //int HospitalID = Convert.ToInt16(tbHospitalID.Text);
            TextBox tbHospitalName = (TextBox)row.Cells[3].FindControl("HospitalName");
            string HospitalName = tbHospitalName.Text;
            TextBox tbSpeciality = (TextBox)row.Cells[4].FindControl("Speciality");
            string Speciality = tbSpeciality.Text;
            TextBox tbAddress = (TextBox)row.Cells[5].FindControl("Address");
            string Address = tbAddress.Text;
            datawrapper(HospitalID, HospitalName, Speciality, Address, "update");
            GridViewAdminHospitals.EditIndex = -1;
            bindGrid();
        }

        protected void GridViewAdminHospitals_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewAdminHospitals.EditIndex = e.NewEditIndex;
            //HiddenField1.Value = e.NewEditIndex.ToString();
            bindGrid();
        }

        protected void GridViewAdminHospitals_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewAdminHospitals.EditIndex = -1;
            bindGrid();
        }

        protected void GridViewAdminHospitals_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                TextBox txtHospitalName = (TextBox)GridViewAdminHospitals.FooterRow.FindControl("txtHospitalName");
                TextBox txtSpeciality = (TextBox)GridViewAdminHospitals.FooterRow.FindControl("txtSpeciality");
                TextBox txtAddress = (TextBox)GridViewAdminHospitals.FooterRow.FindControl("txtAddress");
                if ((txtHospitalName.Text != "")&&(txtSpeciality.Text!="")&&(txtAddress.Text!=""))
                {
                    datawrapper(0, txtHospitalName.Text, txtSpeciality.Text, txtAddress.Text, "insert");
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
        //public void grid()
        //{
        //    SqlCommand listHospitals = new SqlCommand("spListOfHospitals", connection);
        //    listHospitals.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter adap = new SqlDataAdapter(listHospitals);
        //    DataTable dt = new DataTable();
        //    adap.Fill(dt);
        //    ViewState["table"] = dt;
        //    GridViewAdminHospitals.DataSource = dt;
        //    GridViewAdminHospitals.DataBind();
        //}
        //protected void GridViewAdminHospitals_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridViewAdminHospitals.PageIndex = e.NewPageIndex;
        //    grid();
        //}

        //protected void GridViewAdminHospitals_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //GridViewRow row = GridViewAdminHospitals.Rows[e.RowIndex];
        //string username = row.Cells[2].Text;
        //int val = datawrapper(username, "", "","delete");
        //if (val > 0)
        //{
        //    Response.Write("Success");
        //    grid();
        //}
        //else
        //{
        //    Response.Write("failed");
        //}
        //}

        //protected void GridViewAdminHospitals_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //GridViewRow row = GridViewAdminHospitals.Rows[e.RowIndex];
        //string username = row.Cells[2].Text;
        //TextBox tbHospitalName = (TextBox)row.Cells[4].FindControl("HospitalName");
        //string HospitalName = tbHospitalName.Text;
        //TextBox tbSpeciality = (TextBox)row.Cells[5].FindControl("Speciality");
        //string Speciality = tbSpeciality.Text;
        //TextBox tbAddress = (TextBox)row.Cells[9].FindControl("Address");
        //string Address = tbAddress.Text;
        //datawrapper(HospitalName, Speciality, Address, "update");            
        //GridViewAdminHospitals.EditIndex = -1;
        //grid();
        //}

        //protected void GridViewAdminHospitals_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //GridViewAdminHospitals.EditIndex = e.NewEditIndex;
        //grid();
        //}
        //protected void GridViewAdminHospitals_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    try
        //    {
        //DataTable datatable = (DataTable)ViewState["table"];
        //if (datatable != null)
        //{
        //    DataView view = new DataView(datatable);
        //    if (Convert.ToString(ViewState["sort"]).Contains("ASC") || Convert.ToString(ViewState["sort"]) == "")
        //    {
        //        view.Sort = e.SortExpression + " " + "DESC";
        //        ViewState["sort"] = view.Sort.ToString();
        //    }
        //    else
        //    {
        //        view.Sort = e.SortExpression + " " + "ASC";
        //        ViewState["sort"] = view.Sort.ToString();
        //    }
        //    GridViewAdminHospitals.DataSource = view;
        //    GridViewAdminHospitals.DataBind();
        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {

        //    }
        //}

        //protected void GridViewAdminHospitals_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    GridViewAdminHospitals.EditIndex = -1;
        //    grid();
        //}
        //public int datawrapper(string HospitalName, string Speciality, string Address, string flag)
        //{
        //    try
        //    {
        //        SqlCommand gridUpdate = new SqlCommand("AdminHospitals", connection);
        //        gridUpdate.CommandType = CommandType.StoredProcedure;
        //        connection.Open();
        //        gridUpdate.Parameters.AddWithValue("@HospitalName", HospitalName);
        //        gridUpdate.Parameters.AddWithValue("@Speciality", Speciality);
        //        gridUpdate.Parameters.AddWithValue("@Address", Address);
        //        gridUpdate.Parameters.AddWithValue("@flag", flag);
        //        int val = (int)gridUpdate.ExecuteNonQuery();
        //        return val;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //}
    }
}