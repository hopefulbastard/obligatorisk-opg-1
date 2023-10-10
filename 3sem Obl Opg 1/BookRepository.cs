using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3sem_Obl_Opg_1
{
    public class BookRepository
    {
        private static int _id = 1;

        public List<Book> books = new List<Book>
        {
            new Book{ Id = _id++, Title = "House of Leaves", Price = 750},
            new Book{ Id = _id++, Title = "The Hobbit", Price = 200},
            new Book{ Id = _id++, Title = "Animal Farm", Price = 180},
            new Book{ Id = _id++, Title = "Lord of the Flies", Price = 180},
            new Book{ Id = _id++, Title = "The Shining", Price = 400},
            new Book{ Id = _id++, Title = "1984", Price = 200}
        };

        public List<Book> Get(int? minPrice = null,
                                int? maxPrice = null,
                                string? orderBy = null)
        {
            List<Book> result = new List<Book>(books);

            if(minPrice != null)
            {
                result = result.Where(book => book.Price >= minPrice).ToList();     
            }

            if(maxPrice != null)
            {
                result = result.Where(book => book.Price <= maxPrice).ToList();
            }

            if(orderBy != null)
            {
                switch(orderBy.ToLower()) 
                {
                    case "title":
                        result = result.OrderBy(book => book.Title).ToList();
                        break;
                    case "price":
                        result = result.OrderBy(book => book.Price).ToList();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Invalid order by specifier: {orderBy}.");
                }
            }

            return result;
        }

        public Book GetById(int id)
        {
            return books.Find(book => book.Id == id);
        }

        public Book Add(Book book)
        {
            book.Id = _id++;
            book.TitleValidator();
            book.PriceValidator();
            books.Add(book);
            return book;
        }

        public Book Delete(int id)
        {
            Book? bookToDelete = GetById(id);
            if(bookToDelete != null)
            {
                books.Remove(bookToDelete);
            }
            return bookToDelete;
        }

        public Book Update(int id, Book book)
        {
            Book? bookToUpdate = GetById(id);
            if(bookToUpdate != null)
            {
                book.TitleValidator();
                book.PriceValidator();

                bookToUpdate.Title = book.Title;
                bookToUpdate.Price = book.Price;
            }
            return bookToUpdate;
        }

    }
}
