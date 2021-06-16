using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Models
{
    public class BookDto
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public int NumberPages { get; set; }
                
        public string Author { get; set; }
                
        public string Publisher { get; set; }
    }
}
