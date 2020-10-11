using System.Data.Entity;
using PDCoreNew.Configuration.DbConfiguration.Interceptors;

namespace Pumox.Test.DAL.Configuration
{
    internal class PumoxTestDbConfiguration : DbConfiguration
    {
        protected internal PumoxTestDbConfiguration()
        {
            AddInterceptor(new UtcInterceptor());
        }
    }
}
