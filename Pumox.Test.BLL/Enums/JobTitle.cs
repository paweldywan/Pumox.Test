using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pumox.Test.BLL.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum JobTitle
    {
        Administrator = 1, 

        Developer, 

        Architect, 

        Manager
    }
}
