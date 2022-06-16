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

        [Test]
        public void AddFootNote_Method_With_NonExistin_Footnote()
        {

            Book book = new Book("Pri Lancho", "Lanche");
            book.AddFootnote(1,"Q sum LanchO");

            Assert.AreEqual(1, book.FootnoteCount);

           
        }

        [Test]
        public void AddFootNote_Method_With_Existing_Footnote()
        {

            Book book = new Book("Pri Lancho", "Lanche");
            book.AddFootnote(1, "Q sum LanchO");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(1, "Q");
            });
        }

        [Test]
        public void FindFootNote_Method_With_NoneExisting_Footnote()
        {

            Book book = new Book("Pri Lancho", "Lanche");
            book.AddFootnote(1, "Q sum LanchO");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(2); 
            });
        }

        [Test]
        public void FindFootNote_Method_With_Existing_Footnote()
        {

            Book book = new Book("Pri Lancho", "Lanche");
            book.AddFootnote(1, "Q sum LanchO");
            string enteredResult = book.FindFootnote(1);
            string text = "Q sum LanchO";
            string returningResult = $"Footnote #{1}: {text}";

            Assert.AreEqual(enteredResult, returningResult);
        }

        [Test]
        public void AlterFootNote_Method_With_NonExisting_Footnote()
        {

            Book book = new Book("Pri Lancho", "Lanche");
            book.AddFootnote(1, "Q sum LanchO");
            

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(2, "kak");
            });
        }

        [Test]
        public void AlterFootNote_Method_With_Existing_Footnote()
        {

            Book book = new Book("Pri Lancho", "Lanche");
            book.AddFootnote(1, "Q sum LanchO");
            

        }
    }
}