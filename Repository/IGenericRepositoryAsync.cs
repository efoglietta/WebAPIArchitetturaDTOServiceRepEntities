using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArchitetturaDTOEntities.Repository
{
    public interface IGenericRepositoryAsync<T> where T : class
    {

        Task<List<T>> GetAllAsync();
        Task<List<T>> FindByAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        Task<T> GetSingleAsync(object id);        
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        Task<int> SaveAsync();
    }
}
