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

        [TestCaseSource("TestCaseAddData")]
        public void Test_If_AddMethod_Create_Valid_Positiv_Data(
            Person[] ctorPeople, Person[] peopletoAdd, int expectedCount)
        {
            Database database = new Database(ctorPeople);

            foreach (var person in peopletoAdd)
            {
                database.Add(person);
            }

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
                     },
                     new Person[]
                     {
                         new Person(4, "Kocho"),
                         new Person(5, "Mocho"),
                         new Person(6, "Garabet"),
                     },
                     6),
                  new TestCaseData(
                     new Person[]
                     {
                     },
                     new Person[]
                     {
                         new Person(1, "Koncho"),
                         new Person(2, "Moncho"),
                         new Person(3, "Turbalan"),

                     },3)
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
