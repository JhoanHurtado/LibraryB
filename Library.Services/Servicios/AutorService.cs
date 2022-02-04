using Library.Entities.Entities;
using Library.Interfaces.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services.Services
{
    public class AutorService : ServiceGenerico<Autor>, IAutor
    {
        private readonly AppDbContext _dbContext;

        public AutorService(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Autor Get(Autor autor)
        {
            return   _dbContext.Set<Autor>().Where(a=>a.Nombre.ToLower().Equals(autor.Nombre.ToLower())).FirstOrDefault();
        }
    }
}
