using Application_Echange_de_livre.Model;
using Echange_Livres.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Echange_Livres.Services
{
    public class BookExchangeService : IBookExchangeService
    {
        private BookExchangeRepository repository;
        private MyContext context;

        public BookExchangeService(BookExchangeRepository repository)
        {
            this.repository = repository;
        }

       
        public void Delete(BookExchange bookEx)
        {
            repository.Delete(bookEx);
        }

        public BookExchange FindById(int id)
        {
            return repository.FindById(id);
        }

        public List<BookExchange> GetAll()
        {
            return repository.GetAll();
        }

        public void SaveAndUpdate(BookExchange bookEx)
        {
            repository.SaveAndUpdate(bookEx);
        }

       

        public void ValidateExchange(Book b, int newOwner)
        {

            BookExchange book = (BookExchange)context.BookExchanges.Where(bo => bo.Book.Equals(b) || bo.OldOwner.Equals(newOwner));
            repository.SaveAndUpdate(book);
        }
    }
}