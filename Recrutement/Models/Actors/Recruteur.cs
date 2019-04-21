using System.Collections.Generic;
using System.Linq;

namespace Recrutement.Models.Actors
{
    public partial class Recruteur
    {
        public Personne Personne { get; }
        public Profil Profil { get; }
        public string Commentaire { get; }
        
        private readonly List<Creneau> _creneauxIndisponibles;

        public Recruteur(Personne personne, Profil profil, string commentaire = "")
        {
            Personne = personne;
            Profil = profil;
            Commentaire = commentaire;
            _creneauxIndisponibles = new List<Creneau>();
        }

        public bool AjouterIndisponibilite(Creneau indispo) {
            if (!EstDisponible(indispo))
                return false;
            _creneauxIndisponibles.Add(indispo);
            return _creneauxIndisponibles.IndexOf(indispo) >= 0;
        }

        public bool SupprimerIndisponibilite(Creneau indispo) => _creneauxIndisponibles.Remove(indispo);


        public bool PeutTester(Candidat candidat)
        {
            return Profil.Experience >= candidat.Profil.Experience 
                   && candidat.Profil.Competences.All(x=>Profil.Competences.Contains(x));
        }

        public bool EstDisponible(Creneau creneauSouhaite)
        {
            return !_creneauxIndisponibles.Any(x => x.Equals(creneauSouhaite) 
                                                    || x.SeChevauche(creneauSouhaite));
        }
    }
}