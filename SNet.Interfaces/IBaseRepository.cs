using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SNet.Interfaces
{
    public interface IBaseRepository<TEntity>
    where TEntity : class
    {
        TEntity Create();
        void Add(TEntity entity);
        void Delete(TEntity entity);
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
    }
}
