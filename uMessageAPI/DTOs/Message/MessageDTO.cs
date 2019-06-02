using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using uMessageAPI.DTOs.Channel;
using uMessageAPI.DTOs.User;

namespace uMessageAPI.DTOs.Message {
    public class MessageDTO {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid ChannelId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Modified { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public static MessageDTO FromMessage(uMessageAPI.Models.Message message) {
            return new MessageDTO {Id = message.Id, ChannelId = message.ChannelId, Text = message.Text, Created = message.Created,  Modified = message.Modified};
        }
    }
}
