using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Pumox.Test.DAL;
using Pumox.Test.DAL.Entities;

namespace Pumox.Test.Web
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public static ApplicationUserManager Create(PumoxTestContext context)
        {
            return new ApplicationUserManager(new UserStore<ApplicationUser>(context));
        }

        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
            // Configure validation logic for usernames
            UserValidator = new UserValidator<ApplicationUser>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
        }
    }
}
