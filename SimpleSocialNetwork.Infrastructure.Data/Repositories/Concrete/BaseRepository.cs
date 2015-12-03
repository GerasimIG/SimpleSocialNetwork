using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleSocialNetwork.Domain;
using SimpleSocialNetwork.Infrastructure.Data.Context;
using System.Data.Entity;
using SimpleSocialNetwork.Infrastructure.Data.Repositories.Abstract;

namespace SimpleSocialNetwork.Infrastructure.Data.Repositories.Concrete
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        protected SimpleSocialNetworkDbContext dbContext = new SimpleSocialNetworkDbContext();
        public void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            dbContext.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
            dbContext.SaveChanges();
        }

        public void Remove(int entityId)
        {
            TEntity student = dbContext.Set<TEntity>().Find(entityId);
            dbContext.Set<TEntity>().Remove(student);
            dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            var a = dbContext.Set<TEntity>().Find(id);
            return a;
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
