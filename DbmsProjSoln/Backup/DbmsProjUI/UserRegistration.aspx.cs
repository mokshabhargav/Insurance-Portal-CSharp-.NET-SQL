using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using DbmsProjBO;
using DbmsProjUI;


namespace DbmsProjUI
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection("Data Source=MOKSHA-PC\\MSSQLINSTANCE;Initial Catalog=SJSU_DBMS_PROJ;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            submit.Enabled = false;            
        }

        protected void submit_Click1(object sender, EventArgs e)
        {
            if ((firstname.Text != "") && (lastname.Text != "") && (txtSsn.Text != "") && (Gender.SelectedValue != "") && (txtDateOfBirth.Text != "") && (EmailId.Text != "") && (MobileNo.Text != "") && (txtpassword.Text != "") && (txtpassword.Text == confirmPassword.Text))
            {
                string firstName = firstname.Text;
                string lastName = lastname.Text;
                int ssn = Convert.ToInt32(txtSsn.Text);
                char gender = Convert.ToChar(Gender.SelectedValue.Substring(0, 1));
                DateTime DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
                int age = (DateTime.MinValue + (DateTime.Now - DateOfBirth)).Year - 1;
                string emailID = EmailId.Text;
                int contactNo = Convert.ToInt32(MobileNo.Text);
                string password = txtpassword.Text;
                SqlCommand userRegistration = new SqlCommand("spUserRegistration", connection);
                userRegistration.CommandType = CommandType.StoredProcedure;
                connection.Open();
                userRegistration.Parameters.AddWithValue("@BenefSsn", ssn);
                userRegistration.Parameters.AddWithValue("@BenefFName", firstName);
                userRegistration.Parameters.AddWithValue("@BenefLName", lastName);
                userRegistration.Parameters.AddWithValue("@Age", age);
                userRegistration.Parameters.AddWithValue("@Gender", gender);
                userRegistration.Parameters.AddWithValue("@EmailID", emailID);
                userRegistration.Parameters.AddWithValue("@ContactNo", contactNo);
                SqlParameter outputParam = new SqlParameter("@BenefID", SqlDbType.Int);
                outputParam.Direction = ParameterDirection.Output;
                int BeneficiaryID = Convert.ToInt16(userRegistration.Parameters.Add(outputParam));
                message_label.Text = "User registered successfully with Beneficiary ID=" + BeneficiaryID;
            }
            else
            {
                message_label.Text = "Please fill in all the fields";
            }
            
        }

        protected void login_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }
    }
}