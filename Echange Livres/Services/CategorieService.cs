using Application_Echange_de_livre.Model;
using Echange_Livres.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Echange_Livres.Services
{
    public class CategorieService : ICategorieService
    {
        private CategorieRepository repository;

        public CategorieService(CategorieRepository repository)
        {
            this.repository = repository;
        }

        public void Add(Categorie cat)
        {
            repository.Add(cat);
        }

        public void Delete(Categorie cat)
        {
            repository.Delete(cat);
        }

        public Categorie FindById(int id)
        {
            return repository.FindById(id);
        }

        public List<Categorie> GetAll()
        {
            return repository.GetAll();
        }

        public void Update(Categorie cat)
        {
            repository.Update(cat);
        }
    }
}