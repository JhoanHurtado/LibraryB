using Library.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces.Interface
{
    public interface ILibro: IGenerica<Libro>
    {
        Libro Get(Libro libro);
        List<Libro> Get();
        List<Libro> Get(string filtro);

        int GetCountLibros(Libro libro);
    }
}
