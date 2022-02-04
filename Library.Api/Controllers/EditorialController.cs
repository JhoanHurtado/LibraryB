using AutoMapper;
using Library.DTOs.DTOs;
using Library.Entities.Entities;
using Library.Exceptions.Excepcions;
using Library.Interfaces;
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
    public class EditorialController : ControllerBase
    {

        private IEditorial _iEditorial;
        private readonly IMapper _mapper;

        public EditorialController(IEditorial iEditorial, IMapper mapper)
        {
            _iEditorial = iEditorial;
            _mapper = mapper;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<BusinessResult<List<EditorialDto>>> Get()
        {
            try
            {
                var editorials = await _iEditorial.Get();
                var editorialDto = _mapper.Map<List<EditorialDto>>(editorials);
                return BusinessResult<List<EditorialDto>>.Sucess(editorialDto, "Editoriales registradas");
            }
            catch (InvalidModelException ex)
            {
                return BusinessResult<List<EditorialDto>>.Issue(null, ex.Message);
            }
            catch (Exception ex)
            {
                return BusinessResult<List<EditorialDto>>.Issue(null, "Hubo un error al consultar las editoriales");
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{filtro}")]
        public async Task<BusinessResult<List<EditorialDto>>> Get(string Filtro)
        {
            try
            {
                var editorials = await _iEditorial.Find(x => (x.Nombre.Contains(Filtro) || x.Email.Contains(Filtro)));
                var editorialsDto = _mapper.Map<List<EditorialDto>>(editorials);
                if (editorials == null || editorials.Count == 0)
                {
                    return BusinessResult<List<EditorialDto>>.Sucess(editorialsDto, "Cero resultados encontrados");
                }
                return BusinessResult<List<EditorialDto>>.Sucess(editorialsDto, "editoriales encontradas");
            }
            catch (InvalidModelException ex)
            {
                return BusinessResult<List<EditorialDto>>.Issue(null, ex.Message);
            }
            catch (Exception ex)
            {
                return BusinessResult<List<EditorialDto>>.Issue(null, "Hubo un error al consultar los autores");
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<BusinessResult<EditorialDto>> Post(EditorialDto editorialDto)
        {
            try
            {
                var validate = new ValidateEntities().ValidarEditorial(editorialDto);

                if (validate.Result == null)
                {
                    return validate;
                }
                var editorial = _mapper.Map<Editorial>(editorialDto); 

                var exisEditorial = _iEditorial.Get(editorial);
                if (exisEditorial != null)
                {
                    return BusinessResult<EditorialDto>.Issue(null, "Hubo un error al registrar el editorial, ya se registro esta editorial");
                }

                editorial.NLibros = editorial.NLibros <= 0 ? -1 : editorial.NLibros;
                var newEditorial = await _iEditorial.Add(editorial);

                if (newEditorial == null)
                {
                    return BusinessResult<EditorialDto>.Issue(null, "Hubo un error al registrar el editorial");
                }
                var newEditorialDto = _mapper.Map<EditorialDto>(newEditorial);
                return BusinessResult<EditorialDto>.Sucess(newEditorialDto, "Se agrego la editorial");

            }
            catch (InvalidModelException ex)
            {
                return BusinessResult<EditorialDto>.Issue(null, ex.Message);
            }
            catch (Exception ex)
            {
                return BusinessResult<EditorialDto>.Issue(null, "Hubo un error al registrar la editorial");
            }
        }

    }
}
