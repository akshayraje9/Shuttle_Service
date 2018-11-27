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
    
    public partial class DriverRide : System.Web.UI.Page
    {

        Class1 c = new Class1();

        static List<RideDetail> rd = new List<RideDetail>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                AddRidesRpt();
            }        
        }

        /*
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
                
                d.CustName = arr[0];
                d.PickupAddress = arr[1];
                d.DropoffAddress = arr[2];
                d.UCIndex = cnt;
                
                pnlLogin1.Controls.Add(d);
                strData = sr.ReadLine();
                cnt = cnt + 1;
            }
        }
        */

            /*
        public void AddRides()
        {
           // pnlLogin1.Controls.Clear();
            string strQry = "ss_GetRequests_Driver";
            DataSet ds = new DataSet();

            ds = c.ExecuteProcWOPara(strQry);

            for(int i=0; i< ds.Tables[0].Rows.Count; i++)
            {
                DriverUC d = new DriverUC();
                d = (DriverUC)Page.LoadControl("DriverUC.ascx");
                d.RideId = Convert.ToInt32(ds.Tables[0].Rows[i]["RideId"].ToString());
                d.CustName = ds.Tables[0].Rows[i]["Name"].ToString();
                d.PickupAddress = ds.Tables[0].Rows[i]["PickupAdd"].ToString();
                d.DropoffAddress = ds.Tables[0].Rows[i]["DropoffAdd"].ToString();
                d.TravelDt = ds.Tables[0].Rows[i]["TravelDate"].ToString();
                d.PickupTime = ds.Tables[0].Rows[i]["PickupTime"].ToString();
                d.ThresholdReached += new EventHandler(D_ThresholdReached); 
                pnlLogin1.Controls.Add(d);
            }
        }
        */


        public void AddRidesRpt()
        {
            rd.Clear();

            string strQry = "ss_GetRequests_Driver";
            DataSet ds = new DataSet();

            SqlParameter[] sqp = new SqlParameter[1];

            sqp[0] = new SqlParameter("@DriverId", Convert.ToInt16(Session["UserId"].ToString()));

            ds = c.ExecuteProcPara(strQry, sqp);
             
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                RideDetail d = new RideDetail();
                
                d.RideId = Convert.ToInt32(ds.Tables[0].Rows[i]["RideId"].ToString());
                d.CustName = ds.Tables[0].Rows[i]["Name"].ToString();
                d.PickupAdd = ds.Tables[0].Rows[i]["PickupAdd"].ToString();
                d.DropoffAdd = ds.Tables[0].Rows[i]["DropoffAdd"].ToString();
                d.TravelDt = ds.Tables[0].Rows[i]["TravelDate"].ToString();
                d.PickupTime = ds.Tables[0].Rows[i]["PickupTime"].ToString();

                //rd.Add(d);
                rd.Insert(i, d);              
            }

           // lblRideId.Text= rd.Count.ToString();
            rptUserSchedule.DataSource = rd ;
            rptUserSchedule.DataBind();
           // lblRideId.Text = lblRideId.Text.ToString() + " " + rd.Count.ToString();
        }

        protected virtual void D_ThresholdReached(object sender, EventArgs e)
        {
            DriverUC d1 = (DriverUC)sender;

//            lblName.Text = d1.CustName;
            string strQry = "Proc_RideSchedule";
            SqlParameter[] sqp = new SqlParameter[2];
            sqp[0] = new SqlParameter("@RideId", d1.RideId);
            sqp[1] = new SqlParameter("@DriverId", Convert.ToInt16(Session["UserId"].ToString()));

            int i = 0;
            i = c.ExecuteProc(strQry, sqp);
            //AddRides();
            //Page_Load(this, e);
        }


        protected void btnAccept_Click(object sender, EventArgs e)
        {

            AcceptReject("A", sender);

        }


        public void AcceptReject(string st, object sender1)
        {

            Button btn = (Button)sender1;
            RepeaterItem ri1 = (RepeaterItem)btn.Parent;

            int rdIndex = ri1.ItemIndex;

            string strQry = "Proc_RideSchedule";
            SqlParameter[] sqp = new SqlParameter[3];
            sqp[0] = new SqlParameter("@RideId", rd[rdIndex].RideId);
            sqp[1] = new SqlParameter("@DriverId", Convert.ToInt16(Session["UserId"].ToString()));
            sqp[2] = new SqlParameter("@Status", st );

            int i = 0;
            i = c.ExecuteProc(strQry, sqp);
            if (i > 0)
            {
                AddRidesRpt();
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            AcceptReject("R", sender);
        }
    }
}