using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Entities.Entities
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Por falvor ingrese el nombre"), MaxLength(200, ErrorMessage = "El nombre debe tener maximo 200 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Por falvor ingrese la fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Por falvor ingrese la ciudad de procedencia"), MaxLength(200, ErrorMessage = "La ciudad debe de tener maximo 200 caracteres")]
        public string CiudadProcedencia { get; set; }
        [Required(ErrorMessage = "Por falvor ingrese el email"), MaxLength(200, ErrorMessage = "El email debe tener maximo 200 caracteres")]
        public string Email { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }


    }
}
