using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace uMessageAPI.Models {
    public class Channel {

        #region Properties

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Modified { get; set; }

        public ICollection<ChannelUser> ChannelUsers { get; set; }

        #endregion
    }
}
