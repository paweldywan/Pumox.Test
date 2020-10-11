using Newtonsoft.Json;
using PDCore.Interfaces;
using Pumox.Test.BLL.Enums;
using System;

namespace Pumox.Test.BLL.Models
{
    public class Employee : IModificationHistory
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public JobTitle JobTitle { get; set; }

        public long CompanyId { get; set; }

        public virtual Company Company { get; set; }


        #region ModificationHistory

        [JsonIgnore]
        public DateTime DateCreated { get; set; }

        [JsonIgnore]
        public DateTime DateModified { get; set; }

        [JsonIgnore]
        public byte[] RowVersion { get; set; }

        [JsonIgnore]
        public bool IsDirty { get; set; }

        #endregion
    }
}
