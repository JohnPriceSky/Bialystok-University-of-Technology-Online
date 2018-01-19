using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BUOTOnline.DAL.ViewModels
{
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