using CarAppWebService.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Services;

namespace CarAppWebService
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AdminService : System.Web.Services.WebService
    {
        private static string path = AppDomain.CurrentDomain.BaseDirectory;
        private static string dbPath = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\WebServiceDB.mdf;Integrated Security = True";
        private SqlConnection Connection = new SqlConnection(connectionString: dbPath);
        private SqlDataAdapter daUsers;
        private DataSet dsUsers;

        [WebMethod]
        public DataSet PopulateUsers(bool isBanned)
        {
            dsUsers = new DataSet();
            Connection.Open();

            if (isBanned)
            {
                daUsers = new SqlDataAdapter("SELECT * FROM Users WHERE IsBanned = 1", Connection);
                daUsers.Fill(dsUsers, "Users");

            }
            else
            {
                daUsers = new SqlDataAdapter("SELECT * FROM Users WHERE IsBanned = 0", Connection);
                daUsers.Fill(dsUsers, "Users");
            }

            Connection.Close();
            return dsUsers;

        }

        [WebMethod]
        public void banUser(int id)
        {

            Connection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Users SET IsBanned = 1 WHERE Id  = @Id", Connection);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            Connection.Close();

            Connection.Open();
            cmd = new SqlCommand("DELETE FROM Announces WHERE IdUser = @Id", Connection);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            Connection.Close();

        }

        [WebMethod]
        public void unbanUser(int id)
        {
            Connection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Users SET IsBanned = 0 WHERE Id = @Id", Connection);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }



        [WebMethod]
        public void deleteUser(int id)
        {
            Connection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Announces WHERE IdUser = @Id", Connection);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            Connection.Close();

            Connection.Open();
            cmd = new SqlCommand("DELETE FROM Users WHERE Id = @Id", Connection);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
    }
}
