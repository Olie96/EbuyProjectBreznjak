using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Ebuy.Model;
using Ebuy.Model.Common;

namespace EbuyProject.ViewModels
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public string UserName { get; set; } // UserName (length: 50)
        public string UserSurname { get; set; } // UserSurname (length: 50)
        public string UserAdress { get; set; } // UserAdress (length: 50)
        public string UserEmail { get; set; } // UserEmail (length: 50)

        public ICollection<BookViewModel> Books { get; set; }
        public ICollection<CarViewModel> Cars { get; set; }
        public ICollection<ElectronicsViewModel> Electronics { get; set; }
        public ICollection<MusicViewModel> Musics { get; set; }
        public ICollection<SportViewModel> Sports { get; set; }

    }
}