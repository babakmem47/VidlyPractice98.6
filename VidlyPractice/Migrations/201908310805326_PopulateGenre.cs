namespace VidlyPractice.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id, Name) VALUES(1, 'Comedy')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(2, 'Action')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(3, 'Family')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(4, 'Romance')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(5, 'Science Fiction')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(6, 'Horror')");

        }

        public override void Down()
        {
        }
    }
}
