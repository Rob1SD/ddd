using Recrutement.Models.Actors;

namespace Recrutement.Models
{
    public class Entretien
    {
        public Creneau Creneau { get; set; }
        public Recruteur Recruteur { get; set; }
        public Candidat Candidat { get; set; }
        public Salle Salle { get; set; }
        
        public Entretien(Creneau creneau, Recruteur recruteur, Candidat candidat, Salle salle)
        {
            this.Creneau = creneau;
            this.Recruteur = recruteur;
            this.Candidat = candidat;
            this.Salle = salle;
        }
    }
}