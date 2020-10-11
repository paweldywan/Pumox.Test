using PDCore.Repositories.IRepo;
using PDCoreNew.Context.IContext;
using PDCoreNew.Factories.Fac.Repository;
using PDCoreNew.UnitOfWork;
using Pumox.Test.BLL.Models;
using Pumox.Test.DAL.Contracts;

namespace Pumox.Test.DAL
{
    public class PumoxTestUow : UnitOfWork, IPumoxTestUow
    {
        public PumoxTestUow(IRepositoryProvider repositoryProvider, IEntityFrameworkDbContext dbContext) : base(repositoryProvider, dbContext)
        {
        }

        public ISqlRepositoryEntityFrameworkDisconnected<Company> Companies { get { return GetStandardRepoDisconnected<Company>(); } }
    }
}
