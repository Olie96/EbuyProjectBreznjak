using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ebuy.Model.Common;

namespace EbuyProject.ViewModels
{
    public class SportViewModel
    {
        public int SportItemId { get; set; } // SportItemId (Primary key)
        public string SportItemName { get; set; } // SportItemName (length: 50)
        public string SportItemDescription { get; set; } // SportItemDescription (length: 50)
        public int? SportItemPrice { get; set; } // SportItemPrice
        public int? CartId { get; set; } // CartId

        // Foreign keys
        public virtual ICart Cart { get; set; } // FK_Sport_Cart
    }
}