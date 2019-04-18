namespace ddd
{
    public class Adresse
    {
        public string Pays { get; private set; }
        public Departement Departement { get; private set; }
        public Ville Ville { get; private set; }
        public Voie Voie { get; private set; }

        public Adresse(string pays, Departement departement, Ville ville, Voie voie)
        {
            Pays = pays;
            Departement = departement;
            Ville = ville;
            Voie = voie;
        }
    }

    public class Voie
    {
        public Voie(string numero, string nom) {}
    }

    public class Ville
    {
    }

    public class Departement
    {
    }
}