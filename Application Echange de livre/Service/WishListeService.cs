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
    internal class WishListeService : IWishListe
    {
        IWishListe dao;

        public WishListeService()
        {
            dao = new WishDAO();
        }
        public void DeleteFromFavorites(int id)
        {
            dao.DeleteFromFavorites(id);
        }

        public void InsertToFavorites(Book book)
        {
            dao.InsertToFavorites(book);
        }
    }
}
