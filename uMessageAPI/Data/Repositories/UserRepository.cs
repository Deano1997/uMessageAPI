using Microsoft.EntityFrameworkCore;
using uMessageAPI.Models;

namespace uMessageAPI.Data.Repositories {
    public class UserRepository : Generics.EntityRepository<User>, IUserRepository {

    public UserRepository(ApplicationDbContext context) : base(context) { }

    protected override DbSet<User> EntityDataSet { get { return Context.Users; } }

  }
}
