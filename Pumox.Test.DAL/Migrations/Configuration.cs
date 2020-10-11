namespace Pumox.Test.DAL.Migrations
{
    using Pumox.Test.DAL.SampleData;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<PumoxTestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PumoxTestContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            PumoxTestSeeder taskManagerSeeder = new PumoxTestSeeder(context);

            taskManagerSeeder.Seed();
        }
    }
}
