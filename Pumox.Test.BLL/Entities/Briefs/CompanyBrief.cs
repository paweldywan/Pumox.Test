using Newtonsoft.Json;
using PDCore.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Pumox.Test.Entities.Briefs
{
    public class CompanyBrief : IHasRowVersion
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        public int EstablishmentYear { get; set; }


        [JsonIgnore]
        public byte[] RowVersion { get; set; }
    }
}
