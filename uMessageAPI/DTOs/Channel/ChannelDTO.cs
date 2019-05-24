using System.ComponentModel.DataAnnotations;

namespace uMessageAPI.DTOs.Channel
{
    public class ChannelDTO
    {
        public static ChannelDTO FromChannel(uMessageAPI.Models.Channel channel) {
            return new ChannelDTO { };
        }


    }
}