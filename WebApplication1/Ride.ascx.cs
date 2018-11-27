using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WebApplication1
{
    public partial class Ride : System.Web.UI.UserControl
    {
        string type="";
        bool confValue;
        bool accValue;
        bool rejValue;       
        string typeUser;

        string name;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                setControls();
                lblType.Text = type;
                btnConfirm.Visible = confValue;
               
            }

        }

        public void setControls()
        {
            if(typeUser =="1")
            {
                txtDropoff.Text = "";
                txtDropoff.Enabled = true;

                txtPickup.Text = "";
                txtPickup.Enabled = true;
            }
            else if(typeUser == "2")
            {
                txtDropoff.Enabled = false;
                txtPickup.Enabled = false;
                driverLogin();
            }

        }

        public void driverLogin()
        {
            XmlDocument docCust = new XmlDocument();

            docCust.Load(Server.MapPath("BookRide.xml"));

            int id = docCust.DocumentElement.ChildNodes.Count;
            id = id - 1;

            txtPickup.Text= docCust.DocumentElement.ChildNodes[id].ChildNodes[1].InnerText;
            txtDropoff.Text = docCust.DocumentElement.ChildNodes[id].ChildNodes[2].InnerText;
        }

        public string UCType
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public bool ConfirmR
        {
            get
            {
                return confValue;
            }
            set
            {
                confValue = value;
            }
        }

        public bool AcceptR
        {
            get
            {
                return accValue;
            }
            set
            {
                accValue = value;
            }
        }

        public bool RejectR
        {
            get
            {
                return rejValue;
            }
            set
            {
                rejValue = value;
            }
        }

        public string TypeUser
        {
            get
            {
                return typeUser;
            }

            set
            {
                typeUser = value;
            }
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

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            XmlDocument docCust = new XmlDocument();
            docCust.Load(Server.MapPath("BookRide.xml"));

            XmlElement parentElement = docCust.CreateElement("BookRide");

            XmlElement nameCus = docCust.CreateElement("Name");
            XmlElement pickupAdd  = docCust.CreateElement("Pickup");
            XmlElement dropoffAdd = docCust.CreateElement("Dropoff");

            nameCus.InnerText = name ;
            pickupAdd.InnerText = txtPickup.Text.ToString();
            dropoffAdd.InnerText = txtDropoff.Text.ToString();
            
            parentElement.AppendChild(nameCus);
            parentElement.AppendChild(pickupAdd);
            parentElement.AppendChild(dropoffAdd);

            docCust.DocumentElement.AppendChild(parentElement);
            docCust.Save(Server.MapPath("BookRide.xml"));

        }
    }
}