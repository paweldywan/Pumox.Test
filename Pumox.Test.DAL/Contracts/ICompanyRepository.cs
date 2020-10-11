using PDCore.Repositories.IRepo;
using Pumox.Test.BLL.Models;

namespace Pumox.Test.DAL.Contracts
{
    public interface ICompanyRepository : ISqlRepositoryEntityFrameworkDisconnected<Company>
    {
        
    }
}
