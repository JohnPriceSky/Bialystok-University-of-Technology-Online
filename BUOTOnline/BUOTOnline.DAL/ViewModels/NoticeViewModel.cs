using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BUOTOnline.DAL.ViewModels
{
    [JsonObject(NamingStrategyType = typeof(Newtonsoft.Json.Serialization.CamelCaseNamingStrategy))]
    public class NoticeViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Notice image url")]
        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "Too short!")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public DateTime Created { get; set; }
        public string CategoriesIds { get; set; }
        public string Content { get; set; }

        public string Owner { get; set; }

        public long CurrentCategoryId { get; set; }
    }
}