using Application_Echange_de_livre.Model;
using Echange_Livres.DTOs;
using Echange_Livres.Tools;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Echange_Livres.Repositories
{
    public class BookRepository : IBookRepository
    {
        private MyContext context;

        public void Add(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public void Delete(Book book)
        {

            context.Entry(book).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public Book FindById(int id)
        {
            return context.Books.Find(id);
        }

        public List<Book> GetAll()
        {
            return context.Books.AsNoTracking().ToList();
        }

        public List<Book> Search(string search)
        {
            return context.Books.AsNoTracking().Where(b => b.Title.Contains(search)
            || b.Editor.Contains(search) || b.ISBN.Contains(search)
            || b.Collection.Contains(search) || b.EditionDate.ToString().Contains(search)
            || b.Authors.ToString().Contains(search) 
            || b.Categories.ToString().Contains(search)
            ||b.Price.ToString().Contains(search)
            ||b.SubTitle.Contains(search)).ToList();
        }

        public void Update(Book book)
        {
            context.Entry(book).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}