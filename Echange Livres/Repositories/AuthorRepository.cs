using Application_Echange_de_livre.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Echange_Livres.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private MyContext context;
        public void Add(Author author)
        {
            context.Authors.Add(author);
            context.SaveChanges();
        }

        public void Delete(Author author)
        {
            context.Entry(author).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public Author FindById(int id)
        {
            return context.Authors.Find(id);
        }

        public List<Author> GetAll()
        {
            return context.Authors.AsNoTracking().ToList();
        }

        public void Update(Author author)
        {
            context.Entry(author).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}