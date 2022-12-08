using Application_Echange_de_livre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Echange_de_livre.Repositories
{
    internal interface IAbonnement
    {
        void InsertUser(User user);
        void DeleteUser(int id);
        Abonnement FindAbo(int id);

    }
}
