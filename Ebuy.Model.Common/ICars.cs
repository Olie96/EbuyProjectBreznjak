using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebuy.DAL;
using System.Data.Entity;

namespace Ebuy.Model.Common
{
    public interface ICars
    {
         int CarId { get; set; } // CarId (Primary key)
         string CarMaker { get; set; } // CarMaker (length: 50)
         string CarModel { get; set; } // CarModel (length: 50)
         int? CarYearOfProduction { get; set; } // CarYearOfProduction
         int? CarKilometers { get; set; } // CarKilometers
         int? CarPrice { get; set; } // CarPrice
         string CarDescription { get; set; } // CarDescription
         int? CartId { get; set; } // CartId

        // Foreign keys
        Cart Cart { get; set; } // FK_Car_Cart
    }
}
