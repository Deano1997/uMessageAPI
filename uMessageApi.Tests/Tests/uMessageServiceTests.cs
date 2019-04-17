using Microsoft.EntityFrameworkCore;
using System;
using uMessageAPI.Data;
using uMessageAPI.Data.Repositories;
using uMessageAPI.Models;
using Xunit;

namespace uMessageApi.Tests {
    public class uMessageServiceTests {

        private ApplicationDbContext createDbContext() {
            var options = new DbContextOptionsBuilder()
               .UseInMemoryDatabase(databaseName: "uMessage")
               .Options;
 
            return new ApplicationDbContext(options);
        }

        [Fact]
        public void Delete_ValidChannel_GetChannelWithProperties() {
            // Run the test against one instance of the context
            using (var context = createDbContext()) {
                var repository = new ChannelRepository(context);
                var mockChannel = new Channel() { Name = "TestingChannel" };

                repository.Add(mockChannel);
                repository.SaveChanges();
                repository.Delete(mockChannel);
                repository.SaveChanges();

                var result = repository.GetById(mockChannel.Id);

                Assert.Null(result); 
            }
        }

        [Fact]
        public void Get_ValidChannel_GetChannelWithProperties() {
            // Run the test against one instance of the context
            using (var context = createDbContext()) {
                var repository = new ChannelRepository(context);
                var mockChannel = new Channel() { Name = "TestingChannel" };
                repository.Add(mockChannel);
                repository.SaveChanges();

                var result = repository.GetById(mockChannel.Id);

                Assert.Equal(mockChannel.Name, result.Name);
            }
        }



            [Fact]
        public void Update_ValidChannel_UpdateName() {
            // Run the test against one instance of the context
            using (var context = createDbContext()) {
                var repository = new ChannelRepository(context);
                var mockChannel = new Channel() { Name = "TestingChannel"};
                repository.Add(mockChannel);
                repository.SaveChanges();
                mockChannel.Name = "Testingtt";
                repository.Update(mockChannel);
                repository.SaveChanges();

                var result = repository.GetById(mockChannel.Id);

                Assert.Equal(mockChannel.Name, result.Name);
            }

        }
        [Fact]
        public void Update_ValidChannel_UpdateModified() {
            // Run the test against one instance of the context
            using (var context = createDbContext()) {
                var repository = new ChannelRepository(context);
                var mockChannel = new Channel() { Name = "TestingChannel", Modified = DateTime.Now };
                /* repository.Add(mockChannel);*/
                repository.SaveChanges();
                mockChannel.Modified = DateTime.Now;
                repository.Update(mockChannel);
                repository.SaveChanges();

                var result = repository.GetById(mockChannel.Id);

                Assert.Equal(mockChannel.Modified,result.Modified);
            }

        }
    }
}
