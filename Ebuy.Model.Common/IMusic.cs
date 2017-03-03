using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebuy.DAL;

namespace Ebuy.Model.Common
{
    public interface IMusic
    {
         int MusicPartId { get; set; } // MusicPartId (Primary key)
         string MusicPartName { get; set; } // MusicPartName (length: 50)
         string MusicPartDescription { get; set; } // MusicPartDescription
         int? MusicPartPrice { get; set; } // MusicPartPrice
         int? CartId { get; set; } // CartId

        // Foreign keys
        Cart Cart { get; set; } // FK_Music_Cart
    }
}
