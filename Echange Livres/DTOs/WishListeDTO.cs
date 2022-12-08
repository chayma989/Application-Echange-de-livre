using Application_Echange_de_livre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Echange_Livres.DTOs
{
    public class WishListeDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }

        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
    }
}