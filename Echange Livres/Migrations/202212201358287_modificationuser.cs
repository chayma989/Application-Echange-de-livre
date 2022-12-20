namespace Echange_Livres.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificationuser : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Books", new[] { "OwnerId_Id" });
            DropColumn("dbo.Books", "UserDTO_Id");
            RenameColumn(table: "dbo.Books", name: "OwnerId_Id", newName: "UserDTO_Id");
            AddColumn("dbo.UserDTOes", "Street", c => c.String());
            AddColumn("dbo.UserDTOes", "CodePostale", c => c.String());
            AddColumn("dbo.UserDTOes", "Country", c => c.String());
            AddColumn("dbo.UserDTOes", "State", c => c.String());
            AddColumn("dbo.UserDTOes", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Books", "OwnerId_Id");
            DropColumn("dbo.Users", "Street");
            DropColumn("dbo.Users", "CodePostale");
            DropColumn("dbo.Users", "Country");
            DropColumn("dbo.Users", "State");
            DropColumn("dbo.Users", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Users", "State", c => c.String());
            AddColumn("dbo.Users", "Country", c => c.String());
            AddColumn("dbo.Users", "CodePostale", c => c.String());
            AddColumn("dbo.Users", "Street", c => c.String());
            DropIndex("dbo.Books", new[] { "OwnerId_Id" });
            DropColumn("dbo.UserDTOes", "Discriminator");
            DropColumn("dbo.UserDTOes", "State");
            DropColumn("dbo.UserDTOes", "Country");
            DropColumn("dbo.UserDTOes", "CodePostale");
            DropColumn("dbo.UserDTOes", "Street");
            RenameColumn(table: "dbo.Books", name: "UserDTO_Id", newName: "OwnerId_Id");
            AddColumn("dbo.Books", "UserDTO_Id", c => c.Int());
            CreateIndex("dbo.Books", "OwnerId_Id");
        }
    }
}
