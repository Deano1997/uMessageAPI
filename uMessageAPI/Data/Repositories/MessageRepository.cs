using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uMessageAPI.Models;

namespace uMessageAPI.Data.Repositories {
  public class MessageRepository : Generics.EntityRepository<Message>, IMessageRepository {

    public MessageRepository(ApplicationDbContext context) : base(context) { }

    protected override DbSet<Message> EntityDataSet { get { return Context.Messages; } }

  }
}
