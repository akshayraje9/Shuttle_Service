using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using ClassLibraryStoredProcedures;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class DriverUC : System.Web.UI.UserControl
    {

        string name;
        string pickupAdd;
        string dropoffAdd;
        string custName;
        int tUC;
        int rideId;
        string travelDt;
        string pickupTime;

        Class1 c = new Class1();

        public event EventHandler ThresholdReached;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if(Page.IsPostBack == false)
                AddRideDetails();
            //driverLogin();


        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string PickupAddress
        {
            get
            {
                return pickupAdd;
            }
            set
            {
                pickupAdd = value;
            }
        }

        public string DropoffAddress
        {
            get
            {
                return dropoffAdd;
            }
            set
            {
                dropoffAdd = value;
            }
        }

        public string TravelDt
        {
            get
            {
                return travelDt;
            }

            set
            {
                travelDt = value;
            }
        }

        public string PickupTime
        {
            get {
                return pickupTime;
            }

            set {
                pickupTime = value;
            }
        }

        public int RideId
        {
            get {
                return rideId;
            }

            set {
                rideId = value;
            }
        }

        public string CustName
        {
            get
            {
                return custName;
            }
            set
            {
                custName = value;
            }
        }

        public int UCIndex
        {
            get {
                return tUC;
            }

            set {
                tUC = value;
            }
        }

        public void driverLogin()
        {
            XmlDocument docCust = new XmlDocument();

            docCust.Load(Server.MapPath("BookRide.xml"));

            int id = docCust.DocumentElement.ChildNodes.Count;
            id = id - 1;

            txtPickup.Text = docCust.DocumentElement.ChildNodes[id].ChildNodes[1].InnerText;
            txtDropoff.Text = docCust.DocumentElement.ChildNodes[id].ChildNodes[2].InnerText;
        }

        public void AddRideDetails()
        {
            txtCustName.Text = custName;
            txtPickup.Text   = pickupAdd;
            txtDropoff.Text  = dropoffAdd;
            date.Value = Convert.ToDateTime(travelDt).ToString("yyyy-MM-dd");
            time.Value = pickupTime;
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {         
            
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            OnThresholdReached(EventArgs.Empty);
            /*
            string strQry = "Proc_RideSchedule";
            SqlParameter[] sqp = new SqlParameter[2];
            sqp[0] = new SqlParameter("@RideId", rideId );
            sqp[1] = new SqlParameter("@DriverId", Convert.ToInt16(Session["UserId"].ToString()));
               
            int i = 0;
            i = c.ExecuteProc(strQry, sqp);
            */
        }

        
        protected virtual void OnThresholdReached(EventArgs e)
        {
            DriverUC d2 = this;
            if (ThresholdReached != null)
            {
                 ThresholdReached(d2, e);
            }
        }
        
    }
}