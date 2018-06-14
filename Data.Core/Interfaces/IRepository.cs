using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Core.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class 
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        TEntity FindById(object id);

        TEntity Add(TEntity entity);

        void Delete(TEntity entity);

        void Edit(TEntity entity);

        void Save();

        void Refresh();
    }
}