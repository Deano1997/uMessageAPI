﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uMessageAPI.Models.Generics;

namespace uMessageAPI.Models {
    public interface IMessageRepository : Generics.IEntityRepository<Message> { }
}
