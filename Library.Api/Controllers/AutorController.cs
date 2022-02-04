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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {

        private IAutor _iAutor;
        private readonly IMapper _mapper;

        public AutorController(IAutor autor, IMapper mapper)
        {
            _iAutor = autor;
            _mapper = mapper;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<BusinessResult<List<AutorDto>>> Get()
        {
            try
            {
                var autors = await _iAutor.Get();
                var autorsDto = _mapper.Map<List<AutorDto>>(autors);
                return BusinessResult<List<AutorDto>>.Sucess(autorsDto, "Autores registrados");
            }
            catch (InvalidModelException ex)
            {
                return BusinessResult<List<AutorDto>>.Issue(null, ex.Message);
            }
            catch (Exception ex)
            {
                return BusinessResult<List<AutorDto>>.Issue(null, "Hubo un error al consultar los autor");
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{filtro}")]
        public async Task<BusinessResult<List<AutorDto>>> Get(string Filtro)
        {
            try
            {
                var autors = await _iAutor.Find(x => (x.Nombre.Contains(Filtro) || x.Email.Contains(Filtro)));
                var autorsDto = _mapper.Map<List<AutorDto>>(autors);
                if (autors == null || autors.Count == 0)
                {
                    return BusinessResult<List<AutorDto>>.Sucess(autorsDto, "Cero resultados encontrados");
                }
                return BusinessResult<List<AutorDto>>.Sucess(autorsDto, "Autores encontrados");
            }
            catch (InvalidModelException ex)
            {
                return BusinessResult<List<AutorDto>>.Issue(null, ex.Message);
            }
            catch (Exception ex)
            {
                return BusinessResult<List<AutorDto>>.Issue(null, "Hubo un error al consultar los autores");
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<BusinessResult<AutorDto>> Post(AutorDto autorDto)
        {
            try
            {
                var validate = new ValidateEntities().ValidarAutor(autorDto);

                if (validate.Result == null)
                {
                    return validate;
                }
                var autor = _mapper.Map<Autor>(autorDto); 

                var exisAutor = _iAutor.Get(autor);
                if (exisAutor != null)
                {
                    return BusinessResult<AutorDto>.Issue(null, "Hubo un error al registrar el autor, ya se registro un autor con este email");
                }

                var newAutor = await _iAutor.Add(autor);

                if (newAutor == null)
                {
                    return BusinessResult<AutorDto>.Issue(null, "Hubo un error al registrar el autor");
                }
                var newAutorDto = _mapper.Map<AutorDto>(newAutor);
                return BusinessResult<AutorDto>.Sucess(newAutorDto, "Se agrego el autor");

            }
            catch (InvalidModelException ex)
            {
                return BusinessResult<AutorDto>.Issue(null, ex.Message);
            }
            catch (Exception ex)
            {
                return BusinessResult<AutorDto>.Issue(null, "Hubo un error al registrar el autor");
            }
        }

    }
}
