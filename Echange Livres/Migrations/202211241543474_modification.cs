namespace Echange_Livres.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abonnements", "IsAbo", c => c.Boolean(nullable: false));
            DropColumn("dbo.Abonnements", "Typeabn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abonnements", "Typeabn", c => c.Int(nullable: false));
            DropColumn("dbo.Abonnements", "IsAbo");
        }
    }
}
