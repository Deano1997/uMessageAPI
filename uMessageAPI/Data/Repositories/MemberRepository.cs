
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using uMessageAPI.Models;

namespace uMessageAPI.Data.Repositories {
    public class MemberRepository : Generics.EntityRepository<Member>, IMemberRepository {
        public MemberRepository(ApplicationDbContext context) : base(context) { }

        protected override DbSet<Member> EntityDataSet { get { return Context.Members; } }

        public IEnumerable<Member> GetAll() {
            return EntityDataSet.Include(g => g.User);
        }

        public void Add(Member member) {
            EntityDataSet.AddAsync(member);
        }

        public Member GetBy(int id) {
            return EntityDataSet.FindAsync(id).Result;
        }

        public IEnumerable<Member> GetAllByChannel(Channel channel) {
            return EntityDataSet.Where(memb => memb.ChannelId == channel.Id).Include(u => u.User);
        }

        public void saveChanges() {
            Context.SaveChanges();
        }
    }
}
