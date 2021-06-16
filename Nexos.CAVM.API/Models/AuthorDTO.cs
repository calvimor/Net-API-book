using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Models
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime Birthday { get; set; }
                
        public string CityFrom { get; set; }
                
        public string Email { get; set; }
        public List<BookDto> Books { get; set; }
    }
}
