using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    // t yi class olarak belirtmek zorundayız.
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //Varsayalım product sınıfından ekstra methodlara ihtiyaç duyduk böyle bir durumda bunu private yerine protected yapmak daha doğrudur.Çünkü inherit etmemizi sağlar.
        //Protected miras aldığınız yerde erişmenizi sağlar.
        //readonly olmasının sebebi farklı dbcontext lerin set edilmesini engellemek için yapıyoruz.
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            //ef core datayı track etmemesini sağlıyor.
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
