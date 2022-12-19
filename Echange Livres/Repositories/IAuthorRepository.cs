using Application_Echange_de_livre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echange_Livres.Repositories
{
    public interface IAuthorRepository
    {
        void Add(Author author);
        void Delete(Author author);
        void Update(Author author);
        Author FindById(int id);
        List<Author> GetAll();
    }
}
