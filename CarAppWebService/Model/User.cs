namespace CarAppWebService.Model
{
    public class User
    {
        public int id;
        public string nume, prenume, email, adresa, telefon;
        public bool isBanned;
        public byte[] pozaProfil;

        public User() { }

        public User(int id, string nume, string prenume,
                    string email, string adresa, string telefon, bool isBanned,
                    byte[] pozaProfil)
        {
            this.id = id;
            this.nume = nume;
            this.prenume = prenume;
            this.email = email;
            this.adresa = adresa;
            this.telefon = telefon;
            this.isBanned = isBanned;
            this.pozaProfil = pozaProfil;
        }
    }
}