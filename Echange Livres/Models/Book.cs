
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Echange_de_livre.Model
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
        public string SubTitle { get; set; }

        [Required]
        public string Description { get; set; }
        public DateTime EditionDate { get; set; }
        public User OwnerId { get; set; }
        public string Photo { get; set; }
        public BookState BookState { get; set; }
        public virtual IEnumerable<Author> Authors { get; set; }
        public virtual IEnumerable<Categorie> Categories { get; set; }
    }

    public enum BookState
    {
        VERY_GOOD=1,
        GOOD, 
        MEDIOCRE, 
        WORN
    }
}
