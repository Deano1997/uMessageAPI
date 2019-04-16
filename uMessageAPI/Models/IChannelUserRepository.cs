using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uMessageAPI.Models {
    public interface IChannelUserRepository {

        List<ChannelUser> GetAll();

        void SaveChanges();


    }
}
