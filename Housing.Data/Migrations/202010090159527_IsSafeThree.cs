namespace Housing_RedBadgeMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsSafeThree : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Housing", "IsSafe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Housing", "IsSafe", c => c.Boolean(nullable: false));
        }
    }
}
