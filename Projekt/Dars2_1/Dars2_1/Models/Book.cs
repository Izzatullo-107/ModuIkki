using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars2_1.Models
{
    public class Book
    {
        // BookID kitob identifikatori
        public Guid BookId { get; set; }

        // Title kitob nomi
        public string Title { get; set; }

        // Author kitob muallifi
        public string Author { get; set; }

        // Price kitob narxi
        public decimal Price { get; set; }

        // Description kitob ta'rifi
        public string Description { get; set; }

        // Created kitob qo'shilgan sana
        public DateTime Created { get; set; }

        // Genre kitob janri
        public string Genre { get; set; }

        // PageCount kitob sahifa soni
        public int PageCount { get; set; }
    }
}
