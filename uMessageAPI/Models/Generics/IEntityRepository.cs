using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uMessageAPI.Models.Generics {
    public interface IEntityRepository<EntityType> : IDisposable
        where EntityType : class, IEntity {

        void Add(EntityType entity);

        EntityType GetById(Guid id);

        void Update(EntityType entity);

        void Delete(EntityType entity);

        void SaveChanges();

    }
}
