using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uMessageAPI.Models;

namespace uMessageAPI.Data.Repositories {
  public class UserRepository : Generics.EntityRepository<User>, IUserRepository {

    public UserRepository(ApplicationDbContext context) : base(context) { }

    protected override DbSet<User> EntityDataSet { get { return Context.Users; } }

  }
}
