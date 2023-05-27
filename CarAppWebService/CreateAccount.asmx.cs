using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;

namespace CarAppWebService
{
    /// <summary>
    /// Summary description for CreateAccount
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CreateAccount : System.Web.Services.WebService
    {
        private static string path = AppDomain.CurrentDomain.BaseDirectory;
        private static string dbPath = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\WebServiceDB.mdf;Integrated Security = True";
        private string MasterPass = new StreamReader(path + @"App_Data\masterpass.txt").ReadLine();
        private SqlConnection Connection = new SqlConnection(connectionString: dbPath);
        private SqlDataAdapter daUsers;
        private DataSet dsUsers;

        private DataSet findEmail(String email,bool isAdmin) 
        {
            
            Connection.Open();
            DataSet dsEmails = new DataSet();
            if (isAdmin)
            {
                daUsers = new SqlDataAdapter("SELECT * FROM Admins WHERE Email LIKE @email", Connection);
                daUsers.SelectCommand.Parameters.AddWithValue("@email", email);
                daUsers.Fill(dsEmails, "Users");
            }
            else
            {
                daUsers = new SqlDataAdapter("SELECT * FROM Users WHERE Email LIKE @email", Connection);
                daUsers.SelectCommand.Parameters.AddWithValue("@email", email);
                daUsers.Fill(dsEmails, "Users");
            }
            Connection.Close();
            return dsEmails;
        }

       


        [WebMethod]
        public bool createUserAcount(string nume, string prenume, string email, string parola, string adresa, string telefon, byte[] userImage)
        {
            bool ok = false;
            DataSet checkEmailSet = findEmail(email, false);
            if (checkEmailSet.Tables["Users"].Rows.Count == 0)
            {
                Connection.Open();
                SqlCommand Cmd = new SqlCommand("INSERT INTO Users(Nume, Prenume, Email, Parola, PozaProfil, Adresa, Telefon, isBanned) " +
                                                "VALUES (@Nume, @Prenume, @Email, @Parola, @PozaProfil, @Adresa, @Telefon, @IsBanned)", Connection);

                Cmd.Parameters.AddWithValue("@Nume",       nume);
                Cmd.Parameters.AddWithValue("@Prenume",    prenume);
                Cmd.Parameters.AddWithValue("@Email",      email);
                Cmd.Parameters.AddWithValue("@Parola",     parola);
                Cmd.Parameters.AddWithValue("@Telefon",    telefon);
                Cmd.Parameters.AddWithValue("@Adresa",     adresa);
                Cmd.Parameters.AddWithValue("@PozaProfil", userImage);
                Cmd.Parameters.AddWithValue("@IsBanned",   0);
                Cmd.ExecuteNonQuery();

                Connection.Close();
                ok = true;
            }
            else
            {
                //email existent
                Console.WriteLine("Email deja existent!");
                return ok;
            }

            return ok;
        }

        [WebMethod]
        public bool createAdminAcount(string nume, string prenume, string email, string parola, string contact, byte[] userImage)
        {
            bool ok = false;
            DataSet checkEmailSet = findEmail(email, true);
            if (checkEmailSet.Tables["Admins"]!=null)
            {
                Connection.Open();

                SqlCommand Cmd = new SqlCommand("INSERT INTO Admins(Nume, Prenume, Email, Parola, Contact, PozaProfil) " +
                                                "VALUES (@Nume, @Prenume, @Email, @Parola, @Contact, @PozaProfil)", Connection);

                Cmd.Parameters.AddWithValue("@Nume",       nume);
                Cmd.Parameters.AddWithValue("@Prenume",    prenume);
                Cmd.Parameters.AddWithValue("@Email",      email);
                Cmd.Parameters.AddWithValue("@Parola",     parola);
                Cmd.Parameters.AddWithValue("@Contact",    contact);
                Cmd.Parameters.AddWithValue("@PozaProfil", userImage);
                Cmd.ExecuteNonQuery();

                Connection.Close();
                ok = true;
            }
            return ok;
        }
        

        [WebMethod]
        public bool checkPass(string pass)
        {
            if (!string.IsNullOrEmpty(pass))
            {
                if (pass.Equals(MasterPass))
                return true;
            }
            return false;
        }
    }

    
}
