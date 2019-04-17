using Microsoft.EntityFrameworkCore;
using uMessageAPI.Data;

namespace uMessageApi.Tests.Fixtures {
    class EntityFixtures {

        private ApplicationDbContext context;

        public ApplicationDbContext Context {
            get {

                if (context == null) {

                    context = CreateDbContext();
                }

                return context;
            }
        }

        protected ApplicationDbContext CreateDbContext() {
            var options = new DbContextOptionsBuilder()
              .UseInMemoryDatabase(databaseName: "uMessage")
              .Options;

            return new ApplicationDbContext(options);
        }
   
    }
}
