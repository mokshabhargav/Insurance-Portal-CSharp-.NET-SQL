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
using DbmsProjUI;

namespace DbmsProjUI
{
    public partial class AdminHomePage : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection("Data Source=MOKSHA-PC\\MSSQLINSTANCE;Initial Catalog=SJSU_DBMS_PROJ;Integrated Security=True");
        DataTable dt_ddlBid = new DataTable();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Utlity.SessionCheck();            
            //if (((Label)Master.FindControl("lblErrMsg")).Text == "Welcome Admin")
            //{
                if (!IsPostBack)
                {
                    bindGrid();
                    bindgrid2();
                }
            //}
            else
            {
                //((Label)Master.FindControl("lblErrMsg")).Text = "";
                //Response.Redirect("UserLogin.aspx");
            }            
            //SqlCommand ddlBenefId = new SqlCommand("select DISTINCT BeneficiaryID from Beneficiary", connection);
            //ddlBenefId.CommandType = CommandType.Text;
            //connection.Open();
            //SqlDataAdapter ddlSda = new SqlDataAdapter(ddlBenefId);
            //ddlSda.Fill(dt_ddlBid);
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
                GridViewAdminMessages.DataSource = dt;
                GridViewAdminMessages.DataBind();
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
        public void bindgrid2()
        {
            try
            {
                SqlCommand list = new SqlCommand("spAdminNotifications", connection);
                list.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(list);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ViewState["VSTable"] = dt;
                GridViewAdminMessages.DataSource = dt;
                GridViewAdminMessages.DataBind();
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

        //private DataSet GetData(string query)
        //{
        //    string connectionString = "Data Source=MOKSHA-PC\\MSSQLINSTANCE;Initial Catalog=SJSU_DBMS_PROJ;Integrated Security=True";
        //    SqlCommand cmd = new SqlCommand(query);
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        using (SqlDataAdapter sda = new SqlDataAdapter())
        //        {
        //            cmd.Connection = conn;
        //            sda.SelectCommand = cmd;
        //            using (DataSet ds = new DataSet())
        //            {
        //                sda.Fill(ds);
        //                return ds;
        //            }
        //        }
        //    }
        //}

        protected void GridViewAdminMessages_Sorting(object sender, GridViewSortEventArgs e)
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
                GridViewAdminMessages.DataSource = view;
                GridViewAdminMessages.DataBind();
            }
        }

        protected void GridViewAdminMessages_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewAdminMessages.PageIndex = e.NewPageIndex;
            bindGrid();
        }

        protected void GridViewAdminMessages_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridViewAdminMessages.Rows[e.RowIndex];
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

        protected void GridViewAdminMessages_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewAdminMessages.Rows[e.RowIndex];
            int BeneficiaryID = Convert.ToInt16(row.Cells[2].Text);
            //TextBox tbHospitalID = (TextBox)row.FindControl("HospitalID");
            //int HospitalID = Convert.ToInt16(tbHospitalID.Text);
            TextBox tbMsgSubject = (TextBox)row.Cells[3].FindControl("MsgSubject");
            string MsgSubject = tbMsgSubject.Text;
            //TextBox tbTimeOfMessage = (TextBox)row.Cells[4].FindControl("txtTimeOfMessage");
            //tbTimeOfMessage.Text = DateTime.Now.ToString();
            //string TimeOfMessage = tbTimeOfMessage.Text;
            Label lblTimeOfMessage = (Label)GridViewAdminMessages.FooterRow.FindControl("lblTimeOfMessage");
            lblTimeOfMessage.Text = DateTime.Now.ToString();
            string TimeOfMessage = lblTimeOfMessage.Text;
            datawrapper(BeneficiaryID, MsgSubject, TimeOfMessage,"AddMessage");
            GridViewAdminMessages.EditIndex = -1;
            bindGrid();
        }

        protected void GridViewAdminMessages_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewAdminMessages.EditIndex = e.NewEditIndex;
            //HiddenField1.Value = e.NewEditIndex.ToString();
            bindGrid();
        }

        protected void GridViewAdminMessages_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewAdminMessages.EditIndex = -1;
            bindGrid();
        }

        protected void GridViewAdminMessages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Reply"))
            {
                TextBox txtBeneficiaryID = (TextBox)GridViewAdminMessages.FooterRow.FindControl("txtBeneficiaryID");
                TextBox txtMsgSubject = (TextBox)GridViewAdminMessages.FooterRow.FindControl("txtMsgSubject");
                //TextBox txtTimeOfMessage = (TextBox)GridViewAdminMessages.FooterRow.FindControl("txtTimeOfMessage");
                Label lblTimeOfMessage = (Label)GridViewAdminMessages.FooterRow.FindControl("lblTimeOfMessage");
                lblTimeOfMessage.Text = DateTime.Now.ToString();
                string txtTimeOfMessage = lblTimeOfMessage.Text;
                if ((txtBeneficiaryID.Text != "") && (txtMsgSubject.Text != "") && (txtTimeOfMessage != ""))
                {
                    int val=datawrapper(Convert.ToInt16(txtBeneficiaryID.Text), txtMsgSubject.Text, txtTimeOfMessage, "insert");
                    if (val > 0)
                    {
                        Response.Write("Message added");
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
            //else if (e.CommandName.Equals("Reply"))
            //{

            //}
        }
        public int datawrapper(int BeneficiaryID, string MsgSubject, string TimeOfMessage, string flag)
        {
            try
            {
                SqlCommand gridUpdate = new SqlCommand("insert into AllMessages(BeneficiaryID,MsgSubject,TimeOfMessage) values(" + @BeneficiaryID + ",'" + @MsgSubject + "','" + @TimeOfMessage + "')", connection);
                gridUpdate.CommandType=CommandType.Text;
                connection.Open();
                //gridUpdate.Parameters.AddWithValue("@BeneficiaryID", BeneficiaryID);
                //gridUpdate.Parameters.AddWithValue("@MsgSubject", MsgSubject);
                //gridUpdate.Parameters.AddWithValue("@TimeOfMessage", TimeOfMessage);                
                //gridUpdate.Parameters.AddWithValue("@flag", flag);
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

        protected void GridViewAdminMessages_Load(object sender, EventArgs e)
        {
            //lblTimeOfMessage.Text = DateTime.Now.ToString();
        }

        //protected void GridViewAdminMessages_RowDataBound(object sender, GridViewRowEventArgs e)
        //{            
        //    if (e.Row.RowType == DataControlRowType.Footer)
        //    {
        //        //Find the DropDownList in the Row
        //        DropDownList ddlBeneficiaryID = (DropDownList)e.Row.FindControl("ddlBeneficiaryID");
        //        ddlBeneficiaryID.DataSource = GetData("Select DISTINCT BeneficiaryID FROM AllMessages");
        //        ddlBeneficiaryID.DataTextField = "BeneficiaryID";
        //        ddlBeneficiaryID.DataValueField = "BeneficiaryID";
        //        ddlBeneficiaryID.DataBind();

        //        //Add Default Item in the DropDownList
        //        ddlBeneficiaryID.Items.Insert(0, new ListItem("Please select"));

        //        // Select the Country of Customer in DropDownList
        //        string BeneficiaryID = (e.Row.FindControl("BeneficiaryID") as Label).Text;
        //        ddlBeneficiaryID.Items.FindByValue(BeneficiaryID).Selected = true;


        //        //DropDownList ddlBeneficiaryID = (DropDownList)GridViewAdminMessages.FooterRow.FindControl("ddlBeneficiaryID");
        //        //ddlBeneficiaryID.DataSource = dt_ddlBid;
        //        //ddlBeneficiaryID.DataBind();
        //    }
        //}

    }
}