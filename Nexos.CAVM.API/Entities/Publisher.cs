using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nexos.CAVM.API.Entities
{
    /*
     * Registrar los datos de las editoriales:
     * Nombre,
     * Dirección de Correspondencia,
     * Teléfono,
     * Correo electrónico, 
     * Máximo de libros registrados.
     * 
     */
    public class Publisher: BaseEntity
    {
        [Required]
        [MaxLength(350)]
        public string PublisherName { get; set; }

        [Required]
        [MaxLength(350)]
        public string Address { get; set; }

        public string Telephone { get; set; }

        
        [MaxLength(350)]
        public string PublisherEmail { get; set; }

        public int MaxNumberBook { get; set; }

        public List<Book> Books { get; set; }        
    }
}