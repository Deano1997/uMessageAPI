using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using uMessageAPI.Models;
using uMessageAPI.Models.Generics;

namespace uMessageAPI.Data.Repositories.Generics
{
    public abstract class EntityRepository<EntityType> : IEntityRepository<EntityType>
      where EntityType: class, IEntity {
        
        private bool disposed = false;
        private ApplicationDbContext context;

        public EntityRepository(ApplicationDbContext context) {
            this.context = context;
        }

        protected ApplicationDbContext Context {
            get { return context; }
        }

        protected abstract DbSet<EntityType> EntityDataSet { get; }

        public void Add(EntityType entity) {
            EntityDataSet.Add(entity);
        }

        public EntityType GetById(Guid id) {
            return EntityDataSet.SingleOrDefault(r => r.Id == id);
        }

        public void Update(EntityType entity) {
            EntityDataSet.Update(entity);
        }

        public void Delete(EntityType entity) {
            EntityDataSet.Remove(entity);
        }

        public void SaveChanges() {
            Context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing) {
            if (!disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose() {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

    }
}