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

        public User UserId { get; set; }
        public TypeOfAbo TypeOfAbo { get; set; }
    }

    public enum TypeOfAbo
    {
        ABONNE=1,
        PAS_ABONNE
    }
}
