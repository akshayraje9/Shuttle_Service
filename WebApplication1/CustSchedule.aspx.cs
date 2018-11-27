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
    public partial class CustSchedule : System.Web.UI.Page
    {

        Class1 c = new Class1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack == false)
                SetControls();
        }

        protected void btnCancelRide_Click(object sender, EventArgs e)
        {
            Button bn =(Button) sender;
            RepeaterItem ri=(RepeaterItem) bn.Parent;
            HiddenField lb = ri.FindControl("rideId") as HiddenField;
            RideCancel(Convert.ToInt16(lb.Value));
        }

        public void SetControls()
        {
            rptUser.Controls.Clear();
            string strQry = "Proc_GetScheduled_Rides";
            SqlParameter[] sqp = new SqlParameter[2];
            DataSet ds = new DataSet();

            if(Session["UserId"] != null)
            {
                if(Session["type"].ToString() == "2")
                {
                    sqp[0] = new SqlParameter("@CustId", Convert.ToInt32(Session["UserId"].ToString()));
                    sqp[1] = new SqlParameter("@DriverId", DBNull.Value);
                }
                else if(Session["type"].ToString() == "3")
                {
                    sqp[0] = new SqlParameter("@CustId", DBNull.Value);
                    sqp[1] = new SqlParameter("@DriverId", Convert.ToInt32(Session["UserId"].ToString()));
                }

                ds = c.ExecuteProcPara(strQry, sqp);
                rptUser.DataSource = ds.Tables[0];
                rptUser.DataBind();
            }
        }

        protected void Myrepeater_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label type = e.Item.FindControl("lblType") as Label;               
                Button cancel = e.Item.FindControl("btnCancelRide") as Button;
                Label userType = e.Item.FindControl("lblDriverName") as Label;


                if (type.Text.Trim().ToUpper() == "RIDE IS CANCELLED")
                {
                     cancel.Visible = false;                   
                }                
                else
                {
                    cancel.Visible = true;  
                }

                if(Session["type"].ToString() == "2")
                {
                    userType.Text = "Driver Name";
                }
                else if(Session["type"].ToString() == "3")
                {
                    userType.Text = "Customer Name";
                }
            }
        }

        private void RideCancel(int DrvId)
        {
            string strQry = "Proc_CancelRide";
            int i = 0;
            SqlParameter[] sql = new SqlParameter[2];
            sql[0] = new SqlParameter("@RideId", DrvId);
            sql[1] = new SqlParameter("@UserType", Convert.ToInt16(Session["type"].ToString()));

            i = c.ExecuteProc(strQry, sql);
            if (i > 0)
            {
                SetControls();
            }
        }        
    }
}