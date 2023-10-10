using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3sem_Obl_Opg_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3sem_Obl_Opg_1.Tests
{
    [TestClass()]
    public class BookRepositoryTests
    {

        BookRepository bookRepository = new BookRepository();

        //Virker ikke når alle tests bliver kørt, men virker når den kører alene?
        [TestMethod()]
        public void GetByIdTest()
        {
            bookRepository.Get();
            Book getTestBook = bookRepository.GetById(1);
            Assert.AreEqual("1 House of Leaves 750", getTestBook.ToString());
        }

        [TestMethod()]
        public void AddTest()
        {
            bookRepository.Get();
            Book newBook = new Book { Id = 7, Title = "A Study in Scarlet", Price = 300 };
            bookRepository.Add(newBook);
            Book addTestBook = bookRepository.GetById(7);
            Assert.AreEqual("7 A Study in Scarlet 300", addTestBook.ToString());
        }

        [TestMethod()]
        public void DeleteTest()
        {
            bookRepository.Get();
            int repoBeforeDelete = bookRepository.books.Count;
            bookRepository.Delete(6);
            int repoAfterDelete = bookRepository.books.Count;
            Assert.AreEqual(repoAfterDelete, repoBeforeDelete--);
        }
    }
}