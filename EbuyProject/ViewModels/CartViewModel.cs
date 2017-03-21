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
        public int CartId { get; set; } // CartId (Primary key)
        public int? UserId { get; set; } // UserId

        //Reverse navigation
        public System.Collections.Generic.ICollection<BookViewModel> Books { get; set; } // Book.FK_Book_Cart
        public System.Collections.Generic.ICollection<CarViewModel> Cars { get; set; } // Car.FK_Car_Cart
        public System.Collections.Generic.ICollection<ElectronicsViewModel> Electronics { get; set; } // Electronic.FK_Electronic_Cart
        public System.Collections.Generic.ICollection<MusicViewModel> Musics { get; set; } // Music.FK_Music_Cart
        public System.Collections.Generic.ICollection<SportViewModel> Sports { get; set; } // Sport.FK_Sport_Cart

    }
}