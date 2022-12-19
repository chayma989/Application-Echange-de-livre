using Application_Echange_de_livre.Model;
using Echange_Livres.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Echange_Livres.Services
{
    public class WishListeService : IWishListeService
    {
        private WishListeRepository repository;
        public void Add(WishListe wishL)
        {
            repository.Add(wishL);
        }

        public void Delete(WishListe wishL)
        {
            repository.Delete(wishL);
        }

        public WishListe FindById(int id)
        {
            return repository.FindById(id);
        }

        public List<WishListe> GetAll()
        {
            return repository.GetAll();
        }
    }
}