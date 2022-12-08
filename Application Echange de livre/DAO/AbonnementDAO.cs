using Application_Echange_de_livre.Model;
using Application_Echange_de_livre.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Application_Echange_de_livre.DAO
{
    internal class AbonnementDAO : IAbonnement
    {
        MyContext context;
        public AbonnementDAO()
        {
            context = new MyContext();
        }

        public TypeOfAbo Typeabn { get; private set; }

        public void DeleteUser(int id)
        {
            Abonnement abonnement = context.Abonnements.Find(id);

            context.Abonnements.Remove(abonnement);

            context.SaveChanges();
        }

        public Abonnement FindAbo(int id)
        {
            Abonnement abonnement = context.Abonnements.Find(id);
            if (abonnement == null)
            {
                throw new Exception("This User doesn't existe !");
            }
            return abonnement;
        }

        public void InsertUser(User user)
        {
            context.Users.Add(user);
            Typeabn = TypeOfAbo.ABONNE;
            context.SaveChanges();
        }
    }
}
