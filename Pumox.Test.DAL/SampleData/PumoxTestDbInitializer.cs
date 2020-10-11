using System.Data.Entity;

namespace Pumox.Test.DAL.SampleData
{
    public class PumoxTestDbInitializer : CreateDatabaseIfNotExists<PumoxTestContext> 
    {
        protected override void Seed(PumoxTestContext context)
        {
            PumoxTestSeeder taskManagerSeeder = new PumoxTestSeeder(context);

            taskManagerSeeder.Seed();


            base.Seed(context);
        }
    }
}
