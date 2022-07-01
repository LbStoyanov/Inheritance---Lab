namespace Presents
{
    using NUnit.Framework;
    using Test;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void Present_Creation_Woking()
        {
            Present present = new Present("Hurka", 2.5);
            Assert.AreEqual("Hurka", present.Name);
            Assert.AreEqual(2.5, present.Magic);
        }

        [Test]
        public void Bag_Creation_Woking()
        {
            Bag bag = new Bag();

            Assert.AreEqual(0, bag.GetPresents().Count);
        }

        [Test]
        public void Bag_Create_Method_With_Null_Present_Throw()
        {
            Present present = null;
            Bag bag = new Bag();

            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(present);
            });
        }

        [Test]
        public void Bag_Create_Method_With_Exisiting_Present_Throw()
        {
            Present present = new Present("Hurka", 2.5); 
            Bag bag = new Bag();
            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            });
        }

        [Test]
        public void Bag_Create_Method_With_Inexisiting_Present_Throw()
        {
            Present present = new Present("Hurka", 2.5);
            Bag bag = new Bag();
            var expectationResult = bag.Create(present);

            string result = $"Successfully added present {present.Name}.";

            Assert.AreEqual(expectationResult,result );
        }

        [Test]
        public void Bag_Remove_Method_With_Present_Working()
        {
            Present present = new Present("Hurka", 2.5);
            Bag bag = new Bag();
            bag.Create(present);
            bool expectedOutput = bag.Remove(present);
            bool isRemoved = true;
            

            Assert.AreEqual(isRemoved,expectedOutput);
        }

        [Test]
        public void Bag_Remove_Method__No_Present_Working()
        {
            Present present = new Present("Hurka", 2.5);
            Present present2 = new Present("Hurka2", 2.5);
            Bag bag = new Bag();
            bag.Create(present);
            bool expectedOutput = bag.Remove(present2);
            bool isRemoved = false;


            Assert.AreEqual(isRemoved, expectedOutput);
        }

        [Test]
        public void GetPresentWithLeastMagic_Method_Working()
        {
            Present present = new Present("Hurka", 2.4);
            Present present2 = new Present("Hurka2", 2.5);
            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present2);

            var expectedOutput = bag.GetPresentWithLeastMagic();


            Assert.AreEqual(present, expectedOutput);
        }

        [Test]
        public void GetPresents_Method_Working()
        {
            Present present = new Present("Hurka", 2.4);
            Present present2 = new Present("Hurka2", 2.5);
            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present2);

            var expectedOutput = bag.GetPresents();
            var list = new List<Present>();
            list.Add(present);
            list.Add(present2);


            Assert.AreEqual(list, expectedOutput);
        }

        [Test]
        public void GetPresent_Method_Working()
        {
            Present present = new Present("Hurka", 2.4);
            Present present2 = new Present("Hurka2", 2.5);
            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present2);

            var expectedOutput = bag.GetPresent(present.Name);
          


            Assert.AreEqual(present, expectedOutput);
        }
    }
}
