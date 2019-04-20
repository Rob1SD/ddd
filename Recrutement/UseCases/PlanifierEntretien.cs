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
        

        public PlanifierEntretien(SalleRepository salleRepo, RecruteurRepository recruteurRepo, Candidat Candidat, Creneau creneau)
        {
            SalleRepository = salleRepo;
            RecruteurRepository = recruteurRepo;
            this.Candidat = Candidat;
            Creneau = creneau;

            Recruteur = GetRecruteurValide();
            if(Recruteur == null) throw new NullReferenceException("Aucun Recruteur Disponible !");
            
            Salle = GetSalleDisponible();
            if(Salle == null) throw  new NullReferenceException("Aucune salle disponible !");

        }
        
        private Salle GetSalleDisponible()
        {
            return SalleRepository.Collection.First(salle => salle.EstDisponible(Creneau));
        }

        private Recruteur GetRecruteurValide()
        {
            var recruteurs = RecruteurRepository.Collection.Where(recruteur => recruteur.PeutTester(Candidat));
            var premierRecruteurDispo = recruteurs.FirstOrDefault(rec => rec.EstDisponible(Creneau));
            return premierRecruteurDispo;
        }
    }
 
}