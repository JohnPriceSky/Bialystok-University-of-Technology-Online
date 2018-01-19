using Newtonsoft.Json;

namespace BUOTOnline.DAL.ViewModels
{
    [JsonObject(NamingStrategyType = typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public class AttributeViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public AttributeType Type { get; set; }
    }
}