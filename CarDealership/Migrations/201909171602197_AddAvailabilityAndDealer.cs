namespace CarDealership.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvailabilityAndDealer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvailabilityTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Availability = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cars", "AvailabilityTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "AvailabilityTypeId");
            AddForeignKey("dbo.Cars", "AvailabilityTypeId", "dbo.AvailabilityTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Cars", "Availability");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Availability", c => c.String(nullable: false));
            DropForeignKey("dbo.Cars", "AvailabilityTypeId", "dbo.AvailabilityTypes");
            DropIndex("dbo.Cars", new[] { "AvailabilityTypeId" });
            DropColumn("dbo.Cars", "AvailabilityTypeId");
            DropTable("dbo.AvailabilityTypes");
        }
    }
}
