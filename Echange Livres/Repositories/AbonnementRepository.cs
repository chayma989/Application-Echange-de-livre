using Application_Echange_de_livre.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Echange_Livres.Repositories
{
    public class AbonnementRepository : IAbonnementRepository
    {
        private MyContext context;

        public AbonnementRepository(MyContext context)
        {
            this.context = context;
        }

        public void Add(Abonnement a)
        {
            context.Abonnements.Add(a);
            context.SaveChanges();
        }

        public void Delete(Abonnement a)
        {
            context.Entry(a).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public Abonnement FindById(int id)
        {
            return context.Abonnements.Find(id);
        }

        public List<Abonnement> GetAll()
        {
            return context.Abonnements.AsNoTracking().ToList();
        }

        public void Update(Abonnement a)
        {
            context.Entry(a).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}