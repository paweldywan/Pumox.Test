using Newtonsoft.Json;
using PDCore.Interfaces;
using System;

namespace Pumox.Test.BLL.Models
{
    public class Company : CompanyBrief, IModificationHistory, IEntity<long>
    {
        [JsonIgnore]
        public long Id { get; set; }


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
