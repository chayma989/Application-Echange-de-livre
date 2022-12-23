using Application_Echange_de_livre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echange_Livres.Services
{
    public interface IBookService 
    {
        List<Book> GetAll();
        void Add(Book book);
        void Delete(Book book);
        void Update(Book book);
        Book FindById(int id);
        List<Book> Search(string search);
       
    }
}
