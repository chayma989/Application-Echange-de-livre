using Echange_Livres.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Echange_de_livre.Model
{
    public class Abonnement 
    {
        public int Id { get; set; }
        public DateTime DateAbo { get; set; }
        public bool IsAbo { get; set; }
        public User userAbo { get; set; }



    }

}
