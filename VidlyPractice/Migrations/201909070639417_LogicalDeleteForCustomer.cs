namespace VidlyPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogicalDeleteForCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Deleted", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Deleted");
        }
    }
}
