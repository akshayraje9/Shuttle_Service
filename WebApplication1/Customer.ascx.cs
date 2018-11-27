using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Data.SqlClient;
using ClassLibraryStoredProcedures;
using System.Data;
using System.Configuration;

namespace WebApplication1
{
    public partial class Customer : System.Web.UI.UserControl
    {
        string name;
        int userId;
        Class1 c = new Class1();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblSuccess.Text = "";
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

        public int UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
            }
        }

        

        public void xmlSave()
        {
            XmlDocument docCust = new XmlDocument();
            docCust.Load(Server.MapPath("BookRide.xml"));

            XmlElement parentElement = docCust.CreateElement("BookRide");

            XmlElement nameCus = docCust.CreateElement("Name");
            XmlElement pickupAdd = docCust.CreateElement("Pickup");
            XmlElement dropoffAdd = docCust.CreateElement("Dropoff");

            nameCus.InnerText = name;
            pickupAdd.InnerText = txtPickup.Text.ToString();
            dropoffAdd.InnerText = txtDropoff.Text.ToString();

            parentElement.AppendChild(nameCus);
            parentElement.AppendChild(pickupAdd);
            parentElement.AppendChild(dropoffAdd);


            docCust.DocumentElement.AppendChild(parentElement);
            docCust.Save(Server.MapPath("BookRide.xml"));

        }


        public void textSave()
        {
            string strBookRide = name + "|" + txtPickup.Text.Trim() + "|" + txtDropoff.Text.Trim(); 
            StreamWriter sw = new StreamWriter("C:\\Users\\akshayraje\\Desktop\\WebApplication1\\WebApplication1\\BookRide.txt", true);
            sw.WriteLine(strBookRide);
            sw.Close();
        }


        public void AddUpdate()
        {
            try
            {

                lblSuccess.Text = "";
                int i = 0;
                string strQry = "Proc_BookRide_User";


                SqlParameter[] sqp = new SqlParameter[3];
                sqp[0] = new SqlParameter("@UserId", userId);
                sqp[1] = new SqlParameter("@PickupAdd", txtPickup.Text.ToString());
                sqp[2] = new SqlParameter("@DropoffAdd", txtDropoff.Text.ToString());

                ///sqp[3] = new SqlParameter("@PickupTime", DBNull.Value);
                // sqp[4] = new SqlParameter("@TravelDate", DBNull.Value);
                // sqp[3] = new SqlParameter("@PickupTime", Convert.ToDateTime(time.Value).ToString("HH:mm:ss"));
                // sqp[4] = new SqlParameter("@TravelDate", Convert.ToDateTime(date));


                i = c.ExecuteProc(strQry, sqp);
                if (i > 0)
                {
                    lblSuccess.Text = "Ride booked successfully";
                }
                else
                {
                    lblSuccess.Text = "Ride not booked";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
          
              // xmlSave();
        }
    }
}