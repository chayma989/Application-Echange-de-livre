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
       
        private WishListeRepository wishListeRepository;

        public WishListeService(WishListeRepository wishListeRepository)
        {
            this.wishListeRepository = wishListeRepository;
        }

        public void Add(WishListe wishL)
        {
            wishListeRepository.Add(wishL);
        }

        public void Delete(WishListe wishL)
        {
            wishListeRepository.Delete(wishL);
        }

        public WishListe FindById(int id)
        {
            return wishListeRepository.FindById(id);
        }

        public List<WishListe> GetAll()
        {
            return wishListeRepository.GetAll();
        }
    }
}