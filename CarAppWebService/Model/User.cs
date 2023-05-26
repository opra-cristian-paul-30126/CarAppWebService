using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace CarAppWebService.Model
{
    public class User
    {
        public int id;
        public string nume, prenume, email, adresa, telefon;
        public bool isBanned;
        public int nrAnunturi;
        public byte[] pozaProfil;

        public User()
        {

        }

        public User(int id, string nume, string prenume,
            string email, string adresa, string telefon, bool isBanned,
            byte[] pozaProfil, int nrAnunturi)
        {
            this.id = id;

            this.nume = nume;
            this.prenume = prenume;
            this.email = email;
            this.adresa = adresa;
            this.telefon = telefon;
            this.isBanned = isBanned;
            this.pozaProfil = pozaProfil;
            this.nrAnunturi = nrAnunturi;
        }
    }
}