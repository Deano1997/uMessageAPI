using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using uMessageAPI.Models;

namespace uMessageAPI.Data.Repositories {
    public class UserRepository :  Generics.EntityRepository<User>, IUserRepository {

       private readonly UserManager<User> userManager;


        public UserRepository(ApplicationDbContext context, UserManager<User> userManager) : base(context) {
            this.userManager = userManager;
        }

    protected override DbSet<User> EntityDataSet { get { return Context.Users; } }


        public void Add(User user) {
            EntityDataSet.AddAsync(user);
        }

        public User FindById(string id) {
            return EntityDataSet.FindAsync(id).Result;
        }
            

        public void Update(User user) {
            EntityDataSet.Update(user);
        }

        public IEnumerable<User> GetAll() {
            //Look if an Include is needed when getting list.
            return EntityDataSet;
        }

        public void AddWithPassword(User user, string password) {
            user.PasswordHash = userManager.PasswordHasher.HashPassword(user, password);

            Add(user);
        }
        public void saveChanges() {
            Context.SaveChanges();
        }
    }


}
