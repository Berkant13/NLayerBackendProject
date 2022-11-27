using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T>GetByIdAsync(int id);
        //şuan sorgu atmaz sorguyu hazırlar ve memory de tutar biz buna ToList dediğimiz an veritabanına gider ve veririyi getirir.
        IQueryable<T> GetAll();

        IQueryable<T> Where(Expression<Func<T, bool>> expression);
       
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        //async proglama var olan threadleri blocklamamak için kullanılır.
        Task AddAsync(T entity);
        
        Task AddRangeAsync(IEnumerable<T> entities);
        
        void Update(T entity);

        void Remove(T entity);
        
        void RemoveRange(IEnumerable<T> entities);
    }
}
