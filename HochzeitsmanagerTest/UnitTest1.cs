using System;
using Hochzeitsmanager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HochzeitsmanagerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestHochzeit()
        {
            //Teste ob bestimmte Hochzeiten funktionieren oder nicht
            Person martin = new Person("Martin", "Schulz", new DateTime(1990, 1, 1), true);
            Person olaf = new Person("Olaf", "Schulz", new DateTime(1990, 1, 1), true);
            Person marco = new Person("Marco", "Schulz", new DateTime(1990, 1, 1), true);
            Person anja = new Person("Anja", "Meier", new DateTime(1980, 2, 2), false);


            Assert.ThrowsException<Exception>(() =>
            {
                Person ungültigePerson = new Person("Anja", "", new DateTime(1980, 2, 2), false);
            });

            Person.HomoEheErlaubt = false;

            if(martin.Heirate(anja) == false)
            {
                Assert.Fail();
            }

            if(anja.Ehepartner != martin || martin.Ehepartner != anja)
            {
                Assert.Fail();
            }
        }
    }
}