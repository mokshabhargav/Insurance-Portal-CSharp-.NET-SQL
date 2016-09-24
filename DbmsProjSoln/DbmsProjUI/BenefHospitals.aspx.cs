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
    public partial class BenefHospitals : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection("Data Source=MOKSHA-PC\\MSSQLINSTANCE;Initial Catalog=SJSU_DBMS_PROJ;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            //bindGrid();
            //ListOfHospitals();
            //if (((Label)Master.FindControl("lblErrMsg")).Text == "Welcome Beneficiary")
            //{
                if (!IsPostBack)
                {
                    grid();
                }
            //}
            else
            {
                //((Label)Master.FindControl("lblErrMsg")).Text = "";
                //Response.Redirect("UserLogin.aspx");
            }
        }
        //public void bindGrid()
        //{
        //    ListOfHospitals();
        //}
        //public DataTable ListOfHospitals()
        //{
        //    try 
        //    {	        
        //        SqlCommand listHospitals = new SqlCommand("spListOfHospitals", connection);
        //        listHospitals.CommandType=CommandType.StoredProcedure;
        //        connection.Open();
        //        SqlDataAdapter da=new SqlDataAdapter(listHospitals);
        //        DataTable dt=new DataTable();
        //        return dt;
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //}
        public void grid()
        {
            SqlCommand listHospitals = new SqlCommand("spListOfHospitals", connection);
            listHospitals.CommandType=CommandType.StoredProcedure;
            SqlDataAdapter adap = new SqlDataAdapter(listHospitals);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            ViewState["table"] = dt;
            GridViewListHospitals.DataSource = dt;
            GridViewListHospitals.DataBind();
        }

        protected void GridViewListHospitals_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewListHospitals.PageIndex = e.NewPageIndex;
            grid();
        }

        protected void GridViewListHospitals_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridViewListHospitals.Rows[e.RowIndex];
            int ID = Convert.ToInt16(row.Cells[2].Text);
            int val = datawrapper(ID, "", "", "", "delete");
            if (val > 0)
            {
                grid();
                Response.Write("Operation success");
            }
            else
            {
                Response.Write("Operation failed");
            }
        }

        protected void GridViewListHospitals_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewListHospitals.Rows[e.RowIndex];
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
            GridViewListHospitals.EditIndex = -1;
            grid();
        }

        protected void GridViewListHospitals_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewListHospitals.EditIndex = e.NewEditIndex;
            grid();
        }

        protected void GridViewListHospitals_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
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
                    GridViewListHospitals.DataSource = view;
                    GridViewListHospitals.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        protected void GridViewListHospitals_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewListHospitals.EditIndex = -1;
            grid();
        }
        public int datawrapper(int HospitalID, string HospitalName, string Speciality, string Address, string flag)
        {
            try
            {
                SqlCommand gridUpdate = new SqlCommand("spListOfHospitals", connection);
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
    }
}