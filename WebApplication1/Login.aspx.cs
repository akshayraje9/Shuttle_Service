using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.IO;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using ClassLibraryStoredProcedures;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {

        static string strConn = ConfigurationManager.ConnectionStrings["ShuttleConn"].ConnectionString.ToString();
        SqlConnection conn = new SqlConnection(strConn);
        Class1 c1 = new Class1();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserId"] = null;
            Session["firstName"] = null;
            Session["lastName"] = null;
            Session["type"] = null;
        }

        public void VerifyLogin()
        {
            DataSet ds = new DataSet();

            try
            {                
                string strQry = "ss_GetLogin_Details";
                SqlParameter[] sqp = new SqlParameter[2];
                sqp[0] = new SqlParameter("@Email", txtEmail.Text.ToString());
                sqp[1]= new SqlParameter("@Password", txtPassword.Text.ToString());

                ds=c1.ExecuteProcPara(strQry, sqp);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    string pwd = ds.Tables[0].Rows[0][5].ToString();

                    if (pwd.Equals(txtPassword.Text.ToString()))
                    {
                        Session["UserId"]    = ds.Tables[0].Rows[0][0].ToString();
                        Session["firstName"] = ds.Tables[0].Rows[0][2].ToString();
                        Session["lastName"]  = ds.Tables[0].Rows[0][3].ToString();
                        Session["type"]      = ds.Tables[0].Rows[0][1].ToString();
                        Response.Redirect("HomePage.aspx");
                    }
                    else
                    {
                        lblError.Text = "Incorrect EmailID or Password!";
                    }
                }
                else
                {
                    lblError.Text = "Incorrect EmailID or Password!";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }

        public void xmlDoc()
        {
            lblError.Text = "";
            string userName = txtEmail.Text.Trim();
            string pass = txtPassword.Text.Trim();
            bool value = false;

            XmlDocument docCust = new XmlDocument();

            docCust.Load(Server.MapPath("XMLFile1.xml"));

            string verEmail="";
            string verPass="";
            string firstName="";
            string lastName="";
            string typeUser="";

            for (int i=0; i<docCust.DocumentElement.ChildNodes.Count; i++)
            {                
                verEmail = docCust.DocumentElement.ChildNodes[i].ChildNodes[3].InnerText;
                verPass = docCust.DocumentElement.ChildNodes[i].ChildNodes[4].InnerText;
                firstName = docCust.DocumentElement.ChildNodes[i].ChildNodes[0].InnerText;
                lastName = docCust.DocumentElement.ChildNodes[i].ChildNodes[1].InnerText;
                typeUser = docCust.DocumentElement.ChildNodes[i].ChildNodes[5].InnerText;

                if (userName.Equals(verEmail) && pass.Equals(verPass))
                {
                    lblError.Text = "";
                    value = true;
                    break;
                }
            }

            if(value == false)
            {
                lblError.Text = "Incorrect EmailID or Password!";
            }
            else
            {
                Session["firstName"] = firstName;
                Session["lastName"] = lastName;
                Session["type"] = typeUser;
                Response.Redirect("UserInfo.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            VerifyLogin();
        }
    }
}