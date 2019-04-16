using System.ComponentModel.DataAnnotations;

namespace uMessageAPI.Models {
    public class ChannelUser {

        #region Properties

        public int ChannelId { get; set; }

        public Channel Channel { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public ChannelUserRole Role { get; set; }

        #endregion

    }
}
