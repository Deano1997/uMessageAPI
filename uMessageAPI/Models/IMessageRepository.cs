using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uMessageAPI.Models {
    public interface IMessageRepository {

        Message Get(int id);
        void Add(Message message);
        void Delete(Message message);
        void Update(Message message);
        void SaveChanges();
    }
}
