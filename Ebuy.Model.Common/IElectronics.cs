using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebuy.DAL;

namespace Ebuy.Model.Common
{
    public interface IElectronics
    {
         int ElectronicPartId { get; set; } // ElectronicPartId (Primary key)
         string ElectronicPartName { get; set; } // ElectronicPartName (length: 50)
         string ElectronicPartDescription { get; set; } // ElectronicPartDescription
         int? ElectronicPartPrice { get; set; } // ElectronicPartPrice
         int? CartId { get; set; } // CartId

        // Foreign keys
        Cart Cart { get; set; } // FK_Electronic_Cart
    }
}
