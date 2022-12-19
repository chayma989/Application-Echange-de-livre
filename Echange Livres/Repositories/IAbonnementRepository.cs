using Application_Echange_de_livre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echange_Livres.Repositories
{
   public interface IAbonnementRepository
    {
        void Add(Abonnement a);
        void Delete(Abonnement a);
        void Update(Abonnement a);
        Abonnement FindById(int id);
        List<Abonnement> GetAll();
    }
}
