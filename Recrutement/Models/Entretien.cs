using System;
using System.ComponentModel.DataAnnotations;

namespace ddd
{
    public class Entretien
    {
        public Creneau creneau { get; set; }
        public Recruteur recruteur { get; set; }
        public Candidat candidat { get; set; }
        public Salle Salle { get; set; }
        
        public Entretien(Creneau creneau, Recruteur recruteur, Candidat candidat, Salle Salle)
        {
            this.creneau = creneau;
            this.recruteur = recruteur;
            this.candidat = candidat;
            this.Salle = Salle;
        }
    }
}