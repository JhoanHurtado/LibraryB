using AutoMapper;
using Library.DTOs.DTOs;
using Library.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Profiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            this.CreateMap<Editorial, EditorialDto>().ReverseMap();
            this.CreateMap<Autor, AutorDto>().ReverseMap();
            this.CreateMap<Libro, LibroDto>().ReverseMap();
        }
    }
}
