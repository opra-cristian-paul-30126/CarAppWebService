namespace CarAppWebService.Model
{
    public class Announce
    {
        public string marca, model, varianta, caroserie, combustibil, cutieViteze, culoare, dataAnunt, locatie, descriere;
        public int    idUser, idAnunt, pret, an, km, putere, putereKw, cc;
        public byte[] imagAnunt, imag1, imag2, imag3;

        public Announce() { }
        public Announce(int idAnunt,int idUser, string marca, string model, string caroserie, string varianta, int pret, int an, int km, int putere, int putereKw, string combustibil, string cutieViteze,
            int cc, string culoare, string dataAnunt, string locatie, string descriere, byte[] imagAnunt, byte[] imag1, byte[] imag2, byte[] imag3)
        {
            this.idAnunt     = idAnunt;
            this.idUser      = idUser;
            this.cc          = cc;
            this.model       = model;
            this.pret        = pret;
            this.locatie     = locatie;
            this.descriere   = descriere; 
            this.putere      = putere;
            this.cutieViteze = cutieViteze;
            this.an          = an;
            this.culoare     = culoare;
            this.combustibil = combustibil;
            this.dataAnunt   = dataAnunt;
            this.imag1       = imag1;
            this.imag2       = imag2;
            this.imag3       = imag3;
            this.imagAnunt   = imagAnunt;
            this.putereKw    = putereKw;
            this.km          = km;
            this.marca       = marca;
            this.varianta    = varianta;
            this.caroserie   = caroserie;
        }

    }
}