using PDCore.Interfaces;
using PDCore.Repositories.IRepo;
using Pumox.Test.BLL.Models;

namespace Pumox.Test.DAL.Contracts
{
    /// <summary>
    /// Interface for the Pumox Test "Unit of Work"
    /// </summary>
    public interface IPumoxTestUow : IUnitOfWork
    {
        // Repositories
        ISqlRepositoryEntityFrameworkDisconnected<Company> Companies { get; }
    }
}
