using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SNet.Repositories
{
    public interface IBaseRepository<TEntity>
    where TEntity : class
    {
        TEntity Create();
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
        IQueryable<TEntity> GetAll();

        void SaveChanges();

        //  TEntity GetById(int id);
    }
}
