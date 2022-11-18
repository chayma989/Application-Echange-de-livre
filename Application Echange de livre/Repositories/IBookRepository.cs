using Application_Echange_de_livre.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Echange_de_livre.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetdALL();
        Book GetBookById(int id);
        void AddBook(Book book);
        void DeleteBook(int id);
        void SaveOrUpdate(BookExchange exc);
    }
}