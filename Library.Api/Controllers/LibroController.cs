using AutoMapper;
using Library.DTOs.DTOs;
using Library.Entities.Entities;
using Library.Exceptions.Excepcions;
using Library.Interfaces.Interface;
using Library.Utility.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private ILibro _iLibro;
        private IAutor _iAutor;
        private IEditorial _iEditorial;
        private readonly IMapper _mapper;

        public LibroController(ILibro Libro, IAutor autor,IEditorial editorial, IMapper mapper)
        {
            _iLibro = Libro;
            _iAutor = autor;
            _iEditorial = editorial;
            _mapper = mapper;
        }

        // GET api/values
        public async Task<BusinessResult<List<LibroDto>>> Get()
        {
            try
            {
                var Libros =  _iLibro.Get();
                var LibrosDto = _mapper.Map<List<LibroDto>>(Libros);
                return BusinessResult<List<LibroDto>>.Sucess(LibrosDto, "Libros registrados");
            }
            catch (InvalidModelException ex)
            {
                return BusinessResult<List<LibroDto>>.Issue(null, ex.Message);
            }
            catch (Exception ex)
            {
                return BusinessResult<List<LibroDto>>.Issue(null, "Hubo un error al consultar los Libro");
            }
        }


        // GET api/<ValuesController>/5
        [HttpGet("{filtro}")]
        public BusinessResult<List<LibroDto>> Get(string Filtro)
        {


            try
            {
                var Libros = _iLibro.Get(Filtro);
                var LibrosDto = _mapper.Map<List<LibroDto>>(Libros);

                if (Libros == null || Libros.Count == 0)
                {
                    return BusinessResult<List<LibroDto>>.Sucess(LibrosDto, "Cero resultados encontrados");
                }
                return BusinessResult<List<LibroDto>>.Sucess(LibrosDto, "Libros encontrados");

            }
            catch (InvalidModelException ex)
            {
                return BusinessResult<List<LibroDto>>.Issue(null, ex.Message);
            }
            catch (Exception ex)
            {
                return BusinessResult<List<LibroDto>>.Issue(null, "Hubo un error al consultar los Libro");
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<BusinessResult<LibroDto>> Post(LibroDto LibroDto)
        {
            try
            {
                var validate = new ValidateEntities();

                var validateLibro = validate.ValidarLibro(LibroDto);
                if (validateLibro.Result == null)
                {
                    return validateLibro;
                }

                #region #### VALIDAR SI EXISTE LIBRO 
                var Libro = _mapper.Map<Libro>(LibroDto);
                var exisAutor = _iLibro.Get(Libro);
                if (exisAutor != null)
                {
                    return BusinessResult<LibroDto>.Sucess(null, "Hubo un error al registrar el libro, ya se registro un libro con este nombre");
                }
                #endregion

                validate.ValidarAutorName(LibroDto.Autor);
                validate.ValidarEditorialName(LibroDto.Editorial);

                #region ## VALIDAR AUTOR
                var autor = _mapper.Map<Autor>(LibroDto.Autor);
                var veirifiedAutor = _iAutor.Get(autor);
                if (veirifiedAutor == null)
                {
                    return BusinessResult<LibroDto>.Sucess(null, "El autor no está registrado");
                }
                #endregion


                #region ### VALIDAR EDITORIAL
                var editorial = _mapper.Map<Editorial>(LibroDto.Editorial);
                var veirifiedEditorial = _iEditorial.Get(editorial);
                if (veirifiedEditorial == null)
                {
                    return BusinessResult<LibroDto>.Sucess(null, "La editorial no está registrada");
                }
                #endregion

                #region VALIDAR CANTIDAD DE LIBROS POR EDITORIAL

                Libro.AutorId = veirifiedAutor.Id;
                Libro.EditorialId = veirifiedEditorial.Id;
    
                var countLibro = _iLibro.GetCountLibros(Libro);

                if (countLibro >= veirifiedEditorial.NLibros && veirifiedEditorial.NLibros >= 0)
                {
                    throw new BookLimitException("No es posible registrar el libro, se alcanzó el máximo permitido");
                }
                #endregion

                Libro.Autor = null;
                Libro newLibro = await _iLibro.Add(Libro);
                if (newLibro == null)
                {
                    return BusinessResult<LibroDto>.Sucess(LibroDto, "Hubo un error al registrar el Libro");
                }
                var newLibroDto = _mapper.Map<LibroDto>(newLibro);
                return BusinessResult<LibroDto>.Sucess(newLibroDto, "Se agrego el Libro");

            }
            catch (InvalidModelException ex)
            {
                return BusinessResult<LibroDto>.Issue(null, ex.Message);
            }
            catch (BookLimitException ex)
            {
                return BusinessResult<LibroDto>.Issue(null, ex.Message);
            }
            catch (Exception ex)
            {
                return BusinessResult<LibroDto>.Issue(null, "Hubo un error al registrar el Libro");
            }
        }
    }
}
