using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebuy.DAL;
using Ebuy.Model.Common;
using System.Data.Entity;

namespace Ebuy.Model
{
    public class Cars : ICars
    {
        public int CarId { get; set; } // CarId (Primary key)
        public string CarMaker { get; set; } // CarMaker (length: 50)
        public string CarModel { get; set; } // CarModel (length: 50)
        public int? CarYearOfProduction { get; set; } // CarYearOfProduction
        public int? CarKilometers { get; set; } // CarKilometers
        public int? CarPrice { get; set; } // CarPrice
        public string CarDescription { get; set; } // CarDescription
        public int? CartId { get; set; } // CartId

        // Foreign keys
        public virtual Cart Cart { get; set; } // FK_Car_Cart
    }
}
