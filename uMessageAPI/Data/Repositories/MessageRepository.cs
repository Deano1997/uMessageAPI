using Microsoft.EntityFrameworkCore;
using uMessageAPI.Models;

namespace uMessageAPI.Data.Repositories {
    public class MessageRepository : Generics.EntityRepository<Message>, IMessageRepository {

    public MessageRepository(ApplicationDbContext context) : base(context) { }

    protected override DbSet<Message> EntityDataSet { get { return Context.Messages; } }

  }
}
