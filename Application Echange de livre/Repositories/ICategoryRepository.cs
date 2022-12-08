using Application_Echange_de_livre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Echange_de_livre.Repositories
{
    public interface ICategoryRepository
    {
        List<Categorie> GetdALL();
        Categorie GetCatById(int id);
        void AddCategory(Categorie categorie);
        void DeleteCategory(int id);
        void Update(Categorie categorie);
    }
}
