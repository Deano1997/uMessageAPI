using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace uMessageAPI.DTOs.Channel
{
    public class ChannelDTO
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Modified { get; set; }

        public static ChannelDTO FromChannel(uMessageAPI.Models.Channel channel) {
            return new ChannelDTO { Id = channel.Id, Name = channel.Name, Created = channel.Created, Modified = channel.Modified };
        }


    }
}