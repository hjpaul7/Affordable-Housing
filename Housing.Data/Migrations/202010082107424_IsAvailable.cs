namespace Housing_RedBadgeMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsAvailable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Application", "IsAvailable", c => c.Boolean(nullable: false));
            AddColumn("dbo.Application", "Housing_HousingId", c => c.Int());
            CreateIndex("dbo.Application", "Housing_HousingId");
            AddForeignKey("dbo.Application", "Housing_HousingId", "dbo.Housing", "HousingId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Application", "Housing_HousingId", "dbo.Housing");
            DropIndex("dbo.Application", new[] { "Housing_HousingId" });
            DropColumn("dbo.Application", "Housing_HousingId");
            DropColumn("dbo.Application", "IsAvailable");
        }
    }
}
