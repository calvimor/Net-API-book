using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Models
{
    public class PublisherForCreationDto
    {
        public string PublisherName { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        [RegularExpression("^(.+)@(.+)$")]
        public string PublisherEmail { get; set; }

        public int MaxNumberBook { get; set; }
    }
}
