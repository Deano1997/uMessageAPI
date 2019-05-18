using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using uMessageAPI.DTOs.Channel;
using uMessageAPI.Models;
using uMessageAPI.Utility;

namespace uMessageAPI.Controllers {

    [Route("api/v1/channels")]
    [ApiController]
    [Authorize]
    public class ChannelsController : ControllerBase {

        private readonly UserManager<User> userManager;
        private readonly IChannelRepository channelRepository;

        public ChannelsController(UserManager<User> userManager, IChannelRepository channelRepository) {
            this.userManager = userManager;
            this.channelRepository = channelRepository;
        }

        #region Utility

        // FIXME: Move this into a base class so that we do not have to duplicate.
        private Task<uMessageAPI.Models.User> GetCurrentUserAsync() {
            return userManager.GetUserAsync(User);
        }

        #endregion

    }
}
