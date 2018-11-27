using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibraryStoredProcedures
{
    
     public class Class1
    {
        SqlConnection conn = new SqlConnection(@"Data Source = LAPTOP-JUPC546G\SQLEXPRESS2014 ; Initial Catalog = Shuttle; Integrated Security = SSPI");
            

        public DataSet ExecuteProcWOPara(string sp1)
        {
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp1;

                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }

        public DataSet ExecuteProcPara(string sp2, SqlParameter[] sqp2)
        {
            DataSet ds1 = new DataSet();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp2;
                cmd.Parameters.AddRange(sqp2);

                SqlDataAdapter ad1 = new SqlDataAdapter(cmd);
                ad1.Fill(ds1);
            }
            catch (Exception ex)
            {
              throw ex;
            }
            finally
            {
                conn.Close();
            }
            return ds1;
        }

        public int ExecuteProc(string sp, SqlParameter []sqlP)
        {
            int i = 0;
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp;
                                
                cmd.Parameters.AddRange(sqlP);
                
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

            return i;
        }

        public int ExecuteProcWOParameter(string sp)
        {
            int i = 0;
            try
            {

                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp;


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

            return i;
        }


    }
}
