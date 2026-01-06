using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dars2_1
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
    }
}
