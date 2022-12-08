using Application_Echange_de_livre.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Echange_Livres.DTOs
{
    public class BookDTO
    {
        public class Book
        {
            public int Id { get; set; }

            [Required]
            public string Title { get; set; }

            [Required]
            [StringLength(13, ErrorMessage = "Invalid ISBN length")]
            public string ISBN { get; private set; }

            [Required]
            public double Price { get; set; }

            public int PointValue;//Attribute entre 1 et 10
            public string Collection { get; set; }
            public string Editor { get; set; }
            public string SousTitle { get; set; }

            [Required]
            public string Description { get; set; }
            public DateTime EditionDate { get; set; }
            public User OwnerId { get; set; }
            public Author Author { get; set; }
            public string Photo { get; set; }
            public BookState BookState { get; set; }
            public virtual ICollection<Author> Authors { get; set; }
            public virtual ICollection<Categorie> Categories { get; set; }
        }

        public enum BookState
        {
            VERY_GOOD = 1,
            GOOD,
            MEDIOCRE,
            WORN
        }
    }
}