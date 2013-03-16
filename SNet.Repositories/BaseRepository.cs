using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNet.Repositories
{
    public abstract class BaseRepository<TContext, TEntity> : IBaseRepository<TEntity>
        where TContext : DbContext
        where TEntity : class 
    {
        private TContext _context;

        protected TContext Context { get { return _context; } }

        public BaseRepository(TContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().AsQueryable<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public TEntity Create()
        {
            return Context.Set<TEntity>().Create();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        /*
        public TEntity GetById(int id)
        {
            return Context.CreateObjectSet<TEntity>().SingleOrDefault(e => e.Id == id);
        }
        */
    }
}
