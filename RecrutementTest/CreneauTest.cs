using System;
using System.Collections.Generic;
using NUnit.Framework;
using Recrutement.Models;
using Recrutement.Models.Actors;

namespace RecrutementTest
{
    public class CreneauTest
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
    }
}