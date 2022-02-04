using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Entities.Entities
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Por falvor ingrese el autor")]
        public int AutorId { get; set; }
        public int EditorialId { get; set; }

        [Required(ErrorMessage = "Por falvor ingrese el titulo"), MaxLength(200, ErrorMessage = "El titulo debe tener maximo 200 caracteres")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Por falvor ingrese el año")]
        public int Ano { get; set; }
        [Required(ErrorMessage = "Por falvor ingrese el genero"), MaxLength(200, ErrorMessage = "El genero debe tener maximo 200 caracteres")]
        public string Genero { get; set; }
        [Required(ErrorMessage = "Por falvor ingrese el numero de paginas")]
        public int Paginas { get; set; }

        [ForeignKey("AutorId")]
        public virtual Autor Autor { get; set; }

        [ForeignKey("EditorialId")]
        public virtual Editorial Editorial { get; set; }

    }
}
