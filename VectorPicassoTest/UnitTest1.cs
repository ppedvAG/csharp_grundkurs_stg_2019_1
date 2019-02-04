using System;
using System.Windows;
using System.Windows.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorPicasso.Klassen;

namespace VectorPicassoTest
{
    //Attribute
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TesteQuadrat()
        {
            Rechteck rechteck = new Rechteck(new Point(0, 2), Brushes.Black);

            rechteck.Abstand = new Point(10, 20);

            //Fail wenn Höhe und Breite nicht so sind wie zuvor gesetzt
            if(rechteck.Abstand.X != 10 || rechteck.Abstand.Y != 20 )
            {
                Assert.Fail();
            }

            Quadrat q = new Quadrat(new Point(0, 2), Brushes.Black);
            q.Abstand = new Point(10, 20);


           

            //Fail wenn Breite und Höhe nicht gleich sind
            if(q.Abstand.X != q.Abstand.Y)
            {
                Assert.Fail();
            }


            q.Winkel = 500;

            Assert.AreEqual(0, q.Winkel);

        }

    }
}