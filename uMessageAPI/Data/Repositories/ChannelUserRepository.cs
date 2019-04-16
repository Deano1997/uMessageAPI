using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uMessageAPI.Models;


namespace uMessageAPI.Data.Repositories {
    public class ChannelUserRepository : IChannelUserRepository {
        private readonly ApplicationDbContext _dbContext;

        public ChannelUserRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public List<ChannelUser> GetAll() {
            return _dbContext.ChannelUsers
                .OrderBy(gs => gs.ChannelId)
                .Include(gs => gs.Channel)
                .Include(gs => gs.User)
                .ToList();
        }

        public void SaveChanges() {
            _dbContext.SaveChanges();
        }
    }
}
