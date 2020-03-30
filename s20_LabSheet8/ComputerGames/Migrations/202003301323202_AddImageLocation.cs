namespace ComputerGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "ImageLocation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Characters", "ImageLocation");
        }
    }
}
