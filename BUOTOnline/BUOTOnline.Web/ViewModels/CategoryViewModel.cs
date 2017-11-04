using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BUOTOnline.Web.ViewModels
{
    public class CategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ParentId { get; set; }
        public IEnumerable<AttributeViewModel> Attributes { get; set; }
    }
}