using System;
using System.ComponentModel.DataAnnotations;

namespace ddd
{
    public class Entretien
    {
        public Status status { get; set; }
        public Creneau creneau { get; set; }
        public Recruteur recruteur { get; set; }
        public Candidat candidat { get; set; }
        
        public Entretien(Creneau creneau, Recruteur recruteur, Candidat candidat)
        {
            this.creneau = creneau;
            this.recruteur = recruteur;
            this.candidat = candidat;
        }

        public string Planifier()
        {
            //TODO
            return "Return un genre de ToString()";
        }
        
        public bool Confimer()
        {
            //TODO
            return true;
        }
        
        public string Annuler(string raison)
        {
            //TODO
            return raison;
        }
    }
}