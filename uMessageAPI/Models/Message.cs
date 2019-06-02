using System;
using System.ComponentModel.DataAnnotations;
using uMessageAPI.DTOs.Message;

namespace uMessageAPI.Models {
    public class Message : Generics.IEntity {

        #region Properties
        [Required]
        public Guid Id { get; set; }

        public Guid ChannelId { get; set; }
        [Required]
        public Channel Channel { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Modified { get; set; }
        [Required]
        public User User { get; set; }


        #endregion

        #region DTO related helper methods

        public static Message FromCreateMessageDTO(Channel channel, CreateMessageDTO model) {
            var currentTime = DateTime.Now;
           
            // Create a channel object based on the model and current time.
            return new Message { Channel = channel, Text = model.Text, Created = currentTime, Modified = currentTime };
        }

        #endregion
    }
}
