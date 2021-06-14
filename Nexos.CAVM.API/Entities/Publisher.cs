using System.Collections.Generic;

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
        public string PublisherName { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string PublisherEmail { get; set; }

        public int MaxNumberBook { get; set; }

        public List<Book> Books { get; set; }
    }
}