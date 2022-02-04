using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.DTOs.DTOs
{
    public class AutorDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CiudadProcedencia { get; set; }
        public string Email { get; set; }

        //public virtual ICollection<LibroDto> Libros { get; set; }
    }
}
