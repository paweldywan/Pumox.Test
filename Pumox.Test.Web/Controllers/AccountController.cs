using Microsoft.AspNet.Identity;
using Pumox.Test.BLL.Translators;
using Pumox.Test.DAL.Entities;
using Pumox.Test.Web.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace Pumox.Test.Web.Controllers
{
    [IdentityBasicAuthentication]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly ApplicationUserManager userManager;
        private readonly PumoxTestTranslator pumoxTestTranslator;

        public AccountController(ApplicationUserManager userManager, PumoxTestTranslator pumoxTestTranslator)
        {
            this.userManager = userManager;
            this.pumoxTestTranslator = pumoxTestTranslator;
        }

        [Route]
        public string Get()
        {
            return "aaa";
        }

        // POST api/Account/Register
        [IdentityBasicAuthentication(false)]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        {
            var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };

            IdentityResult result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/Account/ChangePassword
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            IdentityResult result = await userManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }


        #region Helpers

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", pumoxTestTranslator.TranslateText(error));
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        #endregion
    }
}
