using ddd;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using ddd.UseCases;


namespace Tests
{
    public class TestPlannificationEntretien
    {
        public RecruteurRepository RecruteurRepository;
        public SalleRepository SalleRepository;

        [SetUp]
        public void Setup()
        {
           RecruteurRepository = new RecruteurRepository();
           
            RecruteurRepository.Ajouter(new Recruteur(new Personne("Antoine", "Sauvignet"),
            new Profil(new List<string>(){ ".Net"}, 10)));

            RecruteurRepository.Ajouter(new Recruteur(new Personne("Daouda", "BANGOURA"),
            new Profil(new List<string>(){ "Android"}, 2)));

            RecruteurRepository.Ajouter(new Recruteur(new Personne("Julien", "Lamby"),
            new Profil(new List<string>(){ "AGILE" }, 5)));

            RecruteurRepository.Ajouter(new Recruteur(new Personne("Benoît", "GOEPFERT"),
            new Profil(new List<string>(){ "JAVA", "PHP", "FRONT" }, 4)));

            RecruteurRepository.Ajouter(new Recruteur(new Personne("Adel Mahfoud", "CHEBBINE"),
            new Profil(new List<string>(){ "JAVA", "Angular"}, 5)));
            
            RecruteurRepository.Ajouter(new Recruteur(new Personne("jean", "BANGOURA"),
                new Profil(new List<string>(){"Android", "Ruby", "F#"}, 2)));

            SalleRepository = new SalleRepository();
            SalleRepository.Ajouter(new Salle("A07", 0));
            SalleRepository.Ajouter(new Salle("B11", 1));
            SalleRepository.Ajouter(new Salle("B22", 2));
            SalleRepository.Ajouter(new Salle("A06", 0));
            SalleRepository.Ajouter(new Salle("A11", 1));

        }

        
        [Test]
        public void JeanBANGOURAWillBeChosenToInterviewRobin()
        {
            Personne candidatPersonne = new Personne("Robin", "Soldé");
            string[] candidatCompetence = {"Android", "Ruby"};
            Profil candidatProfil = new Profil(new List<string>(candidatCompetence), 1);
            Candidat Candidat = new Candidat(candidatPersonne, candidatProfil);
            DateTime DateTime = new DateTime(2019,4,21,10,30,0);
            int Duree = 10;


            PlanifierEntretien PlanifierEntretien = new PlanifierEntretien(this.SalleRepository,
                this.RecruteurRepository, Candidat, new Creneau(DateTime, Duree));
            
            Assert.AreEqual("BANGOURA", PlanifierEntretien.Recruteur.Personne.Nom);
            Assert.AreEqual("jean", PlanifierEntretien.Recruteur.Personne.Prenom);
        }

        [Test]
        public void JeanBangouraIsSuitedButNotAvailableToInterviewRobin()
        {
            var candidatPersonne = new Personne("Robin", "Soldé");
            string[] candidatCompetence = {"Android", "Ruby"};
            var candidatProfil = new Profil(new List<string>(candidatCompetence), 1);
            var Candidat = new Candidat(candidatPersonne, candidatProfil);
            var DateTime = new DateTime(2019,4,21,10,30,0);
            const int duree = 10;
            
            var indispoRecrut = new DateTime(2019,4,21,10,15,0);
            var Crenindispo = new Creneau(indispoRecrut, 60);

            var jeanBangoura = this.RecruteurRepository.Collection.First(x => x.Personne.Prenom == "jean"
                                                                              && x.Personne.Nom == "BANGOURA");
            jeanBangoura.AjouterIndisponibilite(Crenindispo);

            Assert.Throws<NullReferenceException>(() =>
            {
                var PlanifierEntretien = new PlanifierEntretien(this.SalleRepository,
                    this.RecruteurRepository, Candidat, new Creneau(DateTime, duree));
            });
        }
        
    }
}