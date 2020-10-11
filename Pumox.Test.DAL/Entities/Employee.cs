using PDCore.Interfaces;
using Pumox.Test.BLL.Entities.Briefs;
using System;

namespace Pumox.Test.DAL.Entities
{
    public class Employee : EmployeeBrief, IModificationHistory
    {
        public long Id { get; set; }

        public long CompanyId { get; set; }


        #region Proxies

        public virtual Company Company { get; set; }

        #endregion


        #region ModificationHistory

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public byte[] RowVersion { get; set; }

        public bool IsDirty { get; set; }

        #endregion
    }
}
