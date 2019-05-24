
using System.Collections.Generic;

namespace uMessageAPI.Models {
    public interface IMemberRepository {

        Member GetBy(int id);
        IEnumerable<Member> GetAll();
        void Add(Member member);
        void Delete(Member member);
        void Update(Member member);
        void SaveChanges();


    }
}
