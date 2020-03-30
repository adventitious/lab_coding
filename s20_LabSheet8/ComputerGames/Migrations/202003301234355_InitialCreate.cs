namespace ComputerGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        CharacterID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Ability = c.String(),
                        YearOfFirstAppearance = c.Int(nullable: false),
                        GameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterID)
                .ForeignKey("dbo.Games", t => t.GameID, cascadeDelete: true)
                .Index(t => t.GameID);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Genre = c.String(),
                        Platform = c.String(),
                        YearOfRelease = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "GameID", "dbo.Games");
            DropIndex("dbo.Characters", new[] { "GameID" });
            DropTable("dbo.Games");
            DropTable("dbo.Characters");
        }
    }
}
