namespace RozliczanieSieNaMieszkaniu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetUpDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntryModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        What = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Session = c.Int(nullable: false),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EntryModels", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.EntryModels", new[] { "ApplicationUserId" });
            DropTable("dbo.EntryModels");
        }
    }
}
