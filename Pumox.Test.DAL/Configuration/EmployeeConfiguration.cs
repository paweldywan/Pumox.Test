using Pumox.Test.BLL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Pumox.Test.DAL.Configuration
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(e => e.Company)
                .WithMany(c => c.Employees)
                .HasForeignKey(e => e.CompanyId);
        }
    }
}
