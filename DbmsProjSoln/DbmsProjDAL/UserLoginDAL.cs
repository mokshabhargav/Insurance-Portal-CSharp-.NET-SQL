using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DbmsProjBO;

namespace DbmsProjDAL
{
    public class UserLoginDAL
    {
        //string connstring = "Data Source=MOKSHA-PC\\MSSQLSERVER122;Initial Catalog=SJSU_DBMS_Proj;Integrated Security=True";
        //string connstring = "Data Source=ServerName\InstanceName;Initial Catalog=DatabaseName;Integrated Security=True;MultipleActiveResultSets=True";
        //SqlConnection conn = new SqlConnection("Data Source=MOKSHA-PC;Initial Catalog=SJSU_DBMS_Proj;Integrated Security=True;MultipleActiveResultSets=True");
        SqlConnection conn = new SqlConnection(@"Data Source=MOKSHA-PC\MSSQLINSTANCE;Initial Catalog=SJSU_DBMS_PROJ;Integrated Security=True");

        //public int LoginCheck(UserLoginBO boObj)
        //{
            //try
            //{
            //    UserLoginBO boObj1 = new UserLoginBO();
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand("spLoginCheck", conn);
            //    cmd.CommandType = CommandType.StoredProcedure;

            //    cmd.Parameters.AddWithValue("@username", boObj.Username);
            //    cmd.Parameters.AddWithValue("@password", boObj.Password);
            //    int value = (int)cmd.ExecuteScalar();
            //    return value;
            //    /*
            //    SqlDataReader read = cmd.ExecuteReader();
            //    boObj1.Username = (string)read.GetValue(0);
            //    boObj1.Password = (string)read.GetValue(1);
            //     */
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    conn.Close();
            //}
        //}
    }
}
