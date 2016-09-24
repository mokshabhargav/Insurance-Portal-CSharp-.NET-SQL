using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DbmsProjUI;

namespace DbmsProjUI
{
    public static class Utlity
    {
        public static void SessionCheck()
        {
            if (string.IsNullOrEmpty((string)HttpContext.Current.Session["UserName"]))
            {
                HttpContext.Current.Response.Redirect("Home.aspx");
            }
        }
    }
}