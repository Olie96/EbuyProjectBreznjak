using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebuy.DAL;
using Ebuy.Model.Common;

namespace Ebuy.Model
{
    public class Carts : ICart
    {
        public int CartId { get; set; } // CartId (Primary key)
        public int? UserId { get; set; } // UserId

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<IBooks> Books { get; set; } // Book.FK_Book_Cart
        public virtual System.Collections.Generic.ICollection<ICars> Cars { get; set; } // Car.FK_Car_Cart
        public virtual System.Collections.Generic.ICollection<IElectronics> Electronics { get; set; } // Electronic.FK_Electronic_Cart
        public virtual System.Collections.Generic.ICollection<IMusic> Musics { get; set; } // Music.FK_Music_Cart
        public virtual System.Collections.Generic.ICollection<ISport> Sports { get; set; } // Sport.FK_Sport_Cart
    }
}
