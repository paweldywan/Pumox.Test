using PDWebCore.Helpers.MultiLanguage;
using System.Web.Http;

namespace Pumox.Test.Web.Controllers
{
    [Authorize]
    [IdentityBasicAuthentication]
    public class OperationsController : ApiController
    {
        [HttpOptions]
        [ActionName("SetLanguage")]
        public IHttpActionResult SetLanguage(string lang)
        {
            LanguageHelper.SetLanguage(lang);

            return Ok();
        }
    }
}
