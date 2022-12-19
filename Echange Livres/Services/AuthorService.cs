using Application_Echange_de_livre.Model;
using Echange_Livres.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Echange_Livres.Services
{
    public class AuthorService : IAuthorService
    {
        private AuthorRepository repository;

        public AuthorService(AuthorRepository repository)
        {
            this.repository = repository;
        }

        public void Add(Author author)
        {
            repository.Add(author);
        }

        public void Delete(Author author)
        {
            repository.Delete(author);
        }

        public Author FindById(int id)
        {
            return repository.FindById(id);
        }

        public List<Author> GetAll()
        {
            return repository.GetAll();
        }

        public void Update(Author author)
        {
            repository.Update(author);
        }
    }
}