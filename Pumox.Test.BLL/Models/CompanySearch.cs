using Newtonsoft.Json;
using PDCore.Converters;
using Pumox.Test.BLL.Enums;
using System;

namespace Pumox.Test.BLL.Models
{
    public class CompanySearch
    {
        public string Keyword { get; set; }

        [JsonConverter(typeof(FormattedDateTimeConverter))]
        public DateTime? EmployeeDateOfBirthFrom { get; set; }

        [JsonConverter(typeof(FormattedDateTimeConverter))]
        public DateTime? EmployeeDateOfBirthTo { get; set; }

        public JobTitle[] EmployeeJobTitles { get; set; }
    }
}
