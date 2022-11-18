namespace Application_Echange_de_livre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abonnements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeOfAbo = c.Int(nullable: false),
                        UserId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId_Id)
                .Index(t => t.UserId_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 50),
                        Adresse = c.String(nullable: false, maxLength: 50),
                        TotalPoints = c.Int(nullable: false),
                        TypOfUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ISBN = c.String(nullable: false, maxLength: 13),
                        Price = c.Double(nullable: false),
                        EditionDate = c.DateTime(nullable: false),
                        PointValue = c.Int(nullable: false),
                        Collection = c.String(),
                        Editeur = c.String(),
                        Edition = c.Int(nullable: false),
                        Sous_Titre = c.String(),
                        BookState = c.Int(nullable: false),
                        Author_Id = c.Int(),
                        AuthorId_Id = c.Int(),
                        OwnerId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.Author_Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId_Id)
                .ForeignKey("dbo.Users", t => t.OwnerId_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.AuthorId_Id)
                .Index(t => t.OwnerId_Id);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookExchanges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        Book_Id = c.Int(),
                        OldOwner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .ForeignKey("dbo.Users", t => t.OldOwner_Id)
                .Index(t => t.Book_Id)
                .Index(t => t.OldOwner_Id);
            
            CreateTable(
                "dbo.WishListes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.CategorieBooks",
                c => new
                    {
                        Categorie_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Categorie_Id, t.Book_Id })
                .ForeignKey("dbo.Categories", t => t.Categorie_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Categorie_Id)
                .Index(t => t.Book_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WishListes", "UserId", "dbo.Users");
            DropForeignKey("dbo.WishListes", "BookId", "dbo.Books");
            DropForeignKey("dbo.BookExchanges", "OldOwner_Id", "dbo.Users");
            DropForeignKey("dbo.BookExchanges", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Abonnements", "UserId_Id", "dbo.Users");
            DropForeignKey("dbo.Books", "OwnerId_Id", "dbo.Users");
            DropForeignKey("dbo.CategorieBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.CategorieBooks", "Categorie_Id", "dbo.Categories");
            DropForeignKey("dbo.Authors", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Books", "AuthorId_Id", "dbo.Authors");
            DropForeignKey("dbo.Books", "Author_Id", "dbo.Authors");
            DropIndex("dbo.CategorieBooks", new[] { "Book_Id" });
            DropIndex("dbo.CategorieBooks", new[] { "Categorie_Id" });
            DropIndex("dbo.WishListes", new[] { "BookId" });
            DropIndex("dbo.WishListes", new[] { "UserId" });
            DropIndex("dbo.BookExchanges", new[] { "OldOwner_Id" });
            DropIndex("dbo.BookExchanges", new[] { "Book_Id" });
            DropIndex("dbo.Authors", new[] { "Book_Id" });
            DropIndex("dbo.Books", new[] { "OwnerId_Id" });
            DropIndex("dbo.Books", new[] { "AuthorId_Id" });
            DropIndex("dbo.Books", new[] { "Author_Id" });
            DropIndex("dbo.Abonnements", new[] { "UserId_Id" });
            DropTable("dbo.CategorieBooks");
            DropTable("dbo.WishListes");
            DropTable("dbo.BookExchanges");
            DropTable("dbo.Categories");
            DropTable("dbo.Authors");
            DropTable("dbo.Books");
            DropTable("dbo.Users");
            DropTable("dbo.Abonnements");
        }
    }
}
