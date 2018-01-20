using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BUOTOnline.DAL.ViewModels
{
    [JsonObject(NamingStrategyType = typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public class CategoryViewModel
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public string AttributeIds { get; set; }
        public IEnumerable<CategoryViewModel> Parents { get; set; }
        public IEnumerable<AttributeViewModel> Attributes { get; set; }
    }
}