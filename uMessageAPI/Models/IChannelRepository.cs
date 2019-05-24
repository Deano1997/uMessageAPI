using System.Collections.Generic;
using uMessageAPI.DTOs.Channel;

namespace uMessageAPI.Models {
    public interface IChannelRepository : Generics.IEntityRepository<Channel> {

        Channel FindById(string id);

        IEnumerable<Channel> GetAll();

        void Add(Channel channel);

        //void Update(Channel channel);

        void saveChanges();
        void Update(Channel channel);
    }

}
