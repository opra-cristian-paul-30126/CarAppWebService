using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using static System.Net.Mime.MediaTypeNames;

namespace CarAppWebService
{
    /// <summary>
    /// Summary description for CreateAnnouncement
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CreateAnnouncement : System.Web.Services.WebService
    {
        
        private static string dbPath = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\WebServiceDB.mdf;Integrated Security = True";
        private SqlConnection Connection = new SqlConnection(connectionString: dbPath);

        [WebMethod]
        public void addAnnounce(int iduser, string caroserie, string marca, string model, string varianta,
                                int pret, int an, int km, int putere, int puterekw, string combustibil, 
                                string cutieviteze, int cc, string culoare, string locatie, string descriere, 
                                byte[] imageAnnounce, byte[] image1, byte[] image2, byte[] image3)
        {

            Connection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Announces " +
                "                           (IdUser, Caroserie, Marca, Model, Varianta, Pret, " +
                                            "AnPrimaInmatriculare, Kilometri, Putere, Puterekw, Combustibil, CutieViteze, CC, " +
                                            "Culoare, DataAdaugareAnunt, Locatie, Descriere, ImagineAnunt, Imagine1, Imagine2, Imagine3) " +
                                            "VALUES " +
                                            "(@valIdUser, @valCaroserie, @valMarca, @valModel, @valVarianta, @valPretVanzare, " +
                                            "@valAn, @valKilometri, @valPutere, @valPuterekw, @valCombustibil, @valCutieViteze, @valCC, " +
                                            "@valCuloare, @valDataAnunt, @valLocatie, @valDescriere, @valImagineAnunt, @valImagine1, @valImagine2, @valImagine3)", Connection);
            
            
            DateTime thisDay = DateTime.Today;
            string thisDays = thisDay.ToString("d");

            cmd.Parameters.AddWithValue("@valIdUser",        iduser);
            cmd.Parameters.AddWithValue("@valCaroserie",     caroserie);
            cmd.Parameters.AddWithValue("@valMarca",         marca);
            cmd.Parameters.AddWithValue("@valModel",         model);
            cmd.Parameters.AddWithValue("@valVarianta",      varianta);
            cmd.Parameters.AddWithValue("@valPretVanzare", pret);
            cmd.Parameters.AddWithValue("@valAn",            an);
            cmd.Parameters.AddWithValue("@valKilometri",     km);
            cmd.Parameters.AddWithValue("@valPutere",        putere);
            cmd.Parameters.AddWithValue("@valPuterekw",      puterekw);
            cmd.Parameters.AddWithValue("@valCombustibil",   combustibil);
            cmd.Parameters.AddWithValue("@valCutieViteze",   cutieviteze);
            cmd.Parameters.AddWithValue("@valCC",            cc);
            cmd.Parameters.AddWithValue("@valCuloare",       culoare);
            cmd.Parameters.AddWithValue("@valDataAnunt",     thisDays);
            cmd.Parameters.AddWithValue("@valLocatie",       locatie);
            cmd.Parameters.AddWithValue("@valDescriere",     descriere);
            cmd.Parameters.AddWithValue("@valImagineAnunt",  imageAnnounce);
            cmd.Parameters.AddWithValue("@valImagine1",      image1);
            cmd.Parameters.AddWithValue("@valImagine2",      image2);
            cmd.Parameters.AddWithValue("@valImagine3",      image3);
            cmd.ExecuteNonQuery();
            
            Connection.Close();
        }


        [WebMethod]
        public void updateAnnouncee(int CodAnunt, string caroserie, string marca, string model, string varianta,
                                    int pret, int an, int km, int putere, int puterekw, string combustibil,
                                    string cutieviteze, int cc, string culoare, string locatie, string descriere, 
                                    byte[] imgannounce, byte[] img1, byte[] img2, byte[] img3)
        {
            Connection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE " +
                                            "Announces SET Caroserie = @valCaroserie," +
                                            "Marca = @valMarca, " +
                                            "Model = @valModel, " +
                                            "Varianta = @valVarianta, " +
                                            "PretDeVanzare = @valPretDeVanzare, " +
                                            "AnPrimaInmatriculare = @valAnPrimaInmatriculare, " +
                                            "Kilometri = @valKilometri, " +
                                            "Putere = @valPutere, " +
                                            "PutereKw = @valPuterekw, " +
                                            "Combustibil = @valCombustibil, " +
                                            "CutieDeViteze = @valCutieDeViteze, " +
                                            "CapacitateCilindrica = @valCapacitateCilindrica, " +
                                            "Culoare = @valCuloare, " +
                                            "Locatie = @valLocatie, " +
                                            "Descriere = @valDescriere, " +
                                            "ImagineAnunt = @valImagineAnunt, " +
                                            "Imagine1 = @valImagine1, " +
                                            "Imagine2 = @valImagine2, " +
                                            "Imagine3 = @valImagine3 " +
                                            "WHERE " +
                                            "CodAnunt = @CodAnunt", Connection);

            cmd.Parameters.AddWithValue("@CodAnunt",                CodAnunt);
            cmd.Parameters.AddWithValue("@valCaroserie",            caroserie);
            cmd.Parameters.AddWithValue("@valMarca",                marca);
            cmd.Parameters.AddWithValue("@valModel",                model);
            cmd.Parameters.AddWithValue("@valVarianta",             varianta);
            cmd.Parameters.AddWithValue("@valPretDeVanzare",        pret);
            cmd.Parameters.AddWithValue("@valAnPrimaInmatriculare", an);
            cmd.Parameters.AddWithValue("@valKilometri",            km);
            cmd.Parameters.AddWithValue("@valPutere",               putere);
            cmd.Parameters.AddWithValue("@valPuterekw",             puterekw);
            cmd.Parameters.AddWithValue("@valCombustibil",          combustibil);
            cmd.Parameters.AddWithValue("@valCutieDeViteze",        cutieviteze);
            cmd.Parameters.AddWithValue("@valCapacitateCilindrica", cc);
            cmd.Parameters.AddWithValue("@valCuloare",              culoare);
            cmd.Parameters.AddWithValue("@valLocatie",              locatie);
            cmd.Parameters.AddWithValue("@valDescriere",            descriere);
            cmd.Parameters.AddWithValue("@valImagineAnunt",         imgannounce);
            cmd.Parameters.AddWithValue("@valImagine1",             img1);
            cmd.Parameters.AddWithValue("@valImagine2",             img2);
            cmd.Parameters.AddWithValue("@valImagine3",             img3);
            cmd.ExecuteNonQuery();

            Connection.Close();

        }



    }
}
