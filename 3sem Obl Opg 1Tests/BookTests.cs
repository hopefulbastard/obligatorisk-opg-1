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
    public class BookTests
    {

        private Book ValidBook = new Book { Id = 1, Title = "House of Leaves", Price = 750 };
        private Book TitleNullBook = new Book { Id = 2, Title = null, Price = 200 };
        private Book TitleShortBook = new Book { Id = 3, Title = "NA", Price = 200 };
        private Book NegativePriceBook = new Book { Id = 4, Title = "The Hobbit", Price = -1 };
        private Book Price1300Book = new Book { Id = 5, Title = "Battle of the Two Towers", Price = 1300 };

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual(ValidBook.ToString(), "1 House of Leaves 750");
        }

        [TestMethod()]
        public void TitleValidatorTest()
        {
            ValidBook.TitleValidator();

            Assert.ThrowsException<ArgumentNullException>(() => TitleNullBook.TitleValidator());
            Assert.ThrowsException<ArgumentException>(() => TitleShortBook.TitleValidator());
        }

        [TestMethod()]
        public void PriceValidatorTest()
        {
            ValidBook.PriceValidator();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => NegativePriceBook.PriceValidator());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Price1300Book.PriceValidator());
        }
    }
}