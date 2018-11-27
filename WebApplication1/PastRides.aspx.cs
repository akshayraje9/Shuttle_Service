using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClassLibraryStoredProcedures;
using System.Data.Sql;
using System.Data.SqlClient; 

namespace WebApplication1
{
    public partial class PastRides : System.Web.UI.Page
    {
        Class1 c = new Class1();
        static SqlConnection conn = new SqlConnection(@"Data Source = LAPTOP-JUPC546G\SQLEXPRESS2014 ; Initial Catalog = Shuttle; Integrated Security = SSPI");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack == false)
            {
                BindData();
                /*
                Session["UserId"] = 1;
                Session["firstName"] = "Akshay";
                Session["lastName"] = "Raje";
                Session["type"] = 2;
                */
            }
        }

        private void BindData()
        {
            DataTable dummy = new DataTable();
            dummy.Columns.Add("Name");
            dummy.Columns.Add("PickupAdd");
            dummy.Columns.Add("DropoffAdd");
            dummy.Columns.Add("TravelDate");
            dummy.Columns.Add("PickupTime");
            dummy.Columns.Add("Type");
            dummy.Rows.Add();
            rptUser.DataSource = dummy;
            rptUser.DataBind();
        }

        /*
        [System.Web.Services.WebMethod]
        public static string GetData()
        {
            try
            {
                conn.Open();                
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "Proc_GetPast_Rides";

                SqlParameter[] sqp = new SqlParameter[2];
                sqp[0] = new SqlParameter("@CustId", Convert.ToInt32(HttpContext.Current.Session["UserId"].ToString()));
                sqp[1] = new SqlParameter("@DriverId", DBNull.Value);
                cmd.Parameters.AddRange(sqp);

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);
                return ds.GetXml();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        */
    }
}