using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Echange_de_livre.Model
{
    public class BookExchange
    {
       public int Id { get; set; }
       public DateTime CreationDate { get; set; }
       public Book Book { get; set; }
       public User OldOwner { get; set; }

    }
}
