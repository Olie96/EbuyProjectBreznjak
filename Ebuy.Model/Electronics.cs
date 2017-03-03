using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebuy.DAL;
using Ebuy.Model.Common;

namespace Ebuy.Model
{
    public class Electronics : IElectronics
    {
        public int ElectronicPartId { get; set; } // ElectronicPartId (Primary key)
        public string ElectronicPartName { get; set; } // ElectronicPartName (length: 50)
        public string ElectronicPartDescription { get; set; } // ElectronicPartDescription
        public int? ElectronicPartPrice { get; set; } // ElectronicPartPrice
        public int? CartId { get; set; } // CartId

        // Foreign keys
        public virtual Cart Cart { get; set; } // FK_Electronic_Cart
    }
}
