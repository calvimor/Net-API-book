using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Entities
{
    //Registrar los datos de un libro: 
    //Titulo, Año, Genero, Número de páginas, Editorial, Autor.
    public class Book: BaseEntity
    {
        [Required]
        [MaxLength(350)]
        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public int NumberPages { get; set; }

        public Guid AuthorId { get; set; }

        public Author Author { get; set; }

        public Guid PublisherId { get; set; }

        public Publisher Publisher { get; set; }

    }
}
