using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace uMessageAPI.Models {
    public class Channel : Generics.IEntity {

        #region Properties

        public Guid Id { get; set; }

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
