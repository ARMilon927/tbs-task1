namespace EmployeeDetails.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeetablemodified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "CityId", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "ThanaId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "ThanaId");
            DropColumn("dbo.Employees", "CityId");
        }
    }
}
