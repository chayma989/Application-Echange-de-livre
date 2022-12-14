using Application_Echange_de_livre.Model;
using Application_Echange_de_livre.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Echange_de_livre.DAO
{
    public class CategorieDAO : ICategoryRepository
    {
        MyContext context;
        public CategorieDAO()
        {
            context = new MyContext();
        }
        public void AddCategory(Categorie categorie)
        {
            context.Categories.Add(categorie);
            context.Entry(categorie).State = EntityState.Added;
            context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            Categorie categorie = context.Categories.Find(id);

            context.Categories.Remove(categorie);

            context.SaveChanges();
        }

        public List<Categorie> GetdALL()
        {
            return context.Categories.ToList();
        }

        public void Update(Categorie categorie)
        {
            context.Entry(categorie).State = EntityState.Modified;
            context.SaveChanges();
        }

        public Categorie GetCatById(int id)
        {
            Categorie cat = context.Categories.Find(id);
            if (cat == null)
            {
                throw new Exception("This category doesn't existe !");
            }
            return cat;
        }
    }
}
