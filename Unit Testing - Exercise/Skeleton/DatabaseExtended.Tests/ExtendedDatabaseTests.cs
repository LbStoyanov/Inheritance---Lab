namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [TestCaseSource("TestCaseConstructorData")]
        public void Test_If_Constructor_Create_Valid_Positiv_Data(Person[] people,int expectedCount)
        {
            Database database = new Database(people);

            Assert.AreEqual(expectedCount, database.Count);

        }

        [TestCaseSource("TestCaseConstructorData")]
        public void Test_If_Constructor_Create_Valid_Positiv_Data(Person[] people, int expectedCount)
        {
            Database database = new Database(people);

            database.Add();

            Assert.AreEqual(expectedCount, database.Count);

        }

        public static IEnumerable<TestCaseData> TestCaseAddData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                   new TestCaseData(
                     new Person[]
                     {
                     new Person(1, "Iubi"),
                     new Person(2, "Kircho"),
                     new Person(3, "Hasan"),
                     },3),
                   new TestCaseData(
                     new Person[]
                     {

                     }, 0)
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseConstructorData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                   new TestCaseData(
                     new Person[]
                     {
                     new Person(1, "Iubi"),
                     new Person(2, "Kircho"),
                     new Person(3, "Hasan"),
                     },3),
                   new TestCaseData(
                     new Person[]
                     {

                     }, 0)
            };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }
    }
}
