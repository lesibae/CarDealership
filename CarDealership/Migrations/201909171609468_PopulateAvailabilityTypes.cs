namespace CarDealership.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAvailabilityTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AvailabilityTypes (Availability) VALUES('In Stock')");
            Sql("INSERT INTO AvailabilityTypes (Availability) VALUES('Pending Sale')");
            Sql("INSERT INTO AvailabilityTypes (Availability) VALUES('Sold')");
        }
        
        public override void Down()
        {
        }
    }
}
