using Production.Modals.Entity;
using System.Linq.Expressions;

namespace Production.Data
{
    public interface IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        void Delete(int id);
        void Delete(TEntity entity);
        List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity GetById(int? id);
        TEntity GetByIdWithProps(int? id, string includeProperties = "");
        void Insert(TEntity entity);
        void Reload(TEntity entity);
        void Update(TEntity entity);
    }
}
