using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uMessageAPI.Models {
    public interface IChannelRepository {
        Channel Get(int id);
        void Add(Channel channel);
        void Delete(Channel channel);
        void Update(Channel channel);
        void SaveChanges();
    }
}
