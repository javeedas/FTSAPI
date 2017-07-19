using ftms_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ftms_API.DataService
{
    public class DAL
    {
        SqlConnection con;
        SqlCommand cmd;
        string conStr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;




        public bool ValidateLogin(Login loginData)
        {
            bool result;
            using (con = new SqlConnection(conStr))
            {

                int returnvalue;
                cmd = new SqlCommand("sp_Userlogin_check", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("uname", SqlDbType.VarChar).Value = loginData.username;
                cmd.Parameters.Add("pass", SqlDbType.VarChar).Value = loginData.password;
                con.Open();
                returnvalue = Convert.ToInt32(cmd.ExecuteScalar());
                if (returnvalue > 0)
                    result = true;
                else
                    result = false;

            }
            return result;
        }

        public List<Employee> GetTeam()
        {
            List<Employee> emplist = new List<Employee>();
            Employee emps = null;
            try
            {
                using (con = new SqlConnection(conStr))
                {
                    cmd = new SqlCommand("sp_GetTeamDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    // Call Read before accessing data.
                    while (reader.Read())
                    {
                        emps = new Employee();
                        emps.empId = Convert.ToInt32(reader["empId"]);
                        emps.empName = Convert.ToString(reader["empName"]);
                        emps.category = Convert.ToString(reader["category"]);
                        emps.tool = Convert.ToString(reader["tool"]);
                        emps.designation = Convert.ToString(reader["designation"]);
                        emps.dob = Convert.ToDateTime(reader["dob"]);
                        emplist.Add(emps);
                    }
                    // Call Close when done reading.
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }

            return emplist;
        }

    }
}