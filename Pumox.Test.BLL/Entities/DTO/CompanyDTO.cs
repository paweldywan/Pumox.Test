using Newtonsoft.Json;
using Pumox.Test.BLL.Entities.Briefs;
using Pumox.Test.Entities.Briefs;
using System.Collections.Generic;

namespace Pumox.Test.BLL.Entities.DTO
{
    public class CompanyDTO : CompanyBrief
    {
        [JsonProperty(Order = 5)]
        public virtual ICollection<EmployeeBrief> Employees { get; set; }
    }
}
