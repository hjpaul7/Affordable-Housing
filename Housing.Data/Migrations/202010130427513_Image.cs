namespace Housing_RedBadgeMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Housing", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Housing", "Image");
        }
    }
}
