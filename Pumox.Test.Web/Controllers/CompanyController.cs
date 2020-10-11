using PDCore.Extensions;
using PDWebCore;
using Pumox.Test.BLL.Models;
using Pumox.Test.DAL.Contracts;
using System.Threading.Tasks;
using System.Web.Http;

namespace Pumox.Test.Web.Controllers
{
    [Authorize]
    [IdentityBasicAuthentication]
    public class CompanyController : ApiController
    {
        private readonly IPumoxTestUow pumoxTestUow;

        public CompanyController(IPumoxTestUow pumoxTestUow)
        {
            this.pumoxTestUow = pumoxTestUow;
        }

        [ActionName("create")]
        public async Task<IHttpActionResult> Post(Company model)
        {
            bool success = await pumoxTestUow.Companies.SaveNewAsync(model, User);

            if (success)
            {
                var info = model.GetEntityInfo();

                return Ok(info);
            }

            return this.Forbid();
        }

        [ActionName("update")]
        public async Task<IHttpActionResult> Put(long id, CompanyBrief model)
        {
            var company = await pumoxTestUow.Companies.FindByIdAsync(id, false);

            if (company == null)
            {
                return NotFound();
            }

            var result = await pumoxTestUow.Companies.SaveUpdatedWithOptimisticConcurrencyAsync<CompanyBrief>(model, company, User, ModelState.AddModelError);

            if (result != null)
            {
                return this.NoContent();
            }

            return BadRequest(ModelState);
        }

        [ActionName("delete")]
        public async Task<IHttpActionResult> Delete(long id)
        {
            var company = await pumoxTestUow.Companies.FindByIdAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            bool success = await pumoxTestUow.Companies.DeleteAndCommitWithOptimisticConcurrencyAsync(company, User, ModelState.AddModelError);

            if (success)
            {
                return this.NoContent();
            }

            return BadRequest(ModelState);
        }
    }
}
