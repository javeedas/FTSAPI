using ftms_API.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using ftms_API.DataService;

namespace ftms_API.Controllers
{
    public class ftmsController : ApiController
    {

        DAL dal = new DAL();
        // api/ftms/Team
        [AcceptVerbs("GET")]
        [HttpGet]
        public IHttpActionResult GetTeam()
        {
            List<Employee> EmployeeList = new List<Employee>();
            try
            {
                EmployeeList = dal.GetTeam();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                
            }

            return Ok(EmployeeList);

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonObj"></param>
        /// <returns></returns>
        [AcceptVerbs("POST")]
        [HttpPost]
        public IHttpActionResult LoginDetails(JObject jsonObj)
        {
            
            Login loginData = new Login();
            bool responseJson;

            try
            {
                loginData = jsonObj.ToObject<Login>();
                JObject json = new JObject();
                responseJson = dal.ValidateLogin(loginData);         
                //json = JObject.Parse(responseJson);
                return Ok(responseJson);
            }
            catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        
                        
                    }
            return Ok();
        }

        





            ////api/ftms/Validate
            ////[Route("ftms/Login/Validate")]


            ////[HttpPost]
            ////public IHttpActionResult Post(User user)

            ////{
            ////    int returnvalue;
            ////    bool result;
            ////    try
            ////    {

            ////        using (con = new SqlConnection(conStr))
            ////        {
            ////            cmd = new SqlCommand("sp_Userlogin_check", con);
            ////            cmd.CommandType = CommandType.StoredProcedure;
            ////            cmd.Parameters.Add("uname", SqlDbType.VarChar).Value = user.username;
            ////            cmd.Parameters.Add("pass", SqlDbType.VarChar).Value = user.password;
            ////            con.Open();
            ////            returnvalue = Convert.ToInt32(cmd.ExecuteScalar());
            ////            if (returnvalue > 0)
            ////                result = true;
            ////            else
            ////                result = false;

            ////        }
            ////        return Ok();
            ////    }

            ////    catch (Exception ex)
            ////    {
            ////        throw ex;
            ////    }
            ////    finally
            ////    {
            ////        con.Dispose();
            ////        con.Close();
            ////    }
            ////}

            ////[Route("Users/AddUser")]
            //[AcceptVerbs("POST")]
            //    [HttpPost]
            //public IHttpActionResult AddUser(User user)
            //{
            //    int returnvalue;
            //    try
            //    {
            //        using (con = new SqlConnection(conStr))
            //        {

            //            cmd = new SqlCommand("sp_AddUser", con);
            //            cmd.CommandType = CommandType.StoredProcedure;

            //            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = user.name;
            //            cmd.Parameters.Add("@uName", SqlDbType.VarChar).Value = user.name;
            //            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = user.password;
            //            if (user.role == "admin")
            //                cmd.Parameters.Add("@role", SqlDbType.Bit).Value = 1;
            //            else
            //                cmd.Parameters.Add("@role", SqlDbType.Bit).Value = 0;
            //            cmd.Parameters.Add("@tool", SqlDbType.VarChar).Value = user.tool;
            //            con.Open();
            //            returnvalue = cmd.ExecuteNonQuery();
            //        }
            //        return Ok(returnvalue);
            //    }


            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //    finally
            //    {
            //        con.Dispose();
            //        con.Close();
            //    }
            //}

            // Autheticate user
            //api/ftms/Login

            //api/ftms/Login[]


            //Check role of User

            //    public bool IsAdmin(User user)
            //{
            //    int returnvalue;
            //    bool result;
            //    try
            //    {
            //        StringBuilder sb = new StringBuilder();
            //        sb.AppendFormat("select 1 from users where username = {0}", user.username);
            //        using (con = new SqlConnection(conStr))
            //        {
            //            cmd = new SqlCommand(sb.ToString(), con);
            //            con.Open();
            //            returnvalue = Convert.ToInt32(cmd.ExecuteScalar());
            //            if (returnvalue > 0)
            //                result = true;
            //            else
            //                result = false;

            //        }
            //        return result;
            //    }

            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //    finally
            //    {
            //        con.Dispose();
            //        con.Close();
            //    }
            //}


            //Add Member to Team
            //public IHttpActionResult AddEmployee(Employee emp)
            //{
            //    int returnvalue;
            //    try
            //    {
            //        using (con = new SqlConnection(conStr))
            //        {
            //            cmd = new SqlCommand("sp_AddEmployee", con);
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.Parameters.Add("@empId", SqlDbType.Int).Value = emp.empId;
            //            cmd.Parameters.Add("@empName", SqlDbType.VarChar).Value = emp.empName;
            //            cmd.Parameters.Add("@category", SqlDbType.VarChar).Value = emp.category;
            //            cmd.Parameters.Add("@tool", SqlDbType.VarChar).Value = emp.tool;
            //            cmd.Parameters.Add("@designation", SqlDbType.VarChar).Value = emp.designation;
            //            cmd.Parameters.Add("@dob", SqlDbType.Date).Value = emp.dob;
            //            con.Open();
            //            returnvalue = cmd.ExecuteNonQuery();
            //        }
            //        return Ok(returnvalue);
            //    }


            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //    finally
            //    {
            //        con.Dispose();
            //        con.Close();
            //    }


            //}

            //Delete Team Mmber
            //public int Delete(Employee emp)
            //{
            //    int result;
            //    try
            //    {
            //        using (con = new SqlConnection(conStr))
            //        {
            //            con.Open();
            //            cmd = new SqlCommand("sp_DeleteEmployee", con);
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.Parameters.AddWithValue("Id", emp.empId);
            //            result = cmd.ExecuteNonQuery();
            //        }
            //        return result;
            //    }
            //    catch (Exception e)
            //    {
            //        throw new Exception("Error occured while deleting member");
            //    }
            //    finally
            //    {
            //        con.Close();
            //    }

            //}

            //Update method for updating Member

            //public int Update(Employee emp)
            //{
            //    try
            //    {
            //        int returnvalue;
            //        using (con = new SqlConnection(conStr))
            //        {
            //            cmd = new SqlCommand("sp_UpdateMember", con);
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.Parameters.AddWithValue("@empId", emp.empId);
            //            cmd.Parameters.AddWithValue("@empName", emp.empName);
            //            cmd.Parameters.AddWithValue("@category", emp.category);
            //            cmd.Parameters.AddWithValue("@tool", emp.tool);
            //            con.Open();
            //            returnvalue = cmd.ExecuteNonQuery();
            //        }
            //        return returnvalue;
            //    }
            //    catch (Exception e)
            //    {
            //        throw new Exception("Error occured while updating data");
            //    }
            //    finally
            //    {
            //        con.Close();
            //    }
            //}

            //Add EventMethod
            //public int AddEvent(Event events)
            //{
            //    int returnvalue;
            //    try
            //    {
            //        using (con = new SqlConnection(conStr))
            //        {
            //            cmd = new SqlCommand("sp_AddEvent", con);
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.Parameters.Add("@eName", SqlDbType.VarChar).Value = events.eName;
            //            cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = events.eDate;
            //            cmd.Parameters.Add("@eBudget", SqlDbType.Decimal).Value = events.eBudget;
            //            cmd.Parameters.Add("@eStatus", SqlDbType.VarChar).Value = "Pending";
            //            con.Open();
            //            returnvalue = cmd.ExecuteNonQuery();
            //        }
            //        return returnvalue;
            //    }


            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //    finally
            //    {
            //        con.Dispose();
            //        con.Close();
            //    }


            //}
        }
}
