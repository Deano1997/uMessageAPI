using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using uMessageAPI.DTOs.Channel;
using uMessageAPI.DTOs.User;

namespace uMessageAPI.DTOs.Message {
    public class MessageDTO {
        public static MessageDTO FromMessage(uMessageAPI.Models.Message model) {
            return new MessageDTO { };
        }
    }
}
