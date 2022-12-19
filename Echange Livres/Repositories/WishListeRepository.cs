using Application_Echange_de_livre.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Echange_Livres.Repositories
{
    public class WishListeRepository : IWishListeRepository
    {
        private MyContext context;
        public void Add(WishListe wishL)
        {
            context.WishListes.Add(wishL);
            context.SaveChanges();
        }

        public void Delete(WishListe wishL)
        {
            context.Entry(wishL).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public WishListe FindById(int id)
        {
            return context.WishListes.Find(id);
        }

        public List<WishListe> GetAll()
        {
            return context.WishListes.AsNoTracking().ToList();
        }

       
    }
}