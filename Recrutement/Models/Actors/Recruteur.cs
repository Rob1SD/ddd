using System;
using System.Collections.Generic;
using System.Linq;

namespace ddd
{
    public partial class Recruteur
    {
        public Personne Personne { get; }
        public Profil Profil { get; }
        public string Commentaire { get; }
        
        private readonly List<Creneau> CreneauxIndisponibles;

        public Recruteur(Personne personne, Profil profil, string commentaire = "")
        {
            Personne = personne;
            Profil = profil;
            Commentaire = commentaire;
        }

        public void AjouterIndisponibilite(Creneau Indispo) {
            this.CreneauxIndisponibles.Add(Indispo);
        }


        public bool PeutTester(Candidat candidat)
        {
            if (this.Profil.Experience < candidat.Profil.Experience)
                return false;

            return candidat.Profil.Competences.All(x=>this.Profil.Competences.Contains(x));
        }

        public bool EstDisponible(Creneau creneauSouhaite)
        {
            if (this.CreneauxIndisponibles.IndexOf(creneauSouhaite) < 0)
                return true;
            return false;

        }
    }
}