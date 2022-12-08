using Application_Echange_de_livre.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Echange_Livres.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20), MinLength(4)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50), MinLength(8)]
        public string Password { get; set; }

        [Required]
        [MaxLength(50), MinLength(9)]
        public string Adresse { get; set; }
        public int TotalPoints { get; set; }
        public string Photo { get; set; }
        public bool IsAdmin { get; set; }
        public virtual ICollection<Book> WishedBooks { get; set; }
    }
}