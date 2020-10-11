using AutoMapper;
using PDCore.Interfaces;
using PDCoreNew.Context.IContext;
using PDCoreNew.Repositories.Repo;
using Pumox.Test.BLL.Models;
using Pumox.Test.DAL.Contracts;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Pumox.Test.DAL.Repositories
{
    public class CompanyRepository : SqlRepositoryEntityFrameworkDisconnected<Company>, ICompanyRepository
    {
        public CompanyRepository(IEntityFrameworkDbContext ctx, ILogger logger, IMapper mapper) : base(ctx, logger, mapper)
        {
        }
    }
}
