namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void Book_Creation_With_Valid_BookName_Working()
        {
            Book book = new Book("Pri Lancho", "Lanche");

            Assert.AreEqual("Pri Lancho", book.BookName);
            Assert.AreEqual("Lanche", book.Author);
            Assert.AreEqual(0, book.FootnoteCount);
        }

        [Test]
        public void Book_Creation_With_Invalid_BookNameWorking()
        {
            

            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("", "Lanche");
            });

            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(null, "Lanche");
            });
        }

        [Test]
        public void Book_Autor_With_Empty_Name_Working()
        {
            

            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("Pri Lancho", "");
            });
        }

        [Test]
        public void Book_Autor_With_Null_Name_Working()
        {


            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("Pri Lancho", null);
            });
        }
    }
}