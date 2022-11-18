using Application_Echange_de_livre.Model;
using Application_Echange_de_livre.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Application_Echange_de_livre.DAO
{
    public class BookDAO : IBookRepository
    {
        MyContext context;
        public BookDAO()
        {
            context = new MyContext();
        }
        public void AddBook(Book book)
        {
            context.Books.Add(book);
            context.Entry(book).State = EntityState.Added;
            context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            Book book = context.Books.Find(id);

            context.Books.Remove(book);

            context.SaveChanges();
        }

      

        public List<Book> GetdALL()
        {
            return context.Books.ToList();
        }

        public void SaveOrUpdate(BookExchange exc)
        {
            context.Entry(exc).State = EntityState.Modified;
            context.SaveChanges();
        }

        Book IBookRepository.GetBookById(int id)
        {
            Book book = context.Books.Find(id);
            if (book == null)
            {
                throw new Exception("This Book doesn't existe !");
            }
            return book;
        }
    }
}
