using PDWebCore.Context;
using Pumox.Test.BLL.Models;
using Pumox.Test.DAL.Configuration;
using Pumox.Test.DAL.Entities;
using Pumox.Test.DAL.SampleData;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Pumox.Test.DAL
{
    public class PumoxTestContext : MainWebDbContext<ApplicationUser>
    {
        public PumoxTestContext() : base("PumoxTestContext")
        {
            //Database.SetInitializer(new NullDatabaseInitializer<PumoxTestContext>()); //Na produkcji też

            Database.SetInitializer(new PumoxTestDbInitializer());
        }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Use singular table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new CompanyConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
