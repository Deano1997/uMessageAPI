using System.ComponentModel.DataAnnotations;

namespace uMessageAPI.DTOs.Channel
{
    public class UpdateChannelDTO
    {
        [Required]
        public string Name { get; set; }
    }
}