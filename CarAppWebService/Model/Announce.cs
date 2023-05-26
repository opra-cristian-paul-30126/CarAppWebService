using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarAppWebService.Model
{
    public class Announce
    {
        public int codAnunt;
        public int id;
        public string marca;
        public string model;
        public string varianta;
        public int pret;
        public int an;
        public int km;
        public int putere;
        public int putereKw;
        public string combustibil;
        public string cutieViteze;
        public int cc;
        public string culoare;
        public string dataAnunt;
        public string locatie;
        public string descriere;
        public byte[] imagAnunt;
        public byte[] imag1;
        public byte[] imag2;
        public byte[] imag3;
        public Announce()
        {

        }
        public Announce(int codAnunt,int id, string marca, string model, int pret, int an, int km, int putere, int putereKw, string combustibil, string cutieViteze,
            int cc, string culoare, string dataAnunt, string locatie, string descriere, byte[] imagAnunt, byte[] imag1, byte[] imag2, byte[] imag3)
        {
            this.codAnunt = codAnunt;
            this.cc = cc;
            this.model = model;
            this.pret = pret;
            this.locatie = locatie;
            this.descriere = descriere; 
            this.putere = putere;
            this.cutieViteze = cutieViteze;
            this.an = an;
            this.culoare = culoare;
            this.combustibil = combustibil;
            this.dataAnunt = dataAnunt;
            this.imag1 = imag1;
            this.imag2  = imag2;
            this.imag3 = imag3;
            this.imagAnunt  = imagAnunt;
            this.id = id;
            this.putereKw = putereKw;
            this.km = km;
            this.marca = marca;
        }

    }
}