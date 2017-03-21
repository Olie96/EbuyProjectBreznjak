using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebuy.Model.Common
{
    public interface IUser
    {
        int UserId { get; set; } // UserId (Primary key)
        string FirstName { get; set; } // FirstName (length: 50)
        string LastName { get; set; } // LastName (length: 50)
        string Adress { get; set; } // Adress (length: 50)
        string Email { get; set; } // Email (length: 50)
        string Password { get; set; } // Password (length: 50)
    }
}
