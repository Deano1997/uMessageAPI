using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace uMessageAPI.Models {
    public class ChannelUser {
        
        public int ChannelId { get; set; }
        public Channel Channel { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
