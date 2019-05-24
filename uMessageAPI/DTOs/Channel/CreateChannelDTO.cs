using System.ComponentModel.DataAnnotations;

namespace uMessageAPI.DTOs.Channel
{
    public class CreateChannelDTO
    {
        [Required]
        public string Name { get; set; }
    }
}