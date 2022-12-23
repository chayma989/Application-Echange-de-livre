namespace Echange_Livres.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abonnementModif : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AbonnementDTOes", "UserId_Id", "dbo.Users");
            DropIndex("dbo.AbonnementDTOes", new[] { "UserId_Id" });
            RenameColumn(table: "dbo.Abonnements", name: "UserId_Id", newName: "userAbo_Id");
            RenameIndex(table: "dbo.Abonnements", name: "IX_UserId_Id", newName: "IX_userAbo_Id");
            AddColumn("dbo.Abonnements", "DateAbo", c => c.DateTime(nullable: false));
            DropTable("dbo.AbonnementDTOes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AbonnementDTOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsAbo = c.Boolean(nullable: false),
                        UserId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Abonnements", "DateAbo");
            RenameIndex(table: "dbo.Abonnements", name: "IX_userAbo_Id", newName: "IX_UserId_Id");
            RenameColumn(table: "dbo.Abonnements", name: "userAbo_Id", newName: "UserId_Id");
            CreateIndex("dbo.AbonnementDTOes", "UserId_Id");
            AddForeignKey("dbo.AbonnementDTOes", "UserId_Id", "dbo.Users", "Id");
        }
    }
}
