using Application_Echange_de_livre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Echange_Livres.DTOs.BookDTOs
{
    public class BookEchangeDTO
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public Book Book { get; set; }
        public User OldOwner { get; set; }
    }
}