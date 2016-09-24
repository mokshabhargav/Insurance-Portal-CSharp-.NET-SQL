using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using DbmsProjUI;


namespace DbmsProjUI
{
    public partial class UserHomePage : System.Web.UI.Page
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
                SqlCommand listPolicies = new SqlCommand("spSearchForPolicies", connection);
                listPolicies.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(listPolicies);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ViewState["VSTable"] = dt;
                GridViewSearchForPolicies.DataSource = dt;
                GridViewSearchForPolicies.DataBind();
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int age = Convert.ToInt16(txtAge.Text);
            string preferredSpecialist = ddlSpecialist.SelectedValue;

        }
    }
}