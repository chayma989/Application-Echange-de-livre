using Application_Echange_de_livre.DAO;
using Application_Echange_de_livre.Model;
using Application_Echange_de_livre.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Echange_de_livre.Service
{
    internal class CategoryService : ICategoryRepository
    {
        ICategoryRepository dao;

        public CategoryService()
        {
            dao = new CategorieDAO();
        }

        public void AddCategory(Categorie categorie)
        {
            dao.AddCategory(categorie);
        }

        public void DeleteCategory(int id)
        {
            dao.DeleteCategory(id);
        }

        public Categorie GetCatById(int id)
        {
           return dao.GetCatById(id);
        }

        public List<Categorie> GetdALL()
        {
           return dao.GetdALL();
        }

        public void Update(Categorie categorie)
        {
            dao.Update(categorie);
        }
    }
}
