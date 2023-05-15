using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarAppWebService.Model
{
    public class Admin
    {
        public int id;
        public string nume;
        public string prenume;
        public string email;
        public byte[] pozaProfil;
        public string contact;

        public Admin()
        {
        }

        public Admin(int id, string nume, string prenume, string email, byte[] pozaProfil, string contact)
        {
            this.id = id;
            this.nume = nume;
            this.prenume = prenume;
            this.email = email;
            this.pozaProfil = pozaProfil;
            this.contact = contact;
        }

    }
}