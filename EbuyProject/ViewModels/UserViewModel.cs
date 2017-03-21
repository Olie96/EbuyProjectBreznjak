using Ebuy.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EbuyProject.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; } // UserId (Primary key)
        public string FirstName { get; set; } // FirstName (length: 50)
        public string LastName { get; set; } // LastName (length: 50)
        public string Adress { get; set; } // Adress (length: 50)
        public string Email { get; set; } // Email (length: 50)
        public string Password { get; set; } // Password (length: 50)
    }
}