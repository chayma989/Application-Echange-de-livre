using Application_Echange_de_livre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echange_Livres.Services
{
    public interface IBookExchangeService
    {
        void Delete(BookExchange bookEx);
        void SaveAndUpdate(BookExchange bookEx);
        BookExchange FindById(int id);
        List<BookExchange> GetAll();
        void ValidateExchange(Book b, int newOwner);


    }
}
