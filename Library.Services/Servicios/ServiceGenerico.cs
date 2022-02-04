using Library.Entities.Entities;
using Library.Interfaces.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Library.Services.Services
{
    public class ServiceGenerico<T> : IGenerica<T> where T : class
    {
        private readonly AppDbContext _dbContext;

        public ServiceGenerico(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T t)
        {
            _dbContext.Entry(t).State = EntityState.Added;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return t;
        }

        public async Task<List<T>> Find(Expression<Func<T, bool>> filtro)
        {
            return await _dbContext.Set<T>().Where(filtro).ToListAsync();
        }

        public async Task<List<T>> Get()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
    }
}
