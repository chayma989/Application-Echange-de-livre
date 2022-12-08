using Application_Echange_de_livre.DAO;
using Application_Echange_de_livre.Model;
using Application_Echange_de_livre.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Echange_de_livre.Service
{
    internal class BookService : IBookRepository
    {
        IBookRepository dao;

        public BookService()
        {
            dao = new BookDAO();
        }
        public void AddBook(Book book)
        {
            dao.AddBook(book);
        }

        public void DeleteBook(int id)
        {
            dao.DeleteBook(id);
        }

        public List<Book> GetALL()
        {
            return dao.GetALL();
        }

        public Book GetBookById(int id)
        {
            return dao.GetBookById(id);
        }

        public void SaveOrUpdate(BookExchange exc)
        {
            dao.SaveOrUpdate(exc);
        }
    }
}
