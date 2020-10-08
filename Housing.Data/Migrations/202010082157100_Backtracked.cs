namespace Housing_RedBadgeMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Backtracked : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Application", "UnitsRequested", c => c.Int(nullable: false));
            DropColumn("dbo.Application", "IsAvailable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Application", "IsAvailable", c => c.Boolean(nullable: false));
            DropColumn("dbo.Application", "UnitsRequested");
        }
    }
}
