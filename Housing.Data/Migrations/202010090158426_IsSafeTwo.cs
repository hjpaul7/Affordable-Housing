namespace Housing_RedBadgeMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsSafeTwo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Housing", "IsSafe", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Housing", "IsSafe");
        }
    }
}
