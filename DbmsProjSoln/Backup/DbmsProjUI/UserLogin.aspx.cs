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
using DbmsProjBO;
using DbmsProjDAL;

namespace DbmsProjUI
{
    public partial class UserLogin : System.Web.UI.Page
    {
        //UserLoginBO boObj = new UserLoginBO();
        //UserLoginDAL dalObj = new UserLoginDAL();
        SqlConnection connection = new SqlConnection("Data Source=MOKSHA-PC\\MSSQLINSTANCE;Initial Catalog=SJSU_DBMS_PROJ;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)Master.FindControl("lblErrMsg")).Text = "Please Login";
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUserName.Text;
                string password = txtPwd.Text;
                SqlCommand loginCheck = new SqlCommand("spLoginCheck", connection);
                loginCheck.CommandType = CommandType.StoredProcedure;
                connection.Open();
                loginCheck.Parameters.AddWithValue("@username", username);
                loginCheck.Parameters.AddWithValue("@password", password);
                //loginCheck.Parameters.AddWithValue("@cid", cPid.ClaimId);
                SqlParameter out1 = new SqlParameter("@out", SqlDbType.Int);
                out1.Direction = ParameterDirection.ReturnValue;
                loginCheck.Parameters.Add(out1);
                loginCheck.ExecuteScalar();
                int val = Convert.ToInt16(loginCheck.Parameters["@out"].Value);
                //loginCheck.ExecuteNonQuery();
                //int val=Convert.ToInt32(loginCheck.Parameters["ReturnValue"].Value;            
                //loginCheck.Parameters.AddWithValue("@out", 0);
                //int val = Convert.ToInt16(loginCheck.ExecuteScalar());
                if (val == 1)
                {
                    ((Label)Master.FindControl("lblErrMsg")).Text = "Welcome Beneficiary";
                    ((Label)Master.FindControl("lblSession")).Text = username;
                    Response.Redirect("BenefPolicies.aspx");
                }
                else if (val == 2)
                {
                    ((Label)Master.FindControl("lblErrMsg")).Text = "Welcome Admin";
                    ((Label)Master.FindControl("lblSession")).Text = username;
                    Response.Redirect("AdminHomePage.aspx");
                }
                else
                {
                    ((Label)Master.FindControl("lblErrMsg")).Text = null;
                    Response.Redirect("UserRegistration.aspx");
                }
            }
            finally
            {
                connection.Close();
            }
        }
        /*protected void btnLogin_Click(object sender, ImageClickEventArgs e)
        {
            boObj.Username = txtUserName.Text;
            boObj.Password = txtPwd.Text;
            int value=dalObj.LoginCheck(boObj);
            if (value==1)
            Response.Redirect("Sample.aspx");            
        }*/

        //protected void ButtonLogin_Click(object sender, EventArgs e)
        //{
        //    boObj.Username = txtUserName.Text;
        //    boObj.Password = txtPwd.Text;
        //    /*
        //    boObj = dalObj.LoginCheck(boObj);
        //    lblLogin.Text = "Username=" + boObj.Username +"Password="+boObj.Password;
        //    */
        //    int value = dalObj.LoginCheck(boObj);
        //    if ((value == 1)&&(txtUserName.Text=="90100"))
        //    {
        //        Response.Redirect("AdminHomePage.aspx");
        //    }
        //    else if ((value == 1) && (txtUserName.Text != "90100"))
        //    {
        //        Response.Redirect("BenefHomePage.aspx");
        //    }
        //    else
        //    {
        //        ButtonLogin.Visible = false;
        //        lblLogin.Visible = true;
        //        lblLogin.Text = "Incorrect credentials. Please re-enter correct credentials.";
        //    }
        //}
    }
}