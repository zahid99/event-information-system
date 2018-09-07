namespace EventManagementInformation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        AreaId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AreaId);
            
            CreateTable(
                "dbo.EventVenues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AreaId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        Address = c.String(nullable: false),
                        Capacity = c.Int(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.AreaId, cascadeDelete: true)
                .Index(t => t.AreaId);
            
            CreateTable(
                "dbo.EventInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventTypeId = c.Int(nullable: false),
                        EventVenueId = c.Int(nullable: false),
                        EventName = c.String(nullable: false, maxLength: 250),
                        Details = c.String(),
                        Data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventTypes", t => t.EventTypeId, cascadeDelete: true)
                .ForeignKey("dbo.EventVenues", t => t.EventVenueId, cascadeDelete: true)
                .Index(t => t.EventTypeId)
                .Index(t => t.EventVenueId);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventInfoes", "EventVenueId", "dbo.EventVenues");
            DropForeignKey("dbo.EventInfoes", "EventTypeId", "dbo.EventTypes");
            DropForeignKey("dbo.EventVenues", "AreaId", "dbo.Areas");
            DropIndex("dbo.EventInfoes", new[] { "EventVenueId" });
            DropIndex("dbo.EventInfoes", new[] { "EventTypeId" });
            DropIndex("dbo.EventVenues", new[] { "AreaId" });
            DropTable("dbo.EventTypes");
            DropTable("dbo.EventInfoes");
            DropTable("dbo.EventVenues");
            DropTable("dbo.Areas");
        }
    }
}
