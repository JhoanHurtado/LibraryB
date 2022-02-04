using Library.Entities.Entities;
using System.Threading.Tasks;

namespace Library.Interfaces.Interface
{
    public interface IAutor: IGenerica<Autor>
    {
        Autor Get(Autor autor);
    }
}
