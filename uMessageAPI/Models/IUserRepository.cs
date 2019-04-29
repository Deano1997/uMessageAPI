using System.Collections.Generic;

namespace uMessageAPI.Models {
    public interface IUserRepository : Generics.IEntityRepository<User> {

        User FindById(string id);

        IEnumerable<User> GetAll();

        void Add(User user);
        void AddWithPassword(User user,string password);

        void Update(User user);

        void saveChanges();


    }

    



    



}
