using Library.DTOs.DTOs;
using Library.Exceptions.Excepcions;

namespace Library.Utility.Utility
{
    public class ValidateEntities
    {
        public BusinessResult<LibroDto> ValidarLibro(LibroDto LibroDto)
        {
            if (LibroDto.Ano <= 0)
            {
                throw new InvalidModelException("Debe ingresar el año del libro, es un campo requerido");
            }
            else if (LibroDto.Genero == null || LibroDto.Genero.Equals(""))
            {
                throw new InvalidModelException("Debe ingresar el genero del libro, es un campo requerido");
            }
            else if (LibroDto.Paginas <= 0)
            {
                throw new InvalidModelException("Debe ingresar la cantidad de paginas del libro, es un campo requerido");
            }
            else if (LibroDto.Titulo == null || LibroDto.Titulo.Equals(""))
            {
                throw new InvalidModelException("Debe ingresar el titulo del libro, es un campo requerido");
            }
            return BusinessResult<LibroDto>.Sucess(LibroDto, "");

        }



        public BusinessResult<AutorDto> ValidarAutor(AutorDto autor)
        {
            if (autor.Nombre == null || autor.Nombre.Equals(""))
            {
                throw new InvalidModelException("Debe ingresar el nombre del autor, es un campo requerido");
            }
            else if (autor.Email == null || autor.Email.Equals(""))
            {
                throw new InvalidModelException("Debe ingresar el email del autor, es un campo requerido");

            }
            else if (autor.CiudadProcedencia == null || autor.CiudadProcedencia.Equals(""))
            {
                throw new InvalidModelException("Debe ingresar la ciudad de providencia del autor, es un campo requerido");

            }
            else if (autor.FechaNacimiento.Equals("") || autor.FechaNacimiento.Equals("1/01/0001 12:00:00 a. m."))
            {
                throw new InvalidModelException("Debe ingresar la fecha de nacimiento del autor, es un campo requerido");
            }
            return BusinessResult<AutorDto>.Sucess(autor, "");

        }

        public BusinessResult<AutorDto> ValidarAutorName(AutorDto autor)
        {
            if (autor.Nombre == null || autor.Nombre.Equals(""))
            {
                throw new InvalidModelException("Debe ingresar el nombre del autor, es un campo requerido");
            }
            return BusinessResult<AutorDto>.Sucess(autor, "");

        }
        public BusinessResult<EditorialDto> ValidarEditorial(EditorialDto editorial)
        {
            if (editorial.Nombre == null || editorial.Nombre.Equals(""))
            {
                throw new InvalidModelException("Debe ingresar el nombre de la editorial, es un campo requerido");
            }
            else if (editorial.Email == null || editorial.Email.Equals(""))
            {
                throw new InvalidModelException("Debe ingresar el email de la editorial, es un campo requerido");

            }
            else if (editorial.Direccion == null || editorial.Direccion.Equals(""))
            {
                throw new InvalidModelException("Debe ingresar la direccion de la editorial, es un campo requerido");

            }
            else if (editorial.Telefono.Equals("") || editorial.Telefono.Equals(""))
            {
                throw new InvalidModelException("Debe ingresar el telefono de la editorial, es un campo requerido");
            }
            return BusinessResult<EditorialDto>.Sucess(editorial, "");

        }

        public BusinessResult<EditorialDto> ValidarEditorialName(EditorialDto editorial)
        {
            if (editorial.Nombre == null || editorial.Nombre.Equals(""))
            {
                throw new InvalidModelException("Debe ingresar el nombre de la editorial, es un campo requerido");
            }
            return BusinessResult<EditorialDto>.Sucess(editorial, "");

        }
    }
}
