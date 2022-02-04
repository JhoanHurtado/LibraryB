using Library.Entities.Entities;
using Library.Interfaces.Interface;
using Library.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Library.Services.Services
{
    public class LibroService : ServiceGenerico<Libro>, ILibro
    {
        private readonly AppDbContext _dbContext;

        public LibroService(AppDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Libro Get(Libro libro)
        {
            return _dbContext.Set<Libro>().Where(a => a.Titulo.ToLower().Equals(libro.Titulo.ToLower())).FirstOrDefault();
        }

        public List<Libro> Get()
        {
            var query = from books in _dbContext.Libros.ToList()
                        join autors in _dbContext.Autors.ToList() on books.AutorId equals autors.Id
                        join editorial in _dbContext.Editorials.ToList() on books.EditorialId equals editorial.Id
                        select new Libro
                        {
                            Id = books.Id,
                            Ano = books.Ano,
                            AutorId = books.AutorId,
                            Autor = autors,
                            Editorial = editorial,
                            EditorialId = books.EditorialId,
                            Genero = books.Genero,
                            Paginas = books.Paginas,
                            Titulo = books.Titulo
                        };
            return query.ToList();
        }

        public List<Libro> Get(string filtro)
        {

            int filterYear = filtro.All(char.IsDigit) ? Convert.ToInt32(filtro) : 0;

            var query = from books in _dbContext.Libros.ToList()
                        join autors in _dbContext.Autors.ToList() on books.AutorId equals autors.Id
                        join editorial in _dbContext.Editorials.ToList() on books.EditorialId equals editorial.Id
                        where books.Titulo.ToLower().Contains(filtro.ToLower()) || books.Ano == filterYear || autors.Nombre.ToLower().Contains(filtro.ToLower())
                        select new Libro
                        {
                            Id = books.Id,
                            Ano = books.Ano,
                            AutorId = books.AutorId,
                            Autor = autors,
                            Editorial = editorial,
                            EditorialId = books.EditorialId,
                            Genero = books.Genero,
                            Paginas = books.Paginas,
                            Titulo = books.Titulo
                            };
                return query.ToList();
        }

        public int GetCountLibros(Libro libro)
        {
            var libros = _dbContext.Set<Libro>().Where(a => a.EditorialId == libro.EditorialId).ToList();
            var count = libros.Count();
            return count;
        }

    }
}
