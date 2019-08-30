namespace VidlyPractice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes(Id, SigUpFee, DurationInMonth, DiscountRate) VALUES(1, 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes(Id, SigUpFee, DurationInMonth, DiscountRate) VALUES(2, 30, 1, 10)");
            Sql("INSERT INTO MembershipTypes(Id, SigUpFee, DurationInMonth, DiscountRate) VALUES(3, 90, 3, 15)");
            Sql("INSERT INTO MembershipTypes(Id, SigUpFee, DurationInMonth, DiscountRate) VALUES(4, 300, 12, 25)");
        }
        
        public override void Down()
        {
        }
    }
}
