using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCWithDI.Repository
{
    public class UserMasterRepository : IUserMasterRepository
    {
        public static string constr = ConfigurationManager.ConnectionStrings["MDMConnectionString"].ConnectionString;
        private SqlDataReader reader;
        DataTable dt = new DataTable();

        public void  Add(UserMaster item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(constr))
                {
                    connection.Open();
                    string query = "insert into UserMaster  values('" + item.Name + "','" + item.EmailID + "','" + item.MobileNo + "')";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(constr))
                {
                    connection.Open();
                    string query = "delete from UserMaster where ID='" + id+ "'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public UserMaster Get(int id)
        {
            try
            {
                UserMaster userMaster = new UserMaster();

                using (SqlConnection connection = new SqlConnection(constr))
                {
                    connection.Open();
                    string query = "select * from UserMaster where ID='" + id + "'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        userMaster.ID = Convert.ToInt32(reader["ID"].ToString());
                        userMaster.Name = reader["Name"].ToString();
                        userMaster.EmailID = reader["EmailID"].ToString();
                        userMaster.MobileNo = reader["MobileNo"].ToString();
                    }
                    connection.Close();
                    return userMaster;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAll()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(constr))
                {
                    UserMaster userMaster = new UserMaster();
                    connection.Open();
                    string query = "select * from UserMaster";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(UserMaster item)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(constr))
                {
                    connection.Open();
                    string query = "update  UserMaster set Name='"+item.Name+ "',EmailID='" + item.EmailID + "',MobileNo='" + item.MobileNo + "' where ID='" + item.ID + "'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}