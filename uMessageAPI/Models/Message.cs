using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uMessageAPI.Models {
    public class Message {

        #region Properties
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public User User { get; set; }
        #endregion

    }
}
