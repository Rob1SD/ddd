namespace Recrutement.Models.Adress
{
    public class Ville
    {
        public string Nom { get; }
        public string CodePostal { get; }

        public Ville(string nom, string codePostal)
        {
            this.Nom = nom;
            this.CodePostal = codePostal;
        }
    }
}