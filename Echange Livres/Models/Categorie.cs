using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Echange_de_livre.Model
{
    public class Categorie
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public virtual ICollection<Book> Book { get; set; }
       
}
}
