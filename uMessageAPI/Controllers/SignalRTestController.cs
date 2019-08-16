using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using uMessageAPI.Hub;

namespace uMessageAPI.Controllers {

    [Route("api/v1/signal-r-test")]
    [ApiController]
    // FIXME: Remove controller after testing
    public class SignalRTestController : ControllerBase {
        
        private IHubContext<NotifyHub, ITypedHubClient> serviceHubContext;

        public SignalRTestController(IHubContext<NotifyHub, ITypedHubClient> serviceHubContext) {
          this.serviceHubContext = serviceHubContext;
        }

        [HttpGet]
        public async Task<ActionResult> SendMessage() {

            await serviceHubContext.Clients.All.BroadcastMessage( "Hello SignalR");

            return new NoContentResult();
        }

    }
}
