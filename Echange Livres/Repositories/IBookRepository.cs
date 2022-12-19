using Application_Echange_de_livre.Model;
using Echange_Livres.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echange_Livres.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        void Add(Book book);
        void Delete(Book book);
        void Update(Book book);
        Book FindById(int id);
        List<Book> Search(string search);
        
    }
}
