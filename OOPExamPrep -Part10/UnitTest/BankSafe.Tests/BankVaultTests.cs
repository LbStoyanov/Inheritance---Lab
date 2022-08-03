using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Item_Creation_Working()
        {
            Item item = new Item("Pepi nojleto", "33");

            Assert.AreEqual("Pepi nojleto",item.Owner);
            Assert.AreEqual("33",item.ItemId);
        }

        [Test]
        public void Bankvault_Creation_Working()
        {
          BankVault bankVault = new BankVault();
          Assert.AreEqual(12,bankVault.VaultCells.Count);
        }

        [Test]
        public void Bankvault_AddItem_Method_With_Non_Existing_Cell_Throws()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Pepi nojleto", "33");

            string cell = "z";

            Assert.Throws<ArgumentException>(() =>
            {
                bankVault.AddItem(cell, item);
            }, "Cell is already taken!");
        }

    }
}