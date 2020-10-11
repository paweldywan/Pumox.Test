using PDCore.Repositories.IRepo;
using Pumox.Test.BLL.Entities.DTO;
using Pumox.Test.BLL.Models;
using Pumox.Test.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pumox.Test.DAL.Contracts
{
    public interface ICompanyRepository : ISqlRepositoryEntityFrameworkDisconnected<Company>
    {
        Task<List<CompanyDTO>> GetDTO(CompanySearch companySearch);
    }
}
