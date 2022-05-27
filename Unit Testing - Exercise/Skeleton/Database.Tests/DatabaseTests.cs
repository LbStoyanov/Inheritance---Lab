namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new[] {1})]
        [TestCase(new[] {5,15,1,23,45,16})]
        [TestCase(new[] {int.MinValue,int.MaxValue,5})]
        [TestCase(new int[0])]
        //[TestCase(new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17})]

        public void Test_If_The_Database_Input_Is_Valid(int[] parameters)
        {
            Database database = new Database(parameters);

            Assert.AreEqual(parameters.Length, database.Count);

        }
        [TestCase(
            new[] { 1,2 ,3},
            new[] { 10, 15,16 },
            6)]

        [TestCase(
            new int[0],
            new[] { int.MinValue, int.MaxValue, 16 },
            3)]

        [TestCase(
            new int[0],
            new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16,  },
            16)]
        public void Add_With_Valid_Data(int[] ctorParams, int[] addedElements,int expectedCount)
        {
            Database database = new Database(ctorParams);

            for (int i = 0; i < addedElements.Length; i++)
            {
                database.Add(addedElements[i]);
            }

            Assert.AreEqual(expectedCount, database.Count);
        }
        [TestCase(
            new[] {1,2},
            new[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14},
            1)]
        public void Test_Add_Method_With_Invalid_Data(int[] ctorParams, int[] addedElements, int wrongParameter)
        {
            Database database = new Database(ctorParams);

            for (int i = 0; i < addedElements.Length; i++)
            {
                database.Add(addedElements[i]);
            }

            Assert.Throws<InvalidOperationException>(
                () => database.Add(wrongParameter));
        }

    }
}
