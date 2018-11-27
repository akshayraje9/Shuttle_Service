using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ClassLibraryStoredProcedures;

namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        Class1 c1 = new Class1();

        protected void Page_Load(object sender, EventArgs e)
        {
            string val="";
            if (Session["type"] != null)
            {
                val = Session["type"].ToString();
            }

            string strQry = "Proc_GetMenu_Title";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            SqlParameter[] sqp = new SqlParameter[1];

            if (val != "1" && val != "2" && val != "3")
            {
                sqp[0] = new SqlParameter("@Role", DBNull.Value);
            }
            else
            {
                sqp[0] = new SqlParameter("@Role", Convert.ToInt16(val));
            }

            ds=c1.ExecuteProcPara(strQry, sqp);
            dt = ds.Tables[0];

            menu1.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string titl = "";
                string loc = "";
                titl = dt.Rows[i][0].ToString();
                loc = dt.Rows[i][1].ToString();

                if (titl.Equals("View Profile"))
                {
                    MenuItem mu1;
                    if( val == "2" )
                    {
                        mu1 = new MenuItem(titl, null, null, "WebForm1.aspx");
                    }
                    else if( val == "3")
                    {
                        mu1 = new MenuItem(titl, null, null, "DriverRegistration.aspx");
                    }
                    else
                    {
                        mu1 = new MenuItem(titl, null,null,null);
                    }
                    menu1.Items.Add(mu1);
                }

                else
                {
                    MenuItem m1 = new MenuItem(titl, null, null, loc);
                    menu1.Items.Add(m1);
                }
            }

            /*
            if (val.Equals("2"))
            {
                menu1.Items.Clear();                
                MenuItem a = new MenuItem("Book a Ride");
                MenuItem b = new MenuItem("Current Ride");
                MenuItem c = new MenuItem("Past Rides");
                menu1.Items.Add(a);
                menu1.Items.Add(b);
                menu1.Items.Add(c);
                dvUser.Visible = false;

            }
            else if(val.Equals("3"))
            {
                menu1.Items.Clear();
                MenuItem d = new MenuItem("Accept ride");
                MenuItem e1 = new MenuItem("Ongoing Ride");
                MenuItem f = new MenuItem("Past Rides for drivers");
                menu1.Items.Add(d);
                menu1.Items.Add(e1);
                menu1.Items.Add(f);
            }
            else
            {
                menu1.Items.Clear();
                MenuItem d1 = new MenuItem("Home Page",null,null,"HomePage.aspx");
                MenuItem e2 = new MenuItem("Contact Us",null,null,"ContactUs.aspx");
                menu1.Items.Add(d1);
                menu1.Items.Add(e2);
            }
            */

            if(Session["UserId"] != null)
            {
                dvUser.Visible = true;
                login.InnerText = "SIGN OUT";
                lblValue.Text = Session["firstName"].ToString() +" "+ Session["lastName"].ToString();
                if(val.Equals("2"))
                {
                    lblName.Text = "Customer Name";
                }
                else
                {
                    lblName.Text = "Driver Name";
                }
            }
            else
            {
                dvUser.Visible = false;
                lblName.Text = "";
                lblValue.Text = "";
                login.InnerText = "LOGIN";
            }
        }
    }
}