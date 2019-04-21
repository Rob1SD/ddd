using System;
using System.Collections.Generic;
using NUnit.Framework;
using Recrutement.Models;
using Recrutement.Models.Actors;

namespace RecrutementTest
{
    public class TestClassesMetier
    {
        private Creneau _creneau1;
        private Creneau _creneau2;

        [SetUp]
        public void Setup()
        {
           
        }


        [Test]
        public void AssertTwoCreneauEqualsAreEquals()
        {
            DateTime dateTime = DateTime.Now;
            var duration = 10;
            _creneau1 = new Creneau(dateTime, duration);
            _creneau2 = new Creneau(dateTime, duration);
            Assert.True(_creneau1.Equals(_creneau2));
        }
        
        [Test]
        public void AssertTwoCreneauNotEqualsAreNotEquals()
        {
            var duration = 10;
            _creneau1 = new Creneau(DateTime.Now, duration);
            _creneau2 = new Creneau(DateTime.Now, duration);
            Assert.False(_creneau1.Equals(_creneau2));
        }
        
        [Test]
        public void AssertThatRecruteurCannotTestCandidatIfDifferentTech()
        {
            Personne recruteurPersonne = new Personne("Antoine", "Sauvignet");
            string[] recruteurCompetence = {".Net", "js"};
            Profil recruteurProfil = new Profil(new List<string>(recruteurCompetence) , 5);
            Recruteur recruteur = new Recruteur(recruteurPersonne, recruteurProfil);

            Personne candidatPersonne = new Personne("Robin", "Soldé");
            string[] candidatCompetence = {"C", "Ruby"};
            Profil candidatProfil = new Profil(new List<string>(candidatCompetence), 5);
            Candidat candidat = new Candidat(candidatPersonne, candidatProfil);

            Assert.False(recruteur.PeutTester(candidat));
        }

        [Test]
         public void AssertThatRecruteurCannotTestCandidatIfNotMoreExperienceThatCandidat()
        {
            Personne recruteurPersonne = new Personne("Antoine", "Sauvignet");
            string[] recruteurCompetence = {".Net", "js"};
            Profil recruteurProfil = new Profil(new List<string>(recruteurCompetence) , 4);
            Recruteur recruteur = new Recruteur(recruteurPersonne, recruteurProfil);

            Personne candidatPersonne = new Personne("Robin", "Soldé");
            string[] candidatCompetence = {".Net", "js"};
            Profil candidatProfil = new Profil(new List<string>(candidatCompetence), 5);
            Candidat candidat = new Candidat(candidatPersonne, candidatProfil);

            Assert.False(recruteur.PeutTester(candidat));
        }

         [Test]
         public void AssertThatRecruteurCanTestIfSameTechAndMoreExperience()
        {
            Personne recruteurPersonne = new Personne("Antoine", "Sauvignet");
            string[] recruteurCompetence = {".Net", "js", "C"};
            Profil recruteurProfil = new Profil(new List<string>(recruteurCompetence) , 5);
            Recruteur recruteur = new Recruteur(recruteurPersonne, recruteurProfil);

            Personne candidatPersonne = new Personne("Robin", "Soldé");
            string[] candidatCompetence = {"C", ".Net"};
            Profil candidatProfil = new Profil(new List<string>(candidatCompetence), 5);
            Candidat candidat = new Candidat(candidatPersonne, candidatProfil);

            Assert.True(recruteur.PeutTester(candidat));
        }
         
         [Test]
         public void AssertThatRecruteurIsAvailableWhenNoCreneau()
        {
            Personne recruteurPersonne = new Personne("Antoine", "Sauvignet");
            string[] recruteurCompetence = {".Net", "js", "C"};
            Profil recruteurProfil = new Profil(new List<string>(recruteurCompetence) , 5);
            Recruteur recruteur = new Recruteur(recruteurPersonne, recruteurProfil);

            DateTime date = DateTime.Now;
            Creneau creneau = new Creneau(date, 10);

            Assert.True(recruteur.EstDisponible(creneau));
        }
         
         [Test]
         public void AssertThatRecruteurHasCrenauxAfterAddedOne()
        {
            Personne recruteurPersonne = new Personne("Antoine", "Sauvignet");
            string[] recruteurCompetence = {".Net", "js", "C"};
            Profil recruteurProfil = new Profil(new List<string>(recruteurCompetence) , 5);
            Recruteur recruteur = new Recruteur(recruteurPersonne, recruteurProfil);

            DateTime date = DateTime.Now;
            Creneau creneau = new Creneau(date, 10);
            bool ajoutCreneau = recruteur.AjouterIndisponibilite(creneau);

            Assert.True(ajoutCreneau);
        }

         [Test]
        public void AssertThatRecruteurCantHaveTwiceSameCreneau()
        {
            Personne recruteurPersonne = new Personne("Antoine", "Sauvignet");
            string[] recruteurCompetence = {".Net", "js", "C"};
            Profil recruteurProfil = new Profil(new List<string>(recruteurCompetence) , 5);
            Recruteur recruteur = new Recruteur(recruteurPersonne, recruteurProfil);

            DateTime date = DateTime.Now;
            Creneau creneau = new Creneau(date, 10);
            
            recruteur.AjouterIndisponibilite(creneau);
            bool ajoutCreneau = recruteur.AjouterIndisponibilite(creneau);

            Assert.False(ajoutCreneau);
        }

        [Test]
        public void AssertThatRecruteurIsNotAvailableIfTwiceSameCreneau()
        {
            Personne recruteurPersonne = new Personne("Antoine", "Sauvignet");
            string[] recruteurCompetence = {".Net", "js", "C"};
            Profil recruteurProfil = new Profil(new List<string>(recruteurCompetence) , 5);
            Recruteur recruteur = new Recruteur(recruteurPersonne, recruteurProfil);

            DateTime date = DateTime.Now;
            Creneau creneau = new Creneau(date, 10);
            
            recruteur.AjouterIndisponibilite(creneau);

            Assert.False(recruteur.EstDisponible(creneau));
        }

         [Test]
         public void AssertThatSalleIsAvailableWhenNoCreneau()
        {
            Salle salle = new Salle("A07", 0);
            DateTime date = DateTime.Now;
            Creneau creneau = new Creneau(date, 10);

            Assert.True(salle.EstDisponible(creneau));
        }

         [Test]
         public void AssertThatSalleHasCrenauxAfterAddedOne()
        {
            Salle salle = new Salle("A07", 0);
            DateTime date = DateTime.Now;
            Creneau creneau = new Creneau(date, 10);

            Assert.True(salle.EstDisponible(creneau));
            bool ajoutCreneau = salle.AjouterIndisponibilite(creneau);

            Assert.True(ajoutCreneau);
        }

         [Test]
        public void AssertThatSalleCantHaveTwiceSameCreneau()
        {
            Salle salle = new Salle("A07", 0);
            DateTime date = DateTime.Now;
            Creneau creneau = new Creneau(date, 10);
            
            salle.AjouterIndisponibilite(creneau);
            bool ajoutCreneau = salle.AjouterIndisponibilite(creneau);

            Assert.False(ajoutCreneau);
        }

        [Test]
        public void AssertThatSalleIsNotAvailableIfTwiceSameCreneau()
        {
            Salle salle = new Salle("A07", 0);

            DateTime date = DateTime.Now;
            Creneau creneau = new Creneau(date, 10);

            salle.AjouterIndisponibilite(creneau);
            bool ajoutCreneau = salle.AjouterIndisponibilite(creneau);
            
            salle.AjouterIndisponibilite(creneau);            

            Assert.False(salle.EstDisponible(creneau));
        }


    }
}