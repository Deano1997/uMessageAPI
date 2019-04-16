using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uMessageAPI.Models;

namespace uMessageAPI.Data.Repositories {
    public class ChannelRepository : IChannelRepository {

        private readonly ApplicationDbContext _dbContext;

        public ChannelRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public void Add(Channel channel) {
            _dbContext.Channels.Add(channel);
        }

        public void Delete(Channel channel) {
            _dbContext.Channels.Remove(channel);
        }

        public Channel Get(int id) {
            return _dbContext.Channels.SingleOrDefault(r => r.Id == id);
        }

        public void Update(Channel channel) {
            _dbContext.Update(channel);
        }

        public void SaveChanges() {
            _dbContext.SaveChanges();
        }
    }
}
