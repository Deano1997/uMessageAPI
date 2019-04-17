using uMessageApi.Tests.Fixtures;
using Xunit;

namespace uMessageApi.Tests.Tests {
    public class uMessageDatabaseTests : IClassFixture<ChannelFixture> {
        private ChannelFixture fixture;

        public uMessageDatabaseTests(ChannelFixture fixture) {
            this.fixture = fixture;
        }


    }
}
