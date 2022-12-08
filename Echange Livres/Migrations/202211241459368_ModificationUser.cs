namespace Echange_Livres.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificationUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "TypOfUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "TypOfUser", c => c.Int(nullable: false));
        }
    }
}
