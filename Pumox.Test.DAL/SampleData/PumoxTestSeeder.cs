using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Pumox.Test.DAL.Entities;
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
