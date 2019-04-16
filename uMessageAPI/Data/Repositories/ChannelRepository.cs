using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uMessageAPI.Models;
using uMessageAPI.Models.Generics;

namespace uMessageAPI.Data.Repositories {
    public class ChannelRepository : Generics.EntityRepository<Channel>, IChannelRepository {

        public ChannelRepository(ApplicationDbContext context) : base(context) { }

        protected override DbSet<Channel> EntityDataSet { get { return Context.Channels; } }

    }
}
