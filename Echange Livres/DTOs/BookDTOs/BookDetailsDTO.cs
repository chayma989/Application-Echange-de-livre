using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Echange_Livres.DTOs.BookDTOs
{
    public class BookDetailsDTO
    {
        public int PointValue;//Attribute entre 1 et 10
        public string Collection { get; set; }
        public string Editor { get; set; }
        public string SousTitle { get; set; }

        [Required]
        public string Description { get; set; }
    }
}