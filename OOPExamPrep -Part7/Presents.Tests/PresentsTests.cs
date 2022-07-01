namespace Presents.Tests
{
    using NUnit.Framework;
    using Presents.Test;
    using System;

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
        public void Bag_Remove_Method_Working()
        {
            Present present = new Present("Hurka", 2.5);
            Bag bag = new Bag();
            bag.Create(present);
            bool expectedOutput = bag.Remove(present);
            bool isRemoved = true;
            

            Assert.AreEqual(isRemoved,expectedOutput);
        }
    }
}
