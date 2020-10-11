using PDCore.Strategies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pumox.Test.DAL.Strategies
{
    public class PumoxTestDataAccessStrategy<TEntity> : DataAccessStrategy<TEntity>
    {
        public override bool CanUpdateAllProperties(TEntity entity) => true;

        public override bool CanDelete(TEntity entity) => true;

        public override Task AfterAdd(params object[] args) => Task.CompletedTask;

        public override Task<bool> CanAdd(params object[] args) => Task.FromResult(true);

        public override void PrepareForAdd(params object[] args) { }

        public override bool CanUpdate(TEntity entity) => true;

        public override ICollection<string> GetPropertiesForUpdate(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
