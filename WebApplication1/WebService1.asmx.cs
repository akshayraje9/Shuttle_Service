using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using ClassLibraryStoredProcedures;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
 
    public class WebService1 : System.Web.Services.WebService
    {

        Class1 c = new Class1();
        
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string GetData1(string id, string type)
        {
            try
            {
                DataSet ds = new DataSet();              
                string qryStr = "Proc_GetPast_Rides";
                
                SqlParameter[] sqp = new SqlParameter[2];
                if (type == "2")
                {
                    sqp[0] = new SqlParameter("@CustId", Convert.ToInt16(id));
                    sqp[1] = new SqlParameter("@DriverId", DBNull.Value);
                }
                else
                {
                    sqp[0] = new SqlParameter("@CustId", DBNull.Value );
                    sqp[1] = new SqlParameter("@DriverId", Convert.ToInt16(id));
                }

                ds= c.ExecuteProcPara(qryStr, sqp);
                return ds.GetXml();
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
}
