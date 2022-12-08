using Application_Echange_de_livre.Model;
using Application_Echange_de_livre.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Echange_de_livre.DAO
{
    internal class WishDAO : IWishListe
    {
        BookDAO bookDao;

        public void DeleteFromFavorites(int id)
        {
            bookDao.DeleteBook(id);
        }

        public void InsertToFavorites(Book book)
        {
            bookDao.AddBook(book);
        }
    }
}
