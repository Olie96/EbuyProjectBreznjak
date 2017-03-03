using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebuy.DAL;
using Ebuy.Model.Common;

namespace Ebuy.Model
{
    public class Sport : ISport
    {
        public int SportItemId { get; set; } // SportItemId (Primary key)
        public string SportItemName { get; set; } // SportItemName (length: 50)
        public string SportItemDescription { get; set; } // SportItemDescription (length: 50)
        public int? SportItemPrice { get; set; } // SportItemPrice
        public int? CartId { get; set; } // CartId

        // Foreign keys
        public virtual Cart Cart { get; set; } // FK_Sport_Cart
    }
}
