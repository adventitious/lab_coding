﻿namespace ComputerGames.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ComputerGames.GameData>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ComputerGames.GameData";
        }

        protected override void Seed(ComputerGames.GameData context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
