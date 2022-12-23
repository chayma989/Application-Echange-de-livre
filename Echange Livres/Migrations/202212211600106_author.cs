namespace Echange_Livres.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class author : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AuthorBooks", "Author_Id", "dbo.Books");
            DropForeignKey("dbo.AuthorBooks", "Book_Id", "dbo.Books");
            DropIndex("dbo.AuthorBooks", new[] { "Author_Id" });
            DropIndex("dbo.AuthorBooks", new[] { "Book_Id" });
            AddColumn("dbo.Books", "Author_Id", c => c.Int());
            AddColumn("dbo.Books", "Author_Id1", c => c.Int());
            AddColumn("dbo.Books", "Book_Id", c => c.Int());
            CreateIndex("dbo.Books", "Author_Id");
            CreateIndex("dbo.Books", "Author_Id1");
            CreateIndex("dbo.Books", "Book_Id");
            AddForeignKey("dbo.Books", "Author_Id", "dbo.Books", "Id");
            AddForeignKey("dbo.Books", "Author_Id1", "dbo.Books", "Id");
            AddForeignKey("dbo.Books", "Book_Id", "dbo.Books", "Id");
            DropTable("dbo.AuthorBooks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AuthorBooks",
                c => new
                    {
                        Author_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Author_Id, t.Book_Id });
            
            DropForeignKey("dbo.Books", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Books", "Author_Id1", "dbo.Books");
            DropForeignKey("dbo.Books", "Author_Id", "dbo.Books");
            DropIndex("dbo.Books", new[] { "Book_Id" });
            DropIndex("dbo.Books", new[] { "Author_Id1" });
            DropIndex("dbo.Books", new[] { "Author_Id" });
            DropColumn("dbo.Books", "Book_Id");
            DropColumn("dbo.Books", "Author_Id1");
            DropColumn("dbo.Books", "Author_Id");
            CreateIndex("dbo.AuthorBooks", "Book_Id");
            CreateIndex("dbo.AuthorBooks", "Author_Id");
            AddForeignKey("dbo.AuthorBooks", "Book_Id", "dbo.Books", "Id");
            AddForeignKey("dbo.AuthorBooks", "Author_Id", "dbo.Books", "Id");
        }
    }
}
