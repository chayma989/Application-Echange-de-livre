namespace Echange_Livres.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificationUserAdd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Adress_Id", "dbo.Users");
            DropForeignKey("dbo.UserDTOes", "Adresse_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Adress_Id" });
            DropIndex("dbo.UserDTOes", new[] { "Adresse_Id" });
            AddColumn("dbo.Users", "Adress", c => c.String());
            AddColumn("dbo.UserDTOes", "Adress", c => c.String());
            DropColumn("dbo.Users", "Street");
            DropColumn("dbo.Users", "CodePostale");
            DropColumn("dbo.Users", "Country");
            DropColumn("dbo.Users", "State");
            DropColumn("dbo.Users", "Discriminator");
            DropColumn("dbo.Users", "Adress_Id");
            DropColumn("dbo.UserDTOes", "Street");
            DropColumn("dbo.UserDTOes", "CodePostale");
            DropColumn("dbo.UserDTOes", "Country");
            DropColumn("dbo.UserDTOes", "State");
            DropColumn("dbo.UserDTOes", "Discriminator");
            DropColumn("dbo.UserDTOes", "Adresse_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserDTOes", "Adresse_Id", c => c.Int());
            AddColumn("dbo.UserDTOes", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.UserDTOes", "State", c => c.String());
            AddColumn("dbo.UserDTOes", "Country", c => c.String());
            AddColumn("dbo.UserDTOes", "CodePostale", c => c.String());
            AddColumn("dbo.UserDTOes", "Street", c => c.String());
            AddColumn("dbo.Users", "Adress_Id", c => c.Int());
            AddColumn("dbo.Users", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Users", "State", c => c.String());
            AddColumn("dbo.Users", "Country", c => c.String());
            AddColumn("dbo.Users", "CodePostale", c => c.String());
            AddColumn("dbo.Users", "Street", c => c.String());
            DropColumn("dbo.UserDTOes", "Adress");
            DropColumn("dbo.Users", "Adress");
            CreateIndex("dbo.UserDTOes", "Adresse_Id");
            CreateIndex("dbo.Users", "Adress_Id");
            AddForeignKey("dbo.UserDTOes", "Adresse_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Users", "Adress_Id", "dbo.Users", "Id");
        }
    }
}
