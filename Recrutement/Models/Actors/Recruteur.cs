using System.Collections.Generic;

namespace ddd
{
    public partial class Recruteur
    {
        public Personne Personne { get; }
        public Profil Profil { get; }
        public string Commentaire { get; }
        

        public Recruteur(Personne personne, Profil profil, string commentaire = "")
        {
            Personne = personne;
            Profil = profil;
            Commentaire = commentaire;
        }

        public bool PeutTester(Candidat candidat)
        {
            
            return false;
        }

        public bool EstDisponible(Creneau creneauSouhaite)
        {
            return false;
        }
    }
}