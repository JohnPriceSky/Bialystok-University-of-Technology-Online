using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BUOTOnline.DAL.ViewModels
{

    public class NoticeViewModel
    {
        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; } 

        [Required]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "Opis musi mieć minimum 10 znaków!")]
        public string Description { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
        public IEnumerable<CategoryViewModel> Categories { get; set; }

        //public int[] CategoryId { get; set; }
        //public MultiSelectList Categories { get; set; }

        //public NoticeViewModel()
        //{
        //    List<MultiSelectList> categories = new List<MultiSelectList>();
        //    Categories = new MultiSelectList(categories, "CategoryID", "CategoryName");
        //}

    }
}