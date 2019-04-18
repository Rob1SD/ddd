using ddd;
using NUnit.Framework;
using System;

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
    }
}