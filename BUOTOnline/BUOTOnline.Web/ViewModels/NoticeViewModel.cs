using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BUOTOnline.Web.ViewModels
{
    public enum Category
    {
        Motoryzacja,
        Praca,
        Nieruchomości
    }

    public class NoticeViewModel
    {
        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; } 

        [Required]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "Opis musi mieć minimum 10 znaków!")]
        public string Description { get; set; }

        public DateTime Created { get; private set; } = DateTime.Now;

        public Category Cat { get; set; }

        //public NoticeViewModel(string title, string description)
        //{
        //    Title = title;
        //    Description = description;
        //    Created = DateTime.Now;
        //}
    }
}