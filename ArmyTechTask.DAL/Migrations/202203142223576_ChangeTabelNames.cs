namespace ArmyTechTask.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTabelNames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Branches", newName: "Branch");
            RenameTable(name: "dbo.InvoiceDetails", newName: "InvoiceDetail");
            RenameTable(name: "dbo.Cities", newName: "City");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.City", newName: "Cities");
            RenameTable(name: "dbo.InvoiceDetail", newName: "InvoiceDetails");
            RenameTable(name: "dbo.Branch", newName: "Branches");
        }
    }
}
