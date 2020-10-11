using PDCoreNew.Context.IContext;
using PDCoreNew.Factories.Fac.Repository;
using PDCoreNew.UnitOfWork;
using Pumox.Test.DAL.Contracts;
using Pumox.Test.DAL.Repositories;

namespace Pumox.Test.DAL
{
    public class PumoxTestUow : UnitOfWork, IPumoxTestUow
    {
        public PumoxTestUow(IRepositoryProvider repositoryProvider, IEntityFrameworkDbContext dbContext) : base(repositoryProvider, dbContext)
        {
        }

        public ICompanyRepository Companies { get { return GetRepo<CompanyRepository>(); } }
    }
}
