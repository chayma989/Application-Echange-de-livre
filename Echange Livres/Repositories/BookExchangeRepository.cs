using Application_Echange_de_livre.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Echange_Livres.Repositories
{
    public class BookExchangeRepository : IBookExchange
    {
        private MyContext context;
        public void Add(BookExchange bookEx)
        {
            context.BookExchanges.Add(bookEx);
            context.SaveChanges();
        }

        public void Delete(BookExchange bookEx)
        {
            context.Entry(bookEx).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public BookExchange FindById(int id)
        {
            return context.BookExchanges.Find(id);
        }

        public List<BookExchange> GetAll()
        {
            return context.BookExchanges.AsNoTracking().ToList();
        }

        public void Update(BookExchange bookEx)
        {
            context.Entry(bookEx).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}