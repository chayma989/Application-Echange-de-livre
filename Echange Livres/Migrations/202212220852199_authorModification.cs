namespace Echange_Livres.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class authorModification : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Author_Id", "dbo.Books");
            DropForeignKey("dbo.Books", "Author_Id1", "dbo.Books");
            DropForeignKey("dbo.Books", "Book_Id", "dbo.Books");
            DropIndex("dbo.Books", new[] { "Author_Id" });
            DropIndex("dbo.Books", new[] { "Author_Id1" });
            DropIndex("dbo.Books", new[] { "Book_Id" });
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameAuthor = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AuthorBooks",
                c => new
                    {
                        Author_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Author_Id, t.Book_Id })
                .ForeignKey("dbo.Authors", t => t.Author_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Author_Id)
                .Index(t => t.Book_Id);
            
            DropColumn("dbo.Books", "NameAuthor");
            DropColumn("dbo.Books", "Discriminator");
            DropColumn("dbo.Books", "Author_Id");
            DropColumn("dbo.Books", "Author_Id1");
            DropColumn("dbo.Books", "Book_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Book_Id", c => c.Int());
            AddColumn("dbo.Books", "Author_Id1", c => c.Int());
            AddColumn("dbo.Books", "Author_Id", c => c.Int());
            AddColumn("dbo.Books", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Books", "NameAuthor", c => c.String());
            DropForeignKey("dbo.AuthorBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.AuthorBooks", "Author_Id", "dbo.Authors");
            DropIndex("dbo.AuthorBooks", new[] { "Book_Id" });
            DropIndex("dbo.AuthorBooks", new[] { "Author_Id" });
            DropTable("dbo.AuthorBooks");
            DropTable("dbo.Authors");
            CreateIndex("dbo.Books", "Book_Id");
            CreateIndex("dbo.Books", "Author_Id1");
            CreateIndex("dbo.Books", "Author_Id");
            AddForeignKey("dbo.Books", "Book_Id", "dbo.Books", "Id");
            AddForeignKey("dbo.Books", "Author_Id1", "dbo.Books", "Id");
            AddForeignKey("dbo.Books", "Author_Id", "dbo.Books", "Id");
        }
    }
}
