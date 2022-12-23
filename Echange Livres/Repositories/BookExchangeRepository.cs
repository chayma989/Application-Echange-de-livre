using Application_Echange_de_livre.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Echange_Livres.Repositories
{
    public class BookExchangeRepository : IBookExchangeRepository
    {
        private MyContext context;

        public BookExchangeRepository(MyContext context)
        {
            this.context = context;
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

        public void SaveAndUpdate(BookExchange bookEx)
        {
            if (bookEx.Id == 0)
            {
                context.BookExchanges.Add(bookEx);
            }
            else
            {
                context.Entry(bookEx).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

      
    }
}