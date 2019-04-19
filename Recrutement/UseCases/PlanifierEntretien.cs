using System;
using System.Linq;

namespace ddd.UseCases
{
    public class PlanifierEntretien
    {

        public SalleRepository SalleRepository { get; set; }
        public RecruteurRepository RecruteurRepository { get; set; }
        public Candidat Candidat { get; set; }
        
        public Salle Salle { get; set; }
        public Recruteur Recruteur { get; set; }

        public Creneau Creneau { get; set; }
        

        public PlanifierEntretien(SalleRepository salleRepo, RecruteurRepository recruteurRepo, Candidat Candidat, DateTime DateTime, int Duree)
        {
            this.SalleRepository = salleRepo;
            this.RecruteurRepository = recruteurRepo;
            this.Candidat = Candidat;
            this.Creneau = new Creneau(DateTime, Duree);

            this.Recruteur = this.GetRecruteurValide();
            
            this.Salle = GetSalleDisponible();

        }
        private Salle GetSalleDisponible()
        {
            return this.SalleRepository.Collection.First(salle => salle.EstDisponible(this.Creneau));
        }

        private Recruteur GetRecruteurValide()
        {
            return this.RecruteurRepository.Collection.FirstOrDefault(recruteur => recruteur.PeutTester(this.Candidat)
                && recruteur.EstDisponible(this.Creneau));
        }
    }
 
}