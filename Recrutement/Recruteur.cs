using System.Collections.Generic;

namespace ddd
{
    public class Recruteur
    {
        public string Nom { get; }
        public string Prenom { get; }
        public string Commentaire { get; }
        public uint Experience { get; }
        public List<string> Competences { get; }
        

        public Recruteur(string nom, string prenom, uint experience, List<string> competences, string commentaire = "")
        {
            Nom = nom;
            Prenom = prenom;
            Commentaire = commentaire;
            Experience = experience;
            Competences = competences;
        }
    }
}