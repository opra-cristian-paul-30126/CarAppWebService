namespace CarAppWebService.Model
{
    public class Admin
    {
        public int id;
        public string nume, prenume, email, contact;
        public byte[] pozaProfil;

        public Admin() { }

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