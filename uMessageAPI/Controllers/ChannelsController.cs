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

        #region Channels

        [HttpGet]
        public async Task<ActionResult<ChannelDTO[]>> List() {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<ChannelDTO>> Create([FromBody] CreateChannelDTO model) {
            throw new NotImplementedException();
        }

        [HttpGet("{channelId}")]
        public async Task<ActionResult<ChannelDTO>> GetById(Guid channelId) {
            throw new NotImplementedException();
        }

        [HttpPut("{channelId}")]
        public async Task<ActionResult<ChannelDTO>> Update(Guid channelId, [FromBody] UpdateChannelDTO model) {
            throw new NotImplementedException();
        }

        [HttpDelete("{channelId}")]
        public async Task<ActionResult> Delete(Guid channelId) {
            throw new NotImplementedException();
        }

        #endregion

        #region Messages

        [HttpGet("{channelId}/messages")]
        public async Task<ActionResult<MessageDTO[]>> List(Guid channelId) {
            throw new NotImplementedException();
        }

        [HttpPost("{channelId}/messages")]
        public async Task<ActionResult<MessageDTO>> Create(Guid channelId, [FromBody] CreateMessageDTO model) {
            throw new NotImplementedException();
        }

        [HttpGet("{channelId}/messages/{messageId}")]
        public async Task<ActionResult<MessageDTO>> GetById(Guid channelId, Guid messageId) {
            throw new NotImplementedException();
        }

        #endregion

        #region Members

        [HttpGet("{channelId}/members")]
        public async Task<ActionResult<MemberDTO[]>> List(Guid channelId) {
            throw new NotImplementedException();
        }

        [HttpPost("{channelId}/members")]
        public async Task<ActionResult<MemberDTO>> Create(Guid channelId, [FromBody] CreateMemberDTO model) {
            throw new NotImplementedException();
        }

        [HttpGet("{channelId}/members/{memberId}")]
        public async Task<ActionResult<ChannelDTO>> GetById(Guid channelId, Guid memberId) {
            throw new NotImplementedException();
        }

        [HttpPut("{channelId}/members/{memberId}")]
        public async Task<ActionResult<MemberDTO>> Update(Guid channelId, Guid memberId, [FromBody] UpdateMemberDTO model) {
            throw new NotImplementedException();
        }

        [HttpDelete("{channelId}/members/{memberId}")]
        public async Task<ActionResult> Delete(Guid channelId, Guid memberId) {
            throw new NotImplementedException();
        }

        #endregion

        #region Utility

        // FIXME: Move this into a base class so that we do not have to duplicate.
        private Task<uMessageAPI.Models.User> GetCurrentUserAsync() {
            return userManager.GetUserAsync(User);
        }

        #endregion

    }
}
