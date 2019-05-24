using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using uMessageAPI.DTOs.Channel;
using uMessageAPI.DTOs.Member;
using uMessageAPI.DTOs.Message;
using uMessageAPI.Models;
using uMessageAPI.Utility;

namespace uMessageAPI.Controllers {

    [Route("api/v1/channels")]
    [ApiController]
    [Authorize]
    public class ChannelsController : ControllerBase {

        private readonly UserManager<User> userManager;
        private readonly IChannelRepository channelRepository;
        private readonly IMessageRepository messageRepository;
        private readonly IMemberRepository memberRepository;

        //messageRepo & memberRepo

        public ChannelsController(UserManager<User> userManager, IChannelRepository channelRepository, IMessageRepository messageRepository, IMemberRepository memberRepository) {
            this.userManager = userManager;
            this.channelRepository = channelRepository;
            this.messageRepository = messageRepository;
            this.memberRepository = memberRepository;
        }

        #region Channels

        [HttpGet]
        public async Task<ActionResult<ChannelDTO[]>> List() {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<ChannelDTO>> Create([FromBody] CreateChannelDTO model) {
            var channel = uMessageAPI.Models.Channel.FromCreateChannelDTO(model);
            // Create channel and assign a name.
            channelRepository.Add(channel);
            // Check whether thechannel was successfully created.
            if (channel != null) {
                // Generate the channel response for given channel.
                return Ok(ChannelDTO.FromChannel(channel));
            }

            return NotFound();
        }

        [HttpGet("{channelId}")]
        public async Task<ActionResult<ChannelDTO>> GetById(Guid channelId) {
            var channel = channelRepository.GetById(channelId);

            if (channel != null) {
                // Generate the user response for given user.
                return Ok(ChannelDTO.FromChannel(channel));
            }

            return NotFound();

        }

        [HttpPut("{channelId}")]
        public async Task<ActionResult<ChannelDTO>> Update(Guid channelId, [FromBody] UpdateChannelDTO model) {

            // Get the selected channel
            var channel = channelRepository.GetById(channelId);
                // Update the channel model with the information received from our DTO.
                channel.UpdateFromUpdateChannelDTO(model);
            // Save changes made to the channel model.
            channelRepository.SaveChanges();
            return NoContent();

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

            var message = uMessageAPI.Models.Message.FromCreateMessageDTO(model);
            // Check whether the current channel was resolved.
            if ( message.ChannelId == channelId) {
                // Create channel and assign a name.
                messageRepository.Add(message);
            }
            // Check whether the channel was successfully created.
            if (message != null) {
                // Generate the channel response for given channel.
                return Ok(MessageDTO.FromMessage(message));
            }

            return NotFound();
        }

        [HttpGet("{channelId}/messages/{messageId}")]
        public async Task<ActionResult<MessageDTO>> GetById(Guid channelId, Guid messageId) {
            var message = messageRepository.GetById(messageId);

            if (message != null) {
                // Generate the user response for given user.
                return Ok(MessageDTO.FromMessage(message));
            }

            return NotFound();
        }

        #endregion

        #region Members

        [HttpGet("{channelId}/members")]
        public async Task<ActionResult<MemberDTO[]>> MemberList(Guid channelId) {
            throw new NotImplementedException();
        }

        [HttpPost("{channelId}/members")]
        public async Task<ActionResult<MemberDTO>> Create(Guid channelId, [FromBody] CreateMemberDTO model) {
            throw new NotImplementedException();
        }

        [HttpGet("{channelId}/members/{memberId}")]
        public async Task<ActionResult<MemberDTO>> GetByMemberId(Guid channelId, Guid memberId) {
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
