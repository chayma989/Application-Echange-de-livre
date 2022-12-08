﻿using Application_Echange_de_livre.Model;
using System;
using System.Data.Entity;
using System.Linq;

namespace Echange_Livres.Repositories
{
    public class MyContext : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « MyContext » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « Echange_Livres.Repositories.MyContext » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « MyContext » dans le fichier de configuration de l'application.
        public MyContext()
            : base("name=MyContext")
        {
        }

        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
         public virtual DbSet<User> Users { get; set; }
         public virtual DbSet<Book> Books { get; set; }
         public virtual DbSet<BookExchange> BookExchanges  { get; set; }
         public virtual DbSet<Author> Authors { get; set; }
         public virtual DbSet<Categorie> Categories { get; set; }
         public virtual DbSet<WishListe> WishListes { get; set; }
         public virtual DbSet<Abonnement> Abonnements { get; set; }

        public System.Data.Entity.DbSet<Echange_Livres.DTOs.UserDTO> UtilisateurDTOes { get; set; }

        public System.Data.Entity.DbSet<Echange_Livres.DTOs.AbonnementDTO> AbonnementDTOes { get; set; }

        public System.Data.Entity.DbSet<Echange_Livres.DTOs.CategorieDTO> CategorieDTOes { get; set; }

        public System.Data.Entity.DbSet<Echange_Livres.DTOs.AuthorDTO> AuthorDTOes { get; set; }

        public System.Data.Entity.DbSet<Echange_Livres.DTOs.BookDTOs.BookEchangeDTO> BookEchangeDTOes { get; set; }

        public System.Data.Entity.DbSet<Echange_Livres.DTOs.WishListeDTO> WishListeDTOes { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}