using Homework2.Data.Context;
using Homework2.Data.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Homework2.Data.Repository.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _appDbContext;
        private DbSet<TEntity> data;

        public GenericRepository(AppDbContext _appDbContext)
        {
            this._appDbContext = _appDbContext;
            this.data = this._appDbContext.Set<TEntity>();

        }
        public void Delete(TEntity entity)
        {
            data.Remove(entity);
        }

        public List<TEntity> GetAll()
        {
            return data.ToList();
        }

        public TEntity GetById(int id)
        {
            return data.Find(id);
        }

        public void Post(TEntity entity)
        {
            data.Add(entity);
        }

        public void Put(TEntity entity)
        {
            data.Update(entity);
        }

        public List<TEntity> Where(Expression<Func<TEntity, bool>> where)
        {
            return data.Where(where).ToList();
        }
    }
}
