using NUnit.Framework;
using System;
using System.Linq;

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
            }, "Cell doesn't exists!");
        }


        [Test]
        public void Bankvault_AddItem_Method_With_Taken_Cell_Throws()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Pepi nojleto", "33");

            string cell = "A1";

            bankVault.AddItem(cell, item);

            //bool cellExists = bankVault.VaultCells.Values.Any(x => x?.ItemId == item.ItemId);

            Assert.Throws<ArgumentException>(() =>
            {
                bankVault.AddItem(cell, item);


            }, "Cell is already taken!");
            
        }

        [Test]
        public void Bankvault_AddItem_Method_With_Item_Already_Added_In_Cell_Throws()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Pepi nojleto", "33");

            string cell = "A1";
            string cell2 = "A2";

            bankVault.AddItem(cell, item);


            Assert.Throws<InvalidOperationException>(() =>
            {
                bankVault.AddItem(cell2, item);


            }, "Item is already in cell!");

        }

        [Test]
        public void Bankvault_AddItem_Method_With_Correct_Item_Working()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Pepi nojleto", "33");

            string cell = "A1";
           

            string expectedOutputMessage = bankVault.AddItem(cell, item);

            string message = $"Item:{item.ItemId} saved successfully!";

            Assert.AreEqual(message, expectedOutputMessage);



        }
    }
}