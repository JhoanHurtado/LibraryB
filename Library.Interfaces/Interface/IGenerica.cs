using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Library.Interfaces.Interface
{
    public interface IGenerica<T> where T:class
    {
        Task<List<T>> Get();
        Task<List<T>> Find(Expression<Func<T, bool>> filtro);
        Task<T> Add(T t);
    }
}
