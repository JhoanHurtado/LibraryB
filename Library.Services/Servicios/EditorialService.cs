using Library.Entities.Entities;
using Library.Interfaces.Interface;
using System.Linq;

namespace Library.Services.Services
{
    public class EditorialService : ServiceGenerico<Editorial>, IEditorial
    {
        private readonly AppDbContext _dbContext;

        public EditorialService(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Editorial Get(Editorial editorial)
        {
            return _dbContext.Set<Editorial>().Where(e => e.Nombre.ToLower().Equals(editorial.Nombre.ToLower())).FirstOrDefault();
        }
    }
}