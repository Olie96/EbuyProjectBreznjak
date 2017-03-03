using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebuy.DAL;

namespace Ebuy.Model.Common
{
    public interface ICart
    {
        int CartId { get; set; }
        string UserName { get; set; } // UserName (length: 50)
        string UserSurname { get; set; } // UserSurname (length: 50)
        string UserAdress { get; set; } // UserAdress (length: 50)
        string UserEmail { get; set; } // UserEmail (length: 50)

        ICollection<IBooks> Books { get; set; }
        ICollection<ICars> Cars { get; set; }
        ICollection<IElectronics> Electronics { get; set; }
        ICollection<IMusic> Musics { get; set; }
        ICollection<ISport> Sports { get; set; }
    }
}
