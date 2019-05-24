using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using uMessageAPI.DTOs.Channel;
using uMessageAPI.Models;

namespace uMessageAPI.Data.Repositories {
    public class ChannelRepository : Generics.EntityRepository<Channel>, IChannelRepository {

        public ChannelRepository(ApplicationDbContext context) : base(context) { }

        protected override DbSet<Channel> EntityDataSet { get { return Context.Channels; } }

        public void Add(Channel channel) {
            EntityDataSet.AddAsync(channel);
        }

        public Channel FindById(string id) {
            return EntityDataSet.FindAsync(id).Result;
        }

        public IEnumerable<Channel> GetAll() {
            return EntityDataSet;
        }

        public void saveChanges() {
            Context.SaveChanges();
        }

        public void Update(Channel channel) {
            EntityDataSet.Update(channel);

        }
    }
}
