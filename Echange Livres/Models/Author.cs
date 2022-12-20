using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Echange_de_livre.Model
{
    //object value
    public class Author : Book
    {
        //public int Id { get; set; }
        public string NameAuthor { get; set; }

       //La liste des Books selon les auteurs.
        public virtual ICollection<Book> Books { get; set; }



        //Génerer le constructeur vide.
        public Author()
        {
        }
    }
}
