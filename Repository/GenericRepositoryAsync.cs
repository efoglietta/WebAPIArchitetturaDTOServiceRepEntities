using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchitetturaDTOEntities.DataAccess;
using Microsoft.EntityFrameworkCore;



namespace ArchitetturaDTOEntities.Repository
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T>
        where T : class
       
    {
        NorthwindContext db;
        public GenericRepositoryAsync(NorthwindContext db)
        {
            this.db = db; 
        }


        public GenericRepositoryAsync()
        {
            db = new NorthwindContext();
            //db = ContextFactory.Factory.GetContext();
            //db.Database.Log = Console.Write;

        }


        public async Task<List<T>> GetAllAsync()
        {
           return await db.Set<T>().ToListAsync();         
        }

        public async Task<List<T>> FindByAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
          return  await db.Set<T>().Where(predicate).ToListAsync();
        }

        public void Add(T entity)
        {
            db.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            db.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

      
        public async Task<T> GetSingleAsync(object id)
        {
            return await db.Set<T>().FindAsync(id);
        }

       

        public async Task<int> SaveAsync()
        {
            return await db.SaveChangesAsync();
        }
    }
}
