using Application_Echange_de_livre.Model;
using Echange_Livres.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Echange_Livres.Services
{
    public class AbonnementService : IAbonnementService
    {
        private AbonnementRepository repository;
        public void Add(Abonnement a)
        {
            repository.Add(a);
        }

        public void Delete(Abonnement a)
        {
            repository.Delete(a);
        }

        public Abonnement FindById(int id)
        {
          return  repository.FindById(id);
        }

        public List<Abonnement> GetAll()
        {
            return repository.GetAll();
        }

        public void Update(Abonnement a)
        {
            repository.Update(a);
        }
    }
}