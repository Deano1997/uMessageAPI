using System.Collections.Generic;

namespace uMessageAPI.Models {
    public interface IMessageRepository : Generics.IEntityRepository<Message> {
        Message FindById(string id);

        IEnumerable<Message> GetAll();

        void Add(Message message);

        void Update(Message message);

        void saveChanges();


    }
}
