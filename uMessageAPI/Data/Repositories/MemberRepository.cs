
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using uMessageAPI.Models;

namespace uMessageAPI.Data.Repositories {
    public class MemberRepository : Generics.EntityRepository<Member>, IMemberRepository {
        public MemberRepository(ApplicationDbContext context) : base(context) { }

        protected override DbSet<Member> EntityDataSet { get { return Context.Members; } }

        public IEnumerable<Member> GetAll() {
            return EntityDataSet;
        }

        public void Add(Member member) {
            EntityDataSet.AddAsync(member);
        }

        public Member GetBy(int id) {
            return EntityDataSet.FindAsync(id).Result;
        }

        public void saveChanges() {
            Context.SaveChanges();
        }
    }
}
