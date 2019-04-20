using ddd;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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
            DateTime DateTime = DateTime.Now;
            int Duree = 10;


            PlanifierEntretien PlanifierEntretien = new PlanifierEntretien(this.SalleRepository,
                this.RecruteurRepository, Candidat, DateTime, Duree);
            
            Assert.AreEqual("BANGOURA", PlanifierEntretien.Recruteur.Personne.Nom);
            Assert.AreEqual("jean", PlanifierEntretien.Recruteur.Personne.Prenom);
        }


        
    }
}