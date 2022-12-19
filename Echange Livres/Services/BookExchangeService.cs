using Application_Echange_de_livre.Model;
using Echange_Livres.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Echange_Livres.Services
{
    public class BookExchangeService : IBookExchangeService
    {
        private BookExchangeRepository repository;

        public BookExchangeService(BookExchangeRepository repository)
        {
            this.repository = repository;
        }

        public void Add(BookExchange bookEx)
        {
            repository.Add(bookEx);
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

        public void Update(BookExchange bookEx)
        {
             repository.Update(bookEx);
        }
    }
}