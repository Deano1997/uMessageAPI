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
        
        private IHubContext<ServiceHub, IServiceHubClient> serviceHubContext;

        public SignalRTestController(IHubContext<ServiceHub, IServiceHubClient> serviceHubContext) {
          this.serviceHubContext = serviceHubContext;
        }

        [HttpGet]
        public async Task<ActionResult> SendMessage() {

            await serviceHubContext.Clients.All.BroadcastMessage("success", "Hello SignalR");

            return new NoContentResult();
        }

    }
}
