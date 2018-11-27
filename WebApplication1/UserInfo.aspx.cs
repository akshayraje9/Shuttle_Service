using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using ClassLibraryStoredProcedures;
using System.Data.SqlClient;


namespace WebApplication1
{
    public partial class UserInfo : System.Web.UI.Page
    {
        string name;
        string type;
        int userId;
        Class1 c = new Class1();
        static SqlConnection conn = new SqlConnection(@"Data Source = LAPTOP-JUPC546G\SQLEXPRESS2014 ; Initial Catalog = Shuttle; Integrated Security = SSPI");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                if (Session["UserId"] != null)
                {                    
                    name = Session["firstName"].ToString() + " " + Session["lastName"].ToString();
                    type = Session["type"].ToString();
                    userId = Convert.ToInt16(Session["UserId"].ToString());                    
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        public void xmlData()
        {
            XmlDocument docCust = new XmlDocument();
            docCust.Load(Server.MapPath("BookRide.xml"));
            int id = docCust.DocumentElement.ChildNodes.Count;

            for (int i = 0; i < id ; i++)
            {
                DriverUC dc = new DriverUC();
                dc = (DriverUC)Page.LoadControl("DriverUC.ascx");
                dc.Name = name;
                dc.CustName = docCust.DocumentElement.ChildNodes[i].ChildNodes[0].InnerText;
                dc.PickupAddress = docCust.DocumentElement.ChildNodes[i].ChildNodes[1].InnerText;
                dc.DropoffAddress = docCust.DocumentElement.ChildNodes[i].ChildNodes[2].InnerText;              
                //pnlLogin.Controls.Add(dc);
            }
        }

        protected virtual void D_ThresholdReached(object sender, EventArgs e)
        {
            DriverUC d1 = (DriverUC) sender;          
            //pnlLogin.Controls.RemoveAt(d1.UCIndex);
        }

        public void textData()
        {
            string strData;
            StreamReader sr = new StreamReader("C:\\Users\\akshayraje\\Desktop\\WebApplication1\\WebApplication1\\BookRide.txt");

            strData = sr.ReadLine();
            int cnt = 0;

            while (strData != null)
            {
                string[] arr;
                arr = strData.Split('|');

                DriverUC d = new DriverUC();
                d = (DriverUC)Page.LoadControl("DriverUC.ascx");
                d.Name = name;
                d.CustName = arr[0];
                d.PickupAddress = arr[1];
                d.DropoffAddress = arr[2];
                d.UCIndex = cnt;
                d.ThresholdReached += new EventHandler(D_ThresholdReached);
               // pnlLogin.Controls.Add(d);
                strData = sr.ReadLine();
                cnt = cnt + 1;
            }
        }

        [System.Web.Services.WebMethod]
        public static void AddUpdate(string pickup, string dropoff, string datePickup, string timePickup)
        {            
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Session["UserId"] != null)
                {
                    try
                    {                        
                        conn.Open();

                        int i = 0;

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "Proc_BookRide_User";

                        SqlParameter[] sqp = new SqlParameter[5];
                        sqp[0] = new SqlParameter("@UserId", Convert.ToInt32(HttpContext.Current.Session["UserId"].ToString()));
                        sqp[1] = new SqlParameter("@PickupAdd", pickup);
                        sqp[2] = new SqlParameter("@DropoffAdd", dropoff);
                        sqp[3] = new SqlParameter("@PickupTime", Convert.ToDateTime(timePickup).ToString("HH:mm:ss"));
                        sqp[4] = new SqlParameter("@TravelDate", datePickup);
                  
                        cmd.Parameters.AddRange(sqp);

                        i = cmd.ExecuteNonQuery();                        
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
            }
        }

        /*
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
           // AddUpdate();
        }
        */            
    }
}