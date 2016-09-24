using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace team7H127
{
    public partial class HomeMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuItem item = Menu1.FindItem("Login");
            MenuItem item2 = Menu1.FindItem("Home");
            MenuItem item3 = Menu1.FindItem("Policies");
            MenuItem item4 = Menu1.FindItem("Hospitals");
            MenuItem item5 = Menu1.FindItem("Claim");
            //if (((Label)Master.FindControl("lblErrMsg")).Text == "")
            //{
            //    item.Enabled = true;
            //    item2.Enabled = true;
            //    item3.Enabled = true;
            //    item4.Enabled = true;
            //    item5.Enabled = true;
            //}

            //else
            //{
            //    item.Enabled = false;
            //    item2.Enabled = false;
            //    item3.Enabled = false;
            //    item4.Enabled = false;
            //    item5.Enabled = false;
            //}
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            if (e.Item.Value.ToLower() == "logout")
            {
                //if (Session.Count > 0)
                //{
                //    Session.Abandon();
                //    Session.Clear();
                //}
                //(((Label)Master.FindControl("lblErrMsg")).Text) = "Please Login";
                Response.Redirect("UserLogin.aspx");
            }
        }
    }
}