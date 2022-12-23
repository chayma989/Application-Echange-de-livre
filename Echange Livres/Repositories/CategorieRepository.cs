using Application_Echange_de_livre.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Echange_Livres.Repositories
{
    public class CategorieRepository : ICategorieRepository
    {
        private MyContext context;

        public CategorieRepository(MyContext context)
        {
            this.context = context;
        }

        public void Add(Categorie cat)
        {
            context.Categories.Add(cat);
            context.SaveChanges();
        }

        public void Delete(Categorie cat)
        {

            context.Entry(cat).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public Categorie FindById(int id)
        {
            return context.Categories.Find(id);
        }

        public List<Categorie> GetAll()
        {
            return context.Categories.AsNoTracking().ToList();
        }

        public void Update(Categorie cat)
        {
            context.Entry(cat).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}