using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uMessageAPI.Models {
    public interface IChannelRepository {

        void Add(Channel channel);

        Channel Get(int id);

        void Update(Channel channel);

        void Delete(Channel channel);

        void SaveChanges();

    }
}
