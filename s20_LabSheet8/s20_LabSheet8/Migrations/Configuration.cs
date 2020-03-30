namespace s20_LabSheet8.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<s20_LabSheet8.TeamData>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "s20_LabSheet8.TeamData";
        }

        protected override void Seed(s20_LabSheet8.TeamData context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
