namespace Housing_RedBadgeMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RatingDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SafetyRating", "Posted", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SafetyRating", "Posted");
        }
    }
}
