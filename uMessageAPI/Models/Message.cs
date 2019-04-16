using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace uMessageAPI.Models {
    public class Message {

        #region Properties

        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Modified { get; set; }

        public User User { get; set; }

        #endregion

    }
}
