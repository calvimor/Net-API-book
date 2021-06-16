using Nexos.CAVM.API.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Models
{
    [ValidateMaximunBooksAllowed(
          ErrorMessage = "¡No es posible registrar el libro, se alcanzó el máximo permitido!")]
    public abstract class BookManipulationDto
    {
        [Required(ErrorMessage = "You should fill out a title.")]
        [MaxLength(350, ErrorMessage = "The title shouldn't have more than 350 characters.")]
        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        [Required(ErrorMessage = "You should fill out a number of pages.")]
        public int NumberPages { get; set; }

        [Required(ErrorMessage = "You should fill out an author.")]
        public Guid AuthorId { get; set; }

        [Required(ErrorMessage = "You should fill out a publisher.")]
        public Guid PublisherId { get; set; }

        
    }
}
