using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uMessageAPI.Models;

namespace uMessageAPI.Data.Repositories {
    public class MessageRepository : IMessageRepository {
        private readonly ApplicationDbContext _dbContext;

        public MessageRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }
        public void Add(Message message) {
            _dbContext.Messages.Add(message);
        }

        public void Delete(Message message) {
            _dbContext.Messages.Remove(message);
        }
        public void Update(Message message) {
            _dbContext.Messages.Update(message);
        }

        public Message Get(int id) {
            return _dbContext.Messages.SingleOrDefault(r => r.Id == id);

        }

        public void SaveChanges() {
            _dbContext.SaveChanges();
        }

        
    }
}
