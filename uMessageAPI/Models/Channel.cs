using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using uMessageAPI.DTOs.Channel;

namespace uMessageAPI.Models {
    public class Channel : Generics.IEntity {

        #region Properties
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Modified { get; set; }

        public ICollection<Member> Members { get; set; }

        public ICollection<Message> Messages { get; set; }


        #endregion

        #region DTO related helper methods

        public void UpdateFromUpdateChannelDTO(UpdateChannelDTO model) {
            this.Name = model.Name;
            // Automatically update the modified time to reflect changes.
            this.Modified = DateTime.Now;
        }

        public static Channel FromCreateChannelDTO(CreateChannelDTO model,User owner) {
            // Get the current time as we need this for created and modified to ensure
            // both contain the same value.
            var currentTime = DateTime.Now;
            // Create a channel object based on the model and current time.
            return new Channel { Name = model.Name, Created = currentTime, Modified = currentTime, Members = new [] { new Member() { Role = MemberRole.OWNER,User = owner } } };
        }

        #endregion

    }
}
