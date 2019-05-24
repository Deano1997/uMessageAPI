using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using uMessageAPI.Models;

namespace uMessageAPI.Data.Repositories {
    public class MessageRepository : Generics.EntityRepository<Message>, IMessageRepository {

    public MessageRepository(ApplicationDbContext context) : base(context) { }

    protected override DbSet<Message> EntityDataSet { get { return Context.Messages; } }

        public Message FindById(string id) {
            return EntityDataSet.FindAsync(id).Result;
        }

        public IEnumerable<Message> GetAll() {
            return EntityDataSet;
        }

        public void saveChanges() {
            Context.SaveChanges();
        }
    }
}
