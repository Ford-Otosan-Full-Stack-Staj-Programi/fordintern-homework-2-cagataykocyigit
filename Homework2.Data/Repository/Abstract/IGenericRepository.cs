namespace Homework2.Data.Repository.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {

        List<TEntity> GetAll();

        TEntity GetById(int id);

        void Put(TEntity entity);

        void Delete(TEntity entity);


        void Post(TEntity entity);

        List<TEntity> Where(System.Linq.Expressions.Expression<Func<TEntity, bool>> where);

    }
}
