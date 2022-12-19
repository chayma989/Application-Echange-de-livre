using Application_Echange_de_livre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echange_Livres.Services
{
    public interface IWishListeService
    {
        void Add(WishListe wishL);
        void Delete(WishListe wishL);
        WishListe FindById(int id);
        List<WishListe> GetAll();
    }
}
