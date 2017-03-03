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
        public int CartId { get; set; }
        public string UserName { get; set; } // UserName (length: 50)
        public string UserSurname { get; set; } // UserSurname (length: 50)
        public string UserAdress { get; set; } // UserAdress (length: 50)
        public string UserEmail { get; set; } // UserEmail (length: 50)
        public virtual ICollection<IBooks> Books { get; set; }
        public virtual ICollection<ICars> Cars { get; set; }
        public virtual ICollection<IElectronics> Electronics { get; set; }
        public virtual ICollection<IMusic> Musics { get; set; }
        public virtual ICollection<ISport> Sports { get; set; }
    }
}
