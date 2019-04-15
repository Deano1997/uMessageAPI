﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uMessageAPI.Models {
    public class Channel {

        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        #endregion
    }
}
