using Microsoft.EntityFrameworkCore;
using uMessageAPI.Models;

namespace uMessageAPI.Data.Repositories {
    public class ChannelRepository : Generics.EntityRepository<Channel>, IChannelRepository {

        public ChannelRepository(ApplicationDbContext context) : base(context) { }

        protected override DbSet<Channel> EntityDataSet { get { return Context.Channels; } }

    }
}
