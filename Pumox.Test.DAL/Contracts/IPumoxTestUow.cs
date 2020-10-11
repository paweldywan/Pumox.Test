using PDCore.Interfaces;

namespace Pumox.Test.DAL.Contracts
{
    /// <summary>
    /// Interface for the Pumox Test "Unit of Work"
    /// </summary>
    public interface IPumoxTestUow : IUnitOfWork
    {
        // Repositories
        ICompanyRepository Companies { get; }
    }
}
