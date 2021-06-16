using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Models
{
    public class BookForCreationDto: BookManipulationDto
    {
        public int MaxBooksAllowed { get; set; }

        public int NumberBooksRegistered { get; set; }
    }
}
