using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ebuy.Model.Common;

namespace EbuyProject.ViewModels
{
    public class MusicViewModel
    {
        public int MusicPartId { get; set; } // MusicPartId (Primary key)
        public string MusicPartName { get; set; } // MusicPartName (length: 50)
        public string MusicPartDescription { get; set; } // MusicPartDescription
        public int? MusicPartPrice { get; set; } // MusicPartPrice
        public int? CartId { get; set; } // CartId

        // Foreign keys
        public virtual ICart Cart { get; set; } // FK_Music_Cart
    }
}