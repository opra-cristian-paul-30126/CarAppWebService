using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;

namespace CarAppWebService
{
    /// <summary>
    /// Summary description for MyAnnouncesServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MyAnnouncesServices : System.Web.Services.WebService
    {
        private static string path = AppDomain.CurrentDomain.BaseDirectory;
        private static string dbPath = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\WebServiceDB.mdf;Integrated Security = True";
        private SqlConnection Connection = new SqlConnection(connectionString: dbPath);
        private SqlDataAdapter daAnnounces;
        private DataSet dsAnnounces;
        [WebMethod]
        public DataSet PopulateGrid(int idUser)
        {
            Connection.Open();
            dsAnnounces = new DataSet();
            daAnnounces = new SqlDataAdapter("SELECT * FROM Announces WHERE IdUser = @idUser ", Connection);
            daAnnounces.SelectCommand.Parameters.AddWithValue("@idUser", idUser);
            daAnnounces.Fill(dsAnnounces, "Announces");
            Connection.Close();
            return dsAnnounces;
        }
    }
}
