using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;

namespace Data.Core.Repositories
{
    public class Repository<CContext, TEntity> : IRepository<TEntity> where TEntity : class, new() where CContext : DbContext, new()
    {
        private CContext entities = new CContext();
        private TEntity entity = new TEntity();

        public CContext Context
        {
            get
            {
                return this.entities;
            }
            set
            {
                this.entities = value;
            }
        }

        public TEntity Entity
        {
            get
            {
                return this.entity;
            }
            set
            {
                this.entity = value;
            }
        }

        public Repository()
        {

        }

        public Repository(CContext context)
        {
            this.Context = context;
        }

        public Repository(TEntity entity)
        {
            this.Entity = entity;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = this.entities.Set<TEntity>();
            return query;
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = this.entities.Set<TEntity>().Where(predicate);
            return query;
        }

        public virtual TEntity FindById(object id)
        {
            TEntity query = this.entities.Set<TEntity>().Find(id);
            return query;
        }

        public virtual TEntity Add(TEntity entity)
        {
            return this.entities.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            this.entities.Entry(entity).State = EntityState.Deleted;
            //this.entities.Set<TEntity>().Remove(entity);
        }

        public virtual void Edit(TEntity entity)
        {
            this.entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            this.entities.SaveChanges();
        }

        public virtual void SaveAsync()
        {
            this.entities.SaveChangesAsync();
        }

        public void Dispose()
        {

        }

        public virtual void Refresh()
        {
            this.entities = new CContext();
        }
    }
}
