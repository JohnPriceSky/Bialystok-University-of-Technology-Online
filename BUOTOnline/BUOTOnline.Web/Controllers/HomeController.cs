using BUOTOnline.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BUOTOnline.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var notices = new List<NoticeViewModel>
            {
               new NoticeViewModel
               {
                   Title = "Opel Astra H",
                   Description = "Do zaoferowania Opel Astra 2.0 Turbo z manualną 6 biegową skrzynią. Auto sprowadzone z Niemiec po opłatach, przygotowane do rejestracji (koszt 256zł). Samochód zadbany zarówno od strony technicznej jak i wizualnej. Dodatkowo wyposażony w kompletny sportowy układ wydechowy Freddrich motorsport Master of sound 2,5 cala, przyjemny nieuciążliwy dźwięk. Auto w pełni sprawne. Możliwy powrót na kołach ",
                   Created = DateTime.Now.AddMonths(1)
               },

               new NoticeViewModel
               {
                   Title = "Opel Astra H",
                   Description = "Do zaoferowania Opel Astra 2.0 Turbo z manualną 6 biegową skrzynią. Auto sprowadzone z Niemiec po opłatach, przygotowane do rejestracji (koszt 256zł). Samochód zadbany zarówno od strony technicznej jak i wizualnej. Dodatkowo wyposażony w kompletny sportowy układ wydechowy Freddrich motorsport Master of sound 2,5 cala, przyjemny nieuciążliwy dźwięk. Auto w pełni sprawne. Możliwy powrót na kołach ",
                   Created = DateTime.Now.AddMonths(2)
               },
               new NoticeViewModel
               {
                   Title = "Opel Astra H",
                   Description = "Do zaoferowania Opel Astra 2.0 Turbo z manualną 6 biegową skrzynią. Auto sprowadzone z Niemiec po opłatach, przygotowane do rejestracji (koszt 256zł). Samochód zadbany zarówno od strony technicznej jak i wizualnej. Dodatkowo wyposażony w kompletny sportowy układ wydechowy Freddrich motorsport Master of sound 2,5 cala, przyjemny nieuciążliwy dźwięk. Auto w pełni sprawne. Możliwy powrót na kołach ",
                   Created = DateTime.Now.AddMonths(2)
               },
               new NoticeViewModel
               {
                   Title = "Opel Astra H",
                   Description = "Do zaoferowania Opel Astra 2.0 Turbo z manualną 6 biegową skrzynią. Auto sprowadzone z Niemiec po opłatach, przygotowane do rejestracji (koszt 256zł). Samochód zadbany zarówno od strony technicznej jak i wizualnej. Dodatkowo wyposażony w kompletny sportowy układ wydechowy Freddrich motorsport Master of sound 2,5 cala, przyjemny nieuciążliwy dźwięk. Auto w pełni sprawne. Możliwy powrót na kołach ",
                   Created = DateTime.Now.AddMonths(2)
               },
               new NoticeViewModel
               {
                   Title = "Opel Astra H",
                   Description = "Do zaoferowania Opel Astra 2.0 Turbo z manualną 6 biegową skrzynią. Auto sprowadzone z Niemiec po opłatach, przygotowane do rejestracji (koszt 256zł). Samochód zadbany zarówno od strony technicznej jak i wizualnej. Dodatkowo wyposażony w kompletny sportowy układ wydechowy Freddrich motorsport Master of sound 2,5 cala, przyjemny nieuciążliwy dźwięk. Auto w pełni sprawne. Możliwy powrót na kołach ",
                   Created = DateTime.Now.AddMonths(2)
               }
            };

            return View(notices);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}