using Application_Echange_de_livre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echange_Livres.Services
{
   public interface ICategorieService
    {
        void Add(Categorie cat);
        void Delete(Categorie cat);
        void Update(Categorie cat);
        Categorie FindById(int id);
        List<Categorie> GetAll();
    }
}
