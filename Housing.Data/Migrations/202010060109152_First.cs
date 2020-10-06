namespace Housing_RedBadgeMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Application",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HousingId = c.Int(nullable: false),
                        ApplicantId = c.String(maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        MonthlyIncome = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicantId)
                .ForeignKey("dbo.Housing", t => t.HousingId, cascadeDelete: true)
                .Index(t => t.HousingId)
                .Index(t => t.ApplicantId);
            
            CreateTable(
                "dbo.SafetyRating",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HousingId = c.Int(nullable: false),
                        ApplicantId = c.String(maxLength: 128),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicantId)
                .ForeignKey("dbo.Housing", t => t.HousingId, cascadeDelete: true)
                .Index(t => t.HousingId)
                .Index(t => t.ApplicantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SafetyRating", "HousingId", "dbo.Housing");
            DropForeignKey("dbo.SafetyRating", "ApplicantId", "dbo.ApplicationUser");
            DropForeignKey("dbo.Application", "HousingId", "dbo.Housing");
            DropForeignKey("dbo.Application", "ApplicantId", "dbo.ApplicationUser");
            DropIndex("dbo.SafetyRating", new[] { "ApplicantId" });
            DropIndex("dbo.SafetyRating", new[] { "HousingId" });
            DropIndex("dbo.Application", new[] { "ApplicantId" });
            DropIndex("dbo.Application", new[] { "HousingId" });
            DropTable("dbo.SafetyRating");
            DropTable("dbo.Application");
        }
    }
}
