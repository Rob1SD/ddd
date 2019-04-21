namespace Recrutement.Models.Adress
{
    public class Voie
    {
        public string Numero { get; }
        public string Nom { get; }

        public Voie(string numero, string nom)
        {
            Numero = numero;
            Nom = nom;
        }
    }
}