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
        public DataSet PopulateAnunturi(string marca, string model, string pretMin, string pretMax, string varianta, string combustibil,
            string anMin, string anMax, string ccMin, string ccMax, string cpMin, string cpMax, string kmMin, string kmMax,
            string caroserie, string culoare, string cutieViteze, string locatie)
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
                                                                    "AND CutieDeViteze LIKE @valCutieViteze " +
                                                                    "AND PretDeVanzare BETWEEN @valPretMin AND @valPretMax " +
                                                                    "AND AnPrimaInmatriculare BETWEEN @valAnMin AND @valAnMax " +
                                                                    "AND CapacitateCilindrica BETWEEN @valCCMin AND @valCCMax " +
                                                                    "AND Putere BETWEEN @valPwMin AND @valPwMax " +
                                                                    "AND Kilometri BETWEEN @valKmMin AND @valKmMax " +
                                                                    "AND Locatie LIKE @valLocatie ", Connection);

            if (marca.Equals("Neselectat"))
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valMarca", "%%");
            else
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valMarca", "%" + marca + "%");

            if (model.Equals("Neselectat"))
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valModel", "%%");
            else
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valModel", "%" + model + "%");

            if (varianta.Equals("Neselectat"))
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valVarianta", "%%");
            else
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valVarianta", "%" + varianta + "%");

            if (combustibil.Equals("Neselectat"))
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valCombustibil", "%%");
            else
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valCombustibil", "%" + combustibil + "%");

            if (caroserie.Equals("Neselectat"))
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valCaroserie", "%%");
            else
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valCaroserie", "%" + caroserie + "%");

            if (culoare.Equals("Neselectat"))
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valCuloare", "%%");
            else
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valCuloare", "%" + culoare + "%");

            if (cutieViteze.Equals("Neselectat"))
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valCutieViteze", "%%");
            else
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valCutieViteze", "%" + cutieViteze + "%");

            if (locatie.Equals("Neselectat"))
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valLocatie", "%%");
            else
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valLocatie", "%" + locatie + "%");

            if (Int32.Parse(kmMin) == 0) 
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valKmmin", 0);
            else 
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valKmmin", Int32.Parse(kmMin));

            if (Int32.Parse(kmMax) == 0)
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valKmmax", int.MaxValue);
            else
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valKmmax", Int32.Parse(kmMax));

            if (Int32.Parse(cpMin) == 0) 
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valPwmin", 0);
            else
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valPwmin", Int32.Parse(cpMin));

            if (Int32.Parse(cpMax) == 0) 
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valPwmax", 32767);
            else 
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valPwmax", Int32.Parse(kmMin));

            if (Int32.Parse(ccMin) == 0) 
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valCCmin", 0);
            else 
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valCCmin", Int32.Parse(kmMin));

            if (Int32.Parse(ccMax) == 0) 
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valCCmax", 32767);
            else 
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valCCmax", Int32.Parse(kmMin));

            if (Int32.Parse(anMin) == 0)
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valAnMin", 0);
            else
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valAnMin", anMin);

            if (Int32.Parse(anMax) == 0) 
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valAnMax", 2020);
            else
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valAnMax", Int32.Parse(anMax));

            if (Int32.Parse(pretMin) == 0)
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valPretmin", 0);
            else
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valPretmin", Int32.Parse(pretMin));

            if (Int32.Parse(pretMax) == 0) 
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valPretmax", int.MaxValue);
            else 
                daAnnounces.SelectCommand.Parameters.AddWithValue("@valPretmax", Int32.Parse(pretMax));


            daAnnounces.Fill(dsAnnounces, "Announces");
            Connection.Close();

            return dsAnnounces;
        }
    }
}
