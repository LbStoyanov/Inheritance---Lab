using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void Test_SmartPhone_Creation()
        {
            Smartphone smradphone = new Smartphone("Nokia Tugla 4", 60000);

            Assert.AreEqual("Nokia Tugla 4", smradphone.ModelName);
            Assert.AreEqual(60000, smradphone.MaximumBatteryCharge);
            Assert.AreEqual(60000, smradphone.CurrentBateryCharge);
        }

        [Test]
        public void Test_Shop_Creation()
        {

            Shop shop = new Shop(5);

            Assert.AreEqual(5, shop.Capacity);
        }
        [Test]
        public void Test_Shop_Creation_With_Negative_Capacity()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(-5);
            });
        }
        [Test]
        public void Test_Shop_Count_Working()
        {

            Shop shop = new Shop(5);

            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void Test_Shop_Add_Method_Working()
        {
            Smartphone smradphone1 = new Smartphone("Nokia Tugla 4", 20000);
            Smartphone smradphone2 = new Smartphone("Nokia Tugla 6", 40000);
            Smartphone smradphone3 = new Smartphone("Nokia Tugla 8", 60000);

            Shop shop = new Shop(5);
            shop.Add(smradphone1);
            shop.Add(smradphone2);
            shop.Add(smradphone3);

            Assert.AreEqual(3, shop.Count);
            
        }
        [Test]
        public void Test_Shop_Add_Same_Phone_Twice_Throws()
        {
            Smartphone smradphone1 = new Smartphone("Nokia Tugla 4", 20000);
            Smartphone smradphone2 = new Smartphone("Nokia Tugla 6", 40000);
            Smartphone smradphone3 = new Smartphone("Nokia Tugla 8", 60000);

            Shop shop = new Shop(5);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smradphone1);
                shop.Add(smradphone1);
            });
            
        }
        [Test]
        public void Test_Shop_With_Full_Capacity_Throws()
        {
            Smartphone smradphone1 = new Smartphone("Nokia Tugla 4", 20000);
            Smartphone smradphone2 = new Smartphone("Nokia Tugla 6", 40000);
            Smartphone smradphone3 = new Smartphone("Nokia Tugla 8", 60000);

            Shop shop = new Shop(1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smradphone1);
                shop.Add(smradphone2);
            });

        }

        [Test]
        public void Test_Shop_Remove_Method_Working()
        {
            Smartphone smradphone1 = new Smartphone("Nokia Tugla 4", 20000);
            Smartphone smradphone2 = new Smartphone("Nokia Tugla 6", 40000);
            Smartphone smradphone3 = new Smartphone("Nokia Tugla 8", 60000);

            Shop shop = new Shop(5);
            shop.Add(smradphone1);
            shop.Add(smradphone2);
            shop.Add(smradphone3);

            shop.Remove("Nokia Tugla 8");

            Assert.AreEqual(2, shop.Count);

        }

        [Test]
        public void Test_Shop_Remove_With_NullPhoneValue_Throw()
        {
            Smartphone smradphone1 = new Smartphone("Nokia Tugla 4", 20000);
            Smartphone smradphone2 = new Smartphone("Nokia Tugla 6", 40000);
            Smartphone smradphone3 = new Smartphone("Nokia Tugla 8", 60000);

            Shop shop = new Shop(5);
            shop.Add(smradphone1);
            shop.Add(smradphone2);
            shop.Add(smradphone3);

            

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("Nokia Tugla 9");
            });

        }

        [Test]
        public void TestPhone_Method_Working()
        {
            Smartphone smradphone1 = new Smartphone("Nokia Tugla 4", 20000);
            Smartphone smradphone2 = new Smartphone("Nokia Tugla 6", 40000);
            Smartphone smradphone3 = new Smartphone("Nokia Tugla 8", 60000);

            Shop shop = new Shop(5);
            shop.Add(smradphone1);
            shop.Add(smradphone2);
            shop.Add(smradphone3);



            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("Nokia Tugla 9");
            });

        }
    }
}