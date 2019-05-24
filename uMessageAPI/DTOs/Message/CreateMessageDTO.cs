using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace uMessageAPI.DTOs.Message {
    public class CreateMessageDTO {

        [Required]
        public string Text { get; set; }
    }
}
