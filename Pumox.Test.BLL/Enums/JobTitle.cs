using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pumox.Test.BLL.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum JobTitle
    {
        Administrator, 

        Developer, 

        Architect, 

        Manager
    }
}
