
using System.Collections.Generic;

namespace uMessageAPI.Models {
    public interface IMemberRepository: Generics.IEntityRepository<Member> {

        Member GetBy(int id);

        IEnumerable<Member> GetAll();

        void Add(Member member);

        void Delete(Member member);

        void Update(Member member);

        IEnumerable<Member> GetAllByChannel(Channel channel);


        void SaveChanges();




    }
}
