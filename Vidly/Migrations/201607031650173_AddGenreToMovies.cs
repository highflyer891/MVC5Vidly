namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreToMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreTypeId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "GenreTypeId");
        }
    }
}
