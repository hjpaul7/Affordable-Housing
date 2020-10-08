namespace Housing_RedBadgeMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Viewbag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Application", "Housings_HousingId", c => c.Int());
            AddColumn("dbo.Housing", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Application", "Housings_HousingId");
            CreateIndex("dbo.Housing", "ApplicationUser_Id");
            AddForeignKey("dbo.Housing", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.Application", "Housings_HousingId", "dbo.Housing", "HousingId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Application", "Housings_HousingId", "dbo.Housing");
            DropForeignKey("dbo.Housing", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.Housing", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Application", new[] { "Housings_HousingId" });
            DropColumn("dbo.Housing", "ApplicationUser_Id");
            DropColumn("dbo.Application", "Housings_HousingId");
        }
    }
}
