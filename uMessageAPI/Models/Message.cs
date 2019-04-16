using System;
using System.ComponentModel.DataAnnotations;

namespace uMessageAPI.Models {
    public class Message : Generics.IEntity {

        #region Properties

        public Guid Id { get; set; }

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
