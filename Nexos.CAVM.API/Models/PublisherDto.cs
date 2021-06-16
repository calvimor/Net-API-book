using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Models
{
    public class PublisherDto
    {
        public Guid Id { get; set; }
        public string PublisherName { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string PublisherEmail { get; set; }

        public int MaxNumberBook { get; set; }
    }
}
