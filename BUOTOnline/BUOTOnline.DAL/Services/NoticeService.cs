using BUOTOnline.DAL.IServices;
using BUOTOnline.DAL.ViewModels;
using System;
using System.Collections.Generic;

namespace BUOTOnline.DAL.Services
{
    class NoticeService : INoticeService
    {
        public IEnumerable<NoticeViewModel> GetNotices()
        {
            return new List<NoticeViewModel>
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
        }
    }
}
