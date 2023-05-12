using CarAppWebService.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CarAppWebService
{
    /// <summary>
    /// Summary description for LoginService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LoginService : System.Web.Services.WebService
    {
        private static string dbPath = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\WebServiceDB.mdf;Integrated Security = True";
        private SqlConnection Connection = new SqlConnection(connectionString: dbPath);
        private SqlDataAdapter daUsers;
        private SqlDataAdapter daAdmins;
        private DataSet dsUsers;
        private DataSet dsAdmins;

        [WebMethod]
        private DataSet FindEmails(string email, bool isAdmin)
        {
            Console.WriteLine(dbPath);
            DataSet emails = new DataSet();


            if (isAdmin)
            {
                Connection.Open();
                daAdmins = new SqlDataAdapter("SELECT * FROM Admins WHERE Email LIKE @email", Connection);
                daAdmins.SelectCommand.Parameters.AddWithValue("@email", email);
                daAdmins.Fill(emails, "Admins");
                Connection.Close();
            }

            else
            {
                Connection.Open();
                daUsers = new SqlDataAdapter("SELECT * FROM Users WHERE Email LIKE @email", Connection);
                daUsers.SelectCommand.Parameters.AddWithValue("@email", email);
                daUsers.Fill(emails, "Users");
                Connection.Close();
            }

            return emails;
        }

        [WebMethod]
        public bool FoundEmail(string email, bool isAdmin)
        {
            bool isFound = false;

            if (isAdmin)
            {
                dsAdmins = FindEmails(email, isAdmin);
                if (dsAdmins.Tables["Admins"].Rows.Count != 0) isFound = true;
            }
            else
            {
                dsUsers = FindEmails(email, isAdmin);
                if (dsUsers.Tables["Users"].Rows.Count != 0) isFound = true;
            }
            return isFound;
        }


        [WebMethod]
        public bool CheckPassword(string email, string parola, bool isAdmin)
        {
            bool ok = false;
            if (isAdmin)
            {
                dsAdmins = FindEmails(email, isAdmin);
                foreach (DataRow dr in dsAdmins.Tables["Admins"].Rows)
                {
                    if (dr.ItemArray.GetValue(4).ToString().Trim().Equals(parola))
                    {
                        ok = true;
                        break;
                    }
                }
            }
            else
            {
                dsUsers = FindEmails(email, isAdmin);
                foreach (DataRow dr in dsUsers.Tables["Users"].Rows)
                {
                    if (dr.ItemArray.GetValue(3).ToString().Trim().Equals(parola))
                    {
                        ok = true;
                        break;
                    }
                }
            }
            return ok;
        }

        [WebMethod]
        public Admin ReturnAdmin(string email)
        {
            DataSet emails = new DataSet();
            Admin admin;

            Connection.Open();
            daUsers = new SqlDataAdapter("SELECT * FROM Admins WHERE Email LIKE @email", Connection);
            daUsers.SelectCommand.Parameters.AddWithValue("@email", email);
            daUsers.Fill(emails, "Admins");
            Connection.Close();

            DataRow dr = emails.Tables["Admins"].Rows[0];
            int id = Int32.Parse(dr["Id"].ToString());
            string nume = dr["Nume"].ToString();
            string prenume = dr["Prenume"].ToString();
            string email2 = dr["Email"].ToString();
            string contact = dr["Contact"].ToString();
            string observatii = dr["Observatii"].ToString();
            byte[] imageArray = (byte[])dr["ImaginePortret"];

            admin = new Admin(id, nume, prenume, email2, imageArray, contact);
            return admin;
        }

        [WebMethod]
        public User ReturnUser(string email)
        {
            DataSet emails = new DataSet();
            User user;


            Connection.Open();
            daUsers = new SqlDataAdapter("SELECT * FROM Users WHERE Email LIKE @email", Connection);
            daUsers.SelectCommand.Parameters.AddWithValue("@email", email);
            daUsers.Fill(emails, "Users");
            Connection.Close();

            DataRow dr = emails.Tables["Users"].Rows[0];
            int id = Int32.Parse(dr["Id"].ToString());
            string nume = dr["Nume"].ToString();
            string prenume = dr["Prenume"].ToString();
            string email2 = dr["Email"].ToString();
            string telefon = dr["Telefon"].ToString();
            string adresa = dr["Adresa"].ToString();
            int nrAnunturi = Int32.Parse(dr["NrAnunturi"].ToString());

            int isBanned;
            if (dr["IsBanned"].ToString().Equals("0")) isBanned = 0;
            else isBanned = 1;

            byte[] imageArray = (byte[])dr["PozaProfil"];

            user = new User(id, nume, prenume, email, adresa, telefon, isBanned, imageArray);

            return user;
        }


    }
}

