using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;
using CarAppWebService.Model;

namespace CarAppWebService
{
    /// <summary>
    /// Summary description for BrowseService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BrowseService : System.Web.Services.WebService
    {
        private static string path = AppDomain.CurrentDomain.BaseDirectory;
        private static string dbPath = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\WebServiceDB.mdf;Integrated Security = True";
        private SqlConnection Connection = new SqlConnection(connectionString: dbPath);
        private SqlDataAdapter daAnnounces;
        private DataSet dsAnnounces;

        [WebMethod]
        public DataSet PopulateAnunturi(string marca, string model, string pretMin, string pretMax, string varianta, 
                                        string combustibil, string anMin, string anMax, string ccMin, string ccMax, 
                                        string putereCPMin, string putereCPMax, string kmMin, string kmMax, string caroserie,
                                        string culoare, string cutieViteze, string locatie)
        {

            Connection.Open();
            
            dsAnnounces = new DataSet();
            daAnnounces = new SqlDataAdapter("SELECT * FROM Announces WHERE " +
                                             "Marca LIKE @valMarca " +
                                             "AND Model LIKE @valModel " +
                                             "AND Varianta LIKE @valVarianta " +
                                             "AND Combustibil LIKE @valCombustibil " +
                                             "AND Caroserie LIKE @valCaroserie " +
                                             "AND Culoare LIKE @valCuloare " +
                                             "AND CutieViteze LIKE @valCutieViteze " +
                                             "AND Pret BETWEEN @valPretMin AND @valPretMax " +
                                             "AND AnPrimaInmatriculare BETWEEN @valAnMin AND @valAnMax " +
                                             "AND CC BETWEEN @valCCMin AND @valCCMax " +
                                             "AND Putere BETWEEN @valPutereMin AND @valPutereMax " +
                                             "AND Kilometri BETWEEN @valKmMin AND @valKmMax " +
                                             "AND Locatie LIKE @valLocatie ", Connection);



            // --------------------------------------MARCA--------------------------------------
            if (marca.Equals("Neselectat"))
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valMarca", "%%");
            else
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valMarca", "%" + marca + "%");
            
            // --------------------------------------MODEL--------------------------------------
            if (model.Equals("Neselectat"))
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valModel", "%%");
            else
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valModel", "%" + model + "%");
            
            // ------------------------------------VARIANTA------------------------------------
            if (varianta.Equals("Neselectat"))
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valVarianta", "%%");
            else
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valVarianta", "%" + varianta + "%");
            
            // -----------------------------------COMBUSTIBIL-----------------------------------
            if (combustibil.Equals("Neselectat"))
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valCombustibil", "%%");
            else
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valCombustibil", "%" + combustibil + "%");
            // -----------------------------------CAROSERIE-----------------------------------
            if (caroserie.Equals("Neselectat"))
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valCaroserie", "%%");
            else
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valCaroserie", "%" + caroserie + "%");
            
            // -------------------------------------CULOARE-------------------------------------
            if (culoare.Equals("Neselectat"))
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valCuloare", "%%");
            else
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valCuloare", "%" + culoare + "%");

            // -----------------------------------CUTIE VITEZE-----------------------------------
            if (cutieViteze.Equals("Neselectat"))
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valCutieViteze", "%%");
            else
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valCutieViteze", "%" + cutieViteze + "%");

            // -------------------------------------LOCATIE-------------------------------------
            if (locatie.Equals("Neselectat"))
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valLocatie", "%%");
            else
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valLocatie", "%" + locatie + "%");

            // -------------------------------------Kilometraj-------------------------------------
            if (Int32.Parse(kmMin) == 0) daAnnounces.SelectCommand.Parameters.AddWithValue("@valKmmin", 0);
            else daAnnounces.SelectCommand.Parameters.AddWithValue("@valKmmin", Int32.Parse(kmMin));
            if (Int32.Parse(kmMax) == 0) daAnnounces.SelectCommand.Parameters.AddWithValue("@valKmmax", int.MaxValue);
            else daAnnounces.SelectCommand.Parameters.AddWithValue("@valKmmax", Int32.Parse(kmMin));

            // -------------------------------------PUTERE CP-------------------------------------
            if (Int32.Parse(putereCPMin) == 0) daAnnounces.SelectCommand.Parameters.AddWithValue("@valPutereMin", 0);
            else daAnnounces.SelectCommand.Parameters.AddWithValue("@valPutereMin", Int32.Parse(putereCPMin));
            if (Int32.Parse(putereCPMax) == 0) daAnnounces.SelectCommand.Parameters.AddWithValue("@valPutereMax", 32767);
            else daAnnounces.SelectCommand.Parameters.AddWithValue("@valPutereMax", Int32.Parse(putereCPMax));

            // ----------------------------------------CC----------------------------------------
            if (Int32.Parse(ccMin) == 0) daAnnounces.SelectCommand.Parameters.AddWithValue("@valCCmin", 0);
            else daAnnounces.SelectCommand.Parameters.AddWithValue("@valCCmin", Int32.Parse(ccMin));
            if (Int32.Parse(ccMax) == 0) daAnnounces.SelectCommand.Parameters.AddWithValue("@valCCmax", 32767);
            else daAnnounces.SelectCommand.Parameters.AddWithValue("@valCCmax", Int32.Parse(ccMax));

            // ----------------------------------------AN----------------------------------------
            if (Int32.Parse(anMin) == 0) daAnnounces.SelectCommand.Parameters.AddWithValue("@valAnMin", 0);
            else daAnnounces.SelectCommand.Parameters.AddWithValue("@valAnMin", anMin);
            if (Int32.Parse(anMax) == 0) daAnnounces.SelectCommand.Parameters.AddWithValue("@valAnMax", 2020);
            else daAnnounces.SelectCommand.Parameters.AddWithValue("@valAnMax", Int32.Parse(anMax));

            // ---------------------------------------PRET---------------------------------------
            if (Int32.Parse(pretMin) == 0) daAnnounces.SelectCommand.Parameters.AddWithValue("@valPretmin", 0);
            else daAnnounces.SelectCommand.Parameters.AddWithValue("@valPretmin", Int32.Parse(pretMin));
            if (Int32.Parse(pretMax) == 0) daAnnounces.SelectCommand.Parameters.AddWithValue("@valPretmax", int.MaxValue);
            else daAnnounces.SelectCommand.Parameters.AddWithValue("@valPretmax", Int32.Parse(pretMax));


            daAnnounces.Fill(dsAnnounces, "Announces");
            Connection.Close();

            return dsAnnounces;
        }



        public Announce getAnounceData(int IdAnunt)
        {
            Announce anunt;
            dsAnnounces = new DataSet();
            Connection.Open();

            daAnnounces = new SqlDataAdapter("SELECT * FROM Anunturi WHERE IdAnunt = @valIdAnunt", Connection);
            daAnnounces.SelectCommand.Parameters.AddWithValue("@valIdAnunt", IdAnunt);
            daAnnounces.Fill(dsAnnounces, "Announces");

            Connection.Close();

            DataRow dr = dsAnnounces.Tables["Announces"].Rows[0];

            int idUser         = int.Parse(dr["IdUser"].ToString());
            string caroserie   = dr["Caroserie"].ToString();
            string marca       = dr["Marca"].ToString();
            string model       = dr["Model"].ToString();
            string varianta    = dr["Varianta"].ToString();
            int pret           = int.Parse(dr["Pret"].ToString());
            int an             = int.Parse(dr["AnPrimaInmatriculare"].ToString());
            int km             = int.Parse(dr["Kilometri"].ToString());
            int putereCP       = int.Parse(dr["Putere"].ToString());
            int putereKW       = int.Parse(dr["PutereKW"].ToString());
            string combustibil = dr["Combustibil"].ToString();
            string cutieViteze = dr["CutieViteze"].ToString();
            int cc             = int.Parse(dr["CC"].ToString());
            string culoare     = dr["Culoare"].ToString();
            string data        = dr["DataAdaugareAnunt"].ToString();
            string locatie     = dr["Locatie"].ToString();
            string descriere   = dr["Descriere"].ToString();
            int idAnunt        = int.Parse(dr["IdAnunt"].ToString());
            byte[] imagAnunt   = (byte[])dr["ImagineAnunt"];
            byte[] imag1       = (byte[])dr["Imagine1"];
            byte[] imag2       = (byte[])dr["Imagine2"];
            byte[] imag3       = (byte[])dr["Imagine3"];


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
