using Newtonsoft.Json;

namespace QA.Framework.Base
{
    class Settings
    {
        [JsonProperty(PropertyName = "BaseURL")]
        public static string BaseURL { get; set; }
        [JsonProperty(PropertyName = "ExtendReportPath")]
        public static string ExtendReportPath { get; set; }
        [JsonProperty(PropertyName = "ConfigPath")]
        public static string ConfigPath { get; set; }
    }
}
