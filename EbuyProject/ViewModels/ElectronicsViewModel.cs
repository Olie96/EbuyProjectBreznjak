using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ebuy.Model.Common;

namespace EbuyProject.ViewModels
{
    public class ElectronicsViewModel
    {
        public int ElectronicPartId { get; set; } // ElectronicPartId (Primary key)
        public string ElectronicPartName { get; set; } // ElectronicPartName (length: 50)
        public string ElectronicPartDescription { get; set; } // ElectronicPartDescription
        public int? ElectronicPartPrice { get; set; } // ElectronicPartPrice
       public int? CartId { get; set; } // CartId

        // Foreign keys
        public virtual ICart Cart { get; set; } // FK_Electronic_Cart
    }
}