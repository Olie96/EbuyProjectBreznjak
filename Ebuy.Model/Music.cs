using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebuy.DAL;
using Ebuy.Model.Common;

namespace Ebuy.Model
{
    public class Music : IMusic
    {
        public int MusicPartId { get; set; } // MusicPartId (Primary key)
        public string MusicPartName { get; set; } // MusicPartName (length: 50)
        public string MusicPartDescription { get; set; } // MusicPartDescription
        public int? MusicPartPrice { get; set; } // MusicPartPrice
        public int? CartId { get; set; } // CartId

        // Foreign keys
        public virtual Cart Cart { get; set; } // FK_Music_Cart
    }
}
