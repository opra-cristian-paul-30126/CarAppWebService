using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;
using CarAppWebService.Model;

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
        [WebMethod]
        public Announce getAnnounceData(int IdAnunt)
        {
            Announce anunt;
            dsAnnounces = new DataSet();
            Connection.Open();

            daAnnounces = new SqlDataAdapter("SELECT * FROM Anunturi WHERE IdAnunt = @valIdAnunt", Connection);
            daAnnounces.SelectCommand.Parameters.AddWithValue("@valIdAnunt", IdAnunt);
            daAnnounces.Fill(dsAnnounces, "Announces");

            Connection.Close();

            DataRow dr = dsAnnounces.Tables["Announces"].Rows[0];

            int idUser = int.Parse(dr["IdUser"].ToString());
            string caroserie = dr["Caroserie"].ToString();
            string marca = dr["Marca"].ToString();
            string model = dr["Model"].ToString();
            string varianta = dr["Varianta"].ToString();
            int pret = int.Parse(dr["Pret"].ToString());
            int an = int.Parse(dr["AnPrimaInmatriculare"].ToString());
            int km = int.Parse(dr["Kilometri"].ToString());
            int putereCP = int.Parse(dr["Putere"].ToString());
            int putereKW = int.Parse(dr["PutereKW"].ToString());
            string combustibil = dr["Combustibil"].ToString();
            string cutieViteze = dr["CutieViteze"].ToString();
            int cc = int.Parse(dr["CC"].ToString());
            string culoare = dr["Culoare"].ToString();
            string data = dr["DataAdaugareAnunt"].ToString();
            string locatie = dr["Locatie"].ToString();
            string descriere = dr["Descriere"].ToString();
            int idAnunt = int.Parse(dr["IdAnunt"].ToString());
            byte[] imagAnunt = (byte[])dr["ImagineAnunt"];
            byte[] imag1 = (byte[])dr["Imagine1"];
            byte[] imag2 = (byte[])dr["Imagine2"];
            byte[] imag3 = (byte[])dr["Imagine3"];


            Connection.Open();
            daAnnounces = new SqlDataAdapter("SELECT * FROM Users WHERE Id = @valIdUser", Connection);
            daAnnounces.SelectCommand.Parameters.AddWithValue("@valIdUser", idUser);
            daAnnounces.Fill(dsAnnounces, "Users");
            Connection.Close();

            DataRow drn = dsAnnounces.Tables["User"].Rows[0];

            byte[] imUser = (byte[])drn["ImaginePortret"];
            string telefon = drn["Telefon"].ToString();
            string nume = drn["Nume"].ToString();
            string prenume = drn["Prenume"].ToString();

            anunt = new Announce(idAnunt, idUser, marca, model, caroserie, varianta, pret, an, km, putereCP, putereKW, combustibil, cutieViteze, cc, culoare, data, locatie, descriere, imagAnunt, imag1, imag2, imag3);
            return anunt;
        }


    }




}
