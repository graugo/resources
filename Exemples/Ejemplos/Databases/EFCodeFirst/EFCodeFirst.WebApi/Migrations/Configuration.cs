namespace EFCodeFirst.WebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFCodeFirst.WebApi.Infrastructure.Context.EFCodeFirstContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EFCodeFirst.WebApi.Infrastructure.Context.EFCodeFirstContext";
        }

        protected override void Seed(EFCodeFirst.WebApi.Infrastructure.Context.EFCodeFirstContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
