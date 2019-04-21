using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Recrutement.Infrastructure;
using Recrutement.Models;
using Recrutement.Models.Actors;
using Recrutement.UseCases;

namespace RecrutementTest
{
    public class TestPlannificationEntretien
    {
        private RecruteurRepository _recruteurRepository;
        private SalleRepository _salleRepository;

        [SetUp]
        public void Setup()
        {
           _recruteurRepository = new RecruteurRepository();
           
            _recruteurRepository.Ajouter(new Recruteur(new Personne("Antoine", "Sauvignet"),
            new Profil(new List<string>(){ ".Net"}, 10)));

            _recruteurRepository.Ajouter(new Recruteur(new Personne("Daouda", "BANGOURA"),
            new Profil(new List<string>(){ "Android"}, 2)));

            _recruteurRepository.Ajouter(new Recruteur(new Personne("Julien", "Lamby"),
            new Profil(new List<string>(){ "AGILE" }, 5)));

            _recruteurRepository.Ajouter(new Recruteur(new Personne("Benoît", "GOEPFERT"),
            new Profil(new List<string>(){ "JAVA", "PHP", "FRONT" }, 4)));

            _recruteurRepository.Ajouter(new Recruteur(new Personne("Adel Mahfoud", "CHEBBINE"),
            new Profil(new List<string>(){ "JAVA", "Angular"}, 5)));
            
            _recruteurRepository.Ajouter(new Recruteur(new Personne("jean", "BANGOURA"),
                new Profil(new List<string>(){"Android", "Ruby", "F#"}, 2)));

            _salleRepository = new SalleRepository();
            _salleRepository.Ajouter(new Salle("A07", 0));
            _salleRepository.Ajouter(new Salle("B11", 1));
            _salleRepository.Ajouter(new Salle("B22", 2));
            _salleRepository.Ajouter(new Salle("A06", 0));
            _salleRepository.Ajouter(new Salle("A11", 1));

        }

        
        [Test]
        public void JeanBangouraWillBeChosenToInterviewRobin()
        {
            var candidatPersonne = new Personne("Robin", "Soldé");
            string[] candidatCompetence = {"Android", "Ruby"};
            var candidatProfil = new Profil(new List<string>(candidatCompetence), 1);
            var candidat = new Candidat(candidatPersonne, candidatProfil);
            var dateTime = new DateTime(2019,4,21,10,30,0);
            const int duree = 10;


            var planifierEntretien = new PlanifierEntretien(this._salleRepository,
                this._recruteurRepository, candidat, new Creneau(dateTime, duree));
            
            Assert.AreEqual("BANGOURA", planifierEntretien.Recruteur.Personne.Nom);
            Assert.AreEqual("jean", planifierEntretien.Recruteur.Personne.Prenom);
        }
        

        [Test]
        public void JeanBangouraIsSuitedButNotAvailableToInterviewRobin()
        {
            var candidatPersonne = new Personne("Robin", "Soldé");
            string[] candidatCompetence = {"Android", "Ruby"};
            var candidatProfil = new Profil(new List<string>(candidatCompetence), 1);
            var candidat = new Candidat(candidatPersonne, candidatProfil);
            var dateTime = new DateTime(2019,4,21,10,30,0);
            const int duree = 10;
            
            var indispoRecrut = new DateTime(2019,4,21,10,15,0);
            var crenindispo = new Creneau(indispoRecrut, 60);

            var jeanBangoura = this._recruteurRepository.Collection.First(x => x.Personne.Prenom == "jean"
                                                                              && x.Personne.Nom == "BANGOURA");
            jeanBangoura.AjouterIndisponibilite(crenindispo);

            Assert.Throws<NullReferenceException>(() =>
            {
                var planifierEntretien = new PlanifierEntretien(this._salleRepository,
                    this._recruteurRepository, candidat, new Creneau(dateTime, duree));
            });
        }
        
    }
}