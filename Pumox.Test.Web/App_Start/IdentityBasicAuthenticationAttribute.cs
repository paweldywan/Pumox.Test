using PDWebCore.Attributes.Authentication;
using Pumox.Test.DAL;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace Pumox.Test.Web
{
    public class IdentityBasicAuthenticationAttribute : BasicAuthenticationAttribute
    {
        public IdentityBasicAuthenticationAttribute(bool enabled = true) : base(enabled)
        {
        }

        protected override async Task<IPrincipal> AuthenticateAsync(string userName, string password, CancellationToken cancellationToken)
        {
            IPrincipal result = null;

            using (var db = new PumoxTestContext())
            {
                using (var userManager = ApplicationUserManager.Create(db))
                {
                    cancellationToken.ThrowIfCancellationRequested(); // Unfortunately, UserManager doesn't support CancellationTokens.

                    var user = await userManager.FindAsync(userName, password);

                    if (user != null)
                    {
                        // Create a ClaimsIdentity with all the claims for this user.
                        cancellationToken.ThrowIfCancellationRequested(); // Unfortunately, IClaimsIdenityFactory doesn't support CancellationTokens.

                        ClaimsIdentity identity = await user.GenerateUserIdentityAsync(userManager);

                        result = new ClaimsPrincipal(identity);
                    }
                }
            }

            return result;
        }
    }
}
