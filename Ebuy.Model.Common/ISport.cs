using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebuy.DAL;

namespace Ebuy.Model.Common
{
    public interface ISport
    {
         int SportItemId { get; set; } // SportItemId (Primary key)
         string SportItemName { get; set; } // SportItemName (length: 50)
         string SportItemDescription { get; set; } // SportItemDescription (length: 50)
         int? SportItemPrice { get; set; } // SportItemPrice
         int? CartId { get; set; } // CartId

        // Foreign keys
        Cart Cart { get; set; } // FK_Sport_Cart
    }
}
