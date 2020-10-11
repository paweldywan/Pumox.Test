using Newtonsoft.Json;
using PDCore.Interfaces;
using Pumox.Test.Entities.Briefs;
using System;
using System.Collections.Generic;

namespace Pumox.Test.DAL.Entities
{
    public class Company : CompanyBrief, IModificationHistory, IEntity<long>
    {
        [JsonIgnore]
        public long Id { get; set; }


        #region Proxies

        public virtual ICollection<Employee> Employees { get; set; }

        #endregion


        #region ModificationHistory

        [JsonIgnore]
        public DateTime DateCreated { get; set; }

        [JsonIgnore]
        public DateTime DateModified { get; set; }

        [JsonIgnore]
        public bool IsDirty { get; set; }

        #endregion
    }
}
