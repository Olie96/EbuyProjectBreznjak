using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebuy.DAL;

namespace Ebuy.Model.Common
{
     public interface IBooks
    {
         int BookId { get; set; } // BookId (Primary key)
         string BookName { get; set; } // BookName (length: 50)
         string BookAuthorName { get; set; } // BookAuthorName (length: 50)
         string BookAuthorSurname { get; set; } // BookAuthorSurname (length: 50)
         string BookIsbn { get; set; } // BookISBN (length: 50)
         string BookGenre { get; set; } // BookGenre (length: 50)
         string BookDescription { get; set; } // BookDescription
         int? BookPrice { get; set; } // BookPrice
         int? CartId { get; set; } // CartId

        //Foreign keys
         Cart Cart { get; set; } // FK_Book_Cart
    }
}
