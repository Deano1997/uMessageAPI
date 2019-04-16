using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace uMessageAPI.Models {
    public class Channel {

        #region Properties

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Modified { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public ICollection<ChannelUser> ChannelUsers { get; set; }
        #endregion
        #region Constructor
                #endregion
    }
}
