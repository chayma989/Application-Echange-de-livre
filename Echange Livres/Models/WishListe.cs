using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Echange_de_livre.Model
{
    public class WishListe
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }

        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
    }
}
