using Newtonsoft.Json;
using PDCore.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pumox.Test.BLL.Models
{
    public class CompanyBrief : IHasRowVersion
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        public int EstablishmentYear { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }


        [JsonIgnore]
        public byte[] RowVersion { get; set; }
    }
}
