namespace ddd
{
    public class Ville
    {
        public string Nom { get; }
        public string CodePostal { get; }

        public Ville(string Nom, string CodePostal)
        {
            this.Nom = Nom;
            this.CodePostal = CodePostal;
        }
    }
}