using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Data;
using ClassLibraryStoredProcedures;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        static string strConn = ConfigurationManager.ConnectionStrings["ShuttleConn"].ConnectionString.ToString();
        SqlConnection conn = new SqlConnection(strConn);

        Class1 c1 = new Class1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack == false)
            {
                txtPassword.Attributes["type"] = "password";
                txtConfPass.Attributes["type"] = "password";
                SetControl();
                GetSecurity_Question();
            }
        }

        public void GetSecurity_Question()
        {
            DataSet ds = new DataSet();
                     
            string strQry = "proc_getsecurity_qt";
            ds=c1.ExecuteProcWOPara(strQry);

            ddlSecurity.DataSource = ds.Tables[0];
            ddlSecurity.DataTextField = "question";
            ddlSecurity.DataValueField = "qtid";
            ddlSecurity.DataBind();
        }
        
        public void SetControl()
        {
            if (Session["UserId"] != null)
            {
                txtFirstName.Enabled = false;
                txtLastName.Enabled = false;
                txtPhoneNumber.Enabled = false;
                txtDOB.Disabled = true;
                txtEmail.Enabled = false;
                txtPassword.Enabled = false;
                txtConfPass.Enabled = false;
                ddlSecurity.Enabled = false;
                txtSecurity.Enabled = false;
                chkRobot.Enabled = false;
                chkTC.Enabled = false;
                btnUpdate.Visible = true;
                btnValidate.Visible = false;
                btnSubmit.Visible = false;

                string strUserId = Session["UserId"].ToString();
                DataSet ds = new DataSet();
                string strQry1 = "ss_GetUser_Info";
                SqlParameter[] sqp = new SqlParameter[1];
                sqp[0] = new SqlParameter("@Id", Convert.ToInt32(strUserId));
                ds=c1.ExecuteProcPara(strQry1, sqp);

                txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                txtPhoneNumber.Text= ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
                txtDOB.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["DOB"]).ToString("yyyy-MM-dd");
                txtEmail.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
                txtPassword.Text = ds.Tables[0].Rows[0]["Password"].ToString();
                txtConfPass.Text = ds.Tables[0].Rows[0]["Password"].ToString();
                ddlSecurity.SelectedIndex = Convert.ToInt16(ds.Tables[0].Rows[0]["SecQt"].ToString())-1;
                txtSecurity.Text = ds.Tables[0].Rows[0]["SecAns"].ToString();
            }
            else
            {

                txtFirstName.Enabled = true;
                txtLastName.Enabled = true;
                txtPhoneNumber.Enabled = true;
                txtDOB.Disabled = false;
                txtEmail.Enabled = true;
                txtPassword.Enabled = true;
                txtConfPass.Enabled = true;
                ddlSecurity.Enabled = true;
                txtSecurity.Enabled = true;
                chkRobot.Enabled = true;
                chkTC.Enabled = true;
                btnUpdate.Visible = false;
                btnValidate.Visible = false;
                btnSubmit.Visible = true;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (EmailIsReg(txtEmail.Text.Trim()) == true)
            {
                lblDup.Text = "This Email ID is already registered for a user";
            }
            else
            {
                lblDup.Text = "";

                int i1 = 0;
                i1 = AddUpdateUser();
                if (i1 > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Registration Successful');", true);
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Registration Failed');", true);
                }                
            }          
        }
        
        public bool EmailIsReg(string email)
        {            
            DataSet dsDup = new DataSet();
                        
            string strQry1 = "Proc_getUser_EmailId";
            SqlParameter[] sd = new SqlParameter[1];
            sd[0] = new SqlParameter("@Email", email);

            dsDup = c1.ExecuteProcPara(strQry1, sd);
            
            if(dsDup.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SaveXML()
        {
            XmlDocument docCust = new XmlDocument();

            docCust.Load(Server.MapPath("XMLFile1.xml"));

            XmlElement parentElement = docCust.CreateElement("Customer");

            XmlElement firstName = docCust.CreateElement("FirstName");
            XmlElement lastName = docCust.CreateElement("LastName");
            XmlElement dob = docCust.CreateElement("DateOfBirth");
            XmlElement emailID = docCust.CreateElement("EmailID");
            XmlElement password = docCust.CreateElement("Password");

            firstName.InnerText = txtFirstName.Text;
            lastName.InnerText = txtLastName.Text;
            dob.InnerText = txtDOB.Value.ToString();
            emailID.InnerText = txtEmail.Text;
            password.InnerText = txtPassword.Text;

            parentElement.AppendChild(firstName);
            parentElement.AppendChild(lastName);
            parentElement.AppendChild(dob);
            parentElement.AppendChild(emailID);
            parentElement.AppendChild(password);

            docCust.DocumentElement.AppendChild(parentElement);

            docCust.Save(Server.MapPath("XMLFile1.xml"));

            Response.Redirect("WebForm2.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;
            txtPhoneNumber.Enabled = true;
            txtDOB.Disabled = false;
            txtEmail.Enabled = true;
            txtPassword.Enabled = true;
            txtConfPass.Enabled = true;
            ddlSecurity.Enabled = true;
            txtSecurity.Enabled = true;
            chkRobot.Enabled = true;
            chkTC.Enabled = true;
            btnValidate.Visible = true;
        }

        public int AddUpdateUser()
        {     

            SqlParameter[] sp1 = new SqlParameter[14];

            sp1[0] = new SqlParameter("@Type", 2);
            sp1[1] = new SqlParameter("@FirstName", txtFirstName.Text.ToString());
            sp1[2] = new SqlParameter("@LastName", txtLastName.Text.ToString());

            if (txtPhoneNumber.Text == "")
                sp1[3] = new SqlParameter("@PhoneNum", DBNull.Value);
            else
                sp1[3] = new SqlParameter("@PhoneNum", txtPhoneNumber.Text.ToString());

            sp1[4] = new SqlParameter("@DOB", txtDOB.Value.ToString());

            sp1[5] = new SqlParameter("@EmailId", txtEmail.Text.ToString());

            sp1[6] = new SqlParameter("@Password", txtPassword.Text.ToString());

            sp1[7] = new SqlParameter("@SecQt", Convert.ToInt16(ddlSecurity.SelectedValue));

            sp1[8] = new SqlParameter("@SecAns", txtSecurity.Text.ToString());

            sp1[9] = new SqlParameter("@DLNum", DBNull.Value);

            sp1[10] = new SqlParameter("@LicenseType", DBNull.Value);

            sp1[11] = new SqlParameter("@VehicleReg", DBNull.Value);

            sp1[12] = new SqlParameter("@SSN", DBNull.Value);

            if( Session["UserId"] == null)
            {
                sp1[13] = new SqlParameter("@IdUser", DBNull.Value);
            }
            else
            {
                string userId = Session["UserId"].ToString();
                sp1[13] = new SqlParameter("@IdUser", Convert.ToInt16(userId) );
            }

            int i = 0;
            i = c1.ExecuteProc("proc_saveUser_Info", sp1);

            return i;
        }

        protected void btnValidate_Click(object sender, EventArgs e)
        {
            int i2 = 0;

            i2 = AddUpdateUser();
            if (i2 > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Profile Updated Successfully');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Profile not Updated');", true);
            }
        }    
    }
}