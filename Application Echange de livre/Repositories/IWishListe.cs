using Application_Echange_de_livre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Echange_de_livre.Repositories
{
    public interface IWishListe
    {
        void InsertToFavorites(Book book);
        void DeleteFromFavorites(int id);
    }
}
