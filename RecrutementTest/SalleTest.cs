using System;
using System.Collections.Generic;
using NUnit.Framework;
using Recrutement.Models;
using Recrutement.Models.Actors;

namespace RecrutementTest
{
    public class TestClassesMetier
    {
      

        [SetUp]
        public void Setup()
        {
           
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