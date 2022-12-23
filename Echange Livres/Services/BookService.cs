using Application_Echange_de_livre.Model;
using Echange_Livres.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace Echange_Livres.Services
{
    public class BookService : IBookService
    {
        private BookRepository repository;
        private MyContext context;

        public BookService(BookRepository repository)
        {
            this.repository = repository;
        }

        public void Add(Book book)
        {
            repository.Add(book);
        }

        public void Delete(Book book)
        {
            repository.Delete(book);
        }

        public Book FindById(int id)
        {
            return repository.FindById(id);
        }

        public List<Book> GetAll()
        {
            return repository.GetAll();
        }

        public List<Book> Search(string search)
        {
            return repository.Search(search);
        }

        public void Update(Book book)
        {
            repository.Update(book);
        }

       
    }
}