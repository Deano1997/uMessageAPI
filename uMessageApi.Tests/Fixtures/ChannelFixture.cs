using System;
using uMessageAPI.Models;

namespace uMessageApi.Tests.Fixtures {
    public class ChannelFixture : EntityFixtures  IDisposable {

        public IChannelRepository Repository{ get; private set; }

        public void Dispose() {
            throw new NotImplementedException();
        }


    }
}
