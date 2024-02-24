using System.Linq.Expressions;
using HumanResource.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HumanResource.Data
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly int CompanyId;
        private readonly int UserId;
        private readonly HumanResourceDbContext Context;
        private readonly ILogger logger;
        private readonly DbSet<TEntity> DbSet;

        public BaseRepository(HumanResourceDbContext context, ILogger logger,int companyId, int userId)
        {
            Context = context;
            this.logger = logger;
            DbSet = Context.Set<TEntity>();
            CompanyId = companyId;
            UserId = userId;
        }

        public virtual List<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(a => !a.IsDeleted).Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet.Where(a => !a.IsDeleted);
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.FirstOrDefault(a => !a.IsDeleted && a.Id == id);
        }

        public virtual TEntity GetById(int? id)
        {
            if (id.HasValue)
            {
                return GetById(id.Value);
            }
            throw new InvalidOperationException("Id should have a value");
        }

        public virtual TEntity GetByIdWithProps(int? id, string includeProperties = "")
        {
            if (id.HasValue)
            {
                IQueryable<TEntity> query = DbSet;
                query = query.Where(a => !a.IsDeleted && a.Id == id);

                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                return query.Single();
            }
            throw new InvalidOperationException("Id should have a value");
        }

        public virtual void Insert(TEntity entity)
        {
            DateTime now = DateTime.Now;

            entity.IsDeleted = false;
            entity.CreatedBy = UserId;
            entity.CreatedOn = now;
            entity.UpdatedBy = UserId;
            entity.UpdatedOn = now;
            DbSet.Add(entity);
            Context.Entry(entity).State = 0;

            logger.LogInformation($"INSERT: {GetLoggerProps(entity)}");
        }

        public virtual void Delete(int id)
        {
            var entity = DbSet.Find(id);
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.UpdatedBy = UserId;
            entity.UpdatedOn = DateTime.Now;
            DbSet.Attach(entity);
            Context.Entry(entity).State = 0;

            logger.LogInformation($"DELETE: {GetLoggerProps(entity)}");
        }

        public virtual void Update(TEntity entity)
        {
            entity.UpdatedBy = UserId;
            entity.UpdatedOn = DateTime.Now;
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;

            logger.LogInformation($"UPDATE: {GetLoggerProps(entity)}");
        }

        public virtual void Reload(TEntity entity)
        {
            Context.Entry(entity).Reload();
        }

        private Dictionary<string, string> GetLoggerProps(TEntity entity)
        {
            string jsonEntity;
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                jsonEntity = JsonConvert.SerializeObject(entity, settings);
            }
            catch (Exception ex)
            {
                jsonEntity = ex.Message;
            }

            Dictionary<string, string> props = new Dictionary<string, string>()
            {
                { "Entity name", entity.GetType().Name },
                { "User Id", UserId.ToString() },
                { "Entity", jsonEntity }
            };

            return props;
        }
    }
}

