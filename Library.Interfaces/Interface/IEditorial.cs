using Library.Entities.Entities;
using Library.Interfaces.Interface;

namespace Library.Interfaces.Interface
{
    public interface IEditorial : IGenerica<Editorial>
    {
        Editorial Get(Editorial editorial);
    }
}
