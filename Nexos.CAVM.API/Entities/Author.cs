using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nexos.CAVM.API.Entities
{
    /*
     * Registrar los datos de los autores:
     * Nombre completo,
     * Fecha de nacimiento, 
     * Ciudad de procedencia,
     * Correo electrónico.
     */
    public class Author: BaseEntity
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        [MaxLength(150)]
        public string CityFrom { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        public List<Book> Books { get; set; }
    }
}