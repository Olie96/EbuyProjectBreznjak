using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebuy.DAL;
using Ebuy.Model.Common;

namespace Ebuy.Model
{
    public class Books : IBooks
    {
        public int BookId { get; set; } // BookId (Primary key)
        public string BookName { get; set; } // BookName (length: 50)
        public string BookAuthorName { get; set; } // BookAuthorName (length: 50)
        public string BookAuthorSurname { get; set; } // BookAuthorSurname (length: 50)
        public string BookIsbn { get; set; } // BookISBN (length: 50)
        public string BookGenre { get; set; } // BookGenre (length: 50)
        public string BookDescription { get; set; } // BookDescription
        public int? BookPrice { get; set; } // BookPrice
        public int? CartId { get; set; } // CartId

        // Foreign keys
        public virtual Cart Cart { get; set; } // FK_Book_Cart
    }
}
