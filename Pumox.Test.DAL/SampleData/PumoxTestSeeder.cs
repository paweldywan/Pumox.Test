using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PDCore.Extensions;
using PDCoreNew.Extensions;
using Pumox.Test.BLL.Enums;
using Pumox.Test.DAL.Entities;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Pumox.Test.DAL.SampleData
{
    public class PumoxTestSeeder
    {
        private readonly PumoxTestContext context;

        public PumoxTestSeeder(PumoxTestContext context)
        {
            this.context = context;
        }

        public void Seed()
        {
            SeedRoles();

            SeedUsers();

            SeedCompanies();
        }

        private void SeedCompanies()
        {
            const string companyName = "Firma";
            const string employeeName = "Pracownik";
            const int companyEstablishmentYear = 1970;
            var employeeDateOfBirth = DateTime.UtcNow.Date.AddYears(-65);

            var companies = Enumerable.Range(1, 40).Select(n => new Company
            {
                Name = companyName + n,
                EstablishmentYear = companyEstablishmentYear + n,
                Employees = new[]
                {
                    new Employee 
                    { 
                        DateOfBirth = employeeDateOfBirth.AddYears(n),
                        FirstName = employeeName + n,
                        LastName = employeeName + n + n,
                        JobTitle = JobTitle.Administrator
                    },
                    new Employee
                    {
                        DateOfBirth = employeeDateOfBirth.AddYears(n + 1),
                        FirstName = employeeName + n + 1,
                        LastName = employeeName + n + n + 1,
                        JobTitle = JobTitle.Architect
                    },
                    new Employee
                    {
                        DateOfBirth = employeeDateOfBirth.AddYears(n + 2),
                        FirstName = employeeName + n + 2,
                        LastName = employeeName + n + n + 2,
                        JobTitle = JobTitle.Developer
                    },
                    new Employee
                    {
                        DateOfBirth = employeeDateOfBirth.AddYears(n + 3),
                        FirstName = employeeName + n + 3,
                        LastName = employeeName + n + n + 3,
                        JobTitle = JobTitle.Manager
                    }
                }
            });

            companies.ForEach(x => context.Set<Company>().AddOrUpdate(c => c.Name, x));

            context.SaveChangesWithModificationHistory();
        }

        private void CreateRole(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (!roleManager.RoleExists(roleName))
            {
                var role = new IdentityRole
                {
                    Name = roleName
                };

                roleManager.Create(role);
            }
        }

        private void SeedRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            CreateRole(roleManager, "Klient");

            roleManager.Dispose();
        }

        private void CreateUser(UserManager<ApplicationUser> manager,
           string userName,
           string password,
           string roleName)
        {
            if (!context.Users.Any(u => u.UserName == userName))
            {
                var applicationUser = new ApplicationUser
                {
                    UserName = userName,
                    Email = userName,
                    EmailConfirmed = true
                };

                var userResult = manager.Create(applicationUser, password);

                if (userResult.Succeeded)
                {
                    manager.AddToRole(applicationUser.Id, roleName);
                }
            }
        }

        private void SeedUsers()
        {
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);

            CreateUser(manager, "klient@gmail.com", "hasloos@1Z", "Klient");

            CreateUser(manager, "klient2@gmail.com", "hasloos@1Z2", "Klient");

            CreateUser(manager, "klient3@gmail.com", "hasloos@1Z3", "Klient");


            manager.Dispose();

            store.Dispose();
        }
    }
}
