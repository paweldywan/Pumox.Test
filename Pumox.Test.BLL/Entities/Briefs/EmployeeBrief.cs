using Newtonsoft.Json;
using PDCore.Converters;
using Pumox.Test.BLL.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pumox.Test.BLL.Entities.Briefs
{
    public class EmployeeBrief
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        public string FirstName { get; set; }


        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.ErrorMessages))]
        public string LastName { get; set; }

        [JsonConverter(typeof(FormattedDateTimeConverter))]
        public DateTime DateOfBirth { get; set; }

        public JobTitle JobTitle { get; set; }
    }
}
