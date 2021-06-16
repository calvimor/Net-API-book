using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Models
{
    public class AuthorForCreationDto
    {
        [Required(ErrorMessage = "You should fill out an author name.")]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string CityFrom { get; set; }

        public string Email { get; set; }
    }
}
