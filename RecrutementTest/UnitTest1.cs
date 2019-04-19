using ddd;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Runtime;


namespace Tests
{
    public class Tests
    {
        public Creneau creneau1;
        public Creneau creneau2;
        [SetUp]
        public void Setup()
        {
           // Creneau creneau1;
            //Creneau creneau2;
        }

        [Test]
        public void assertTwoCreneauEqualsAreEquals()
        {

            DateTime dateTime = DateTime.Now;
            var duration = 10;
            creneau1 = new Creneau(dateTime, duration);
            creneau2 = new Creneau(dateTime, duration);
            Assert.True(creneau1.Equals(creneau2));
        }
        [Test]
        public void assertTwoCreneauNotEqualsAreNotEquals()
        {
            var duration = 10;
            creneau1 = new Creneau(DateTime.Now, duration);
            creneau2 = new Creneau(DateTime.Now, duration);
            Assert.False(creneau1.Equals(creneau2));
        }
        [Test]
        public void assertThatRecruteurCannotTestCandidatIfDifferentTech()
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
         public void assertThatRecruteurCannotTestCandidatIfNotMoreExperienceThatCandidat()
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
         public void assertThatRecruteurCanTestIfSameTechAndMoreExperience()
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

    }
}