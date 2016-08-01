﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamChat.Core.Model
{
    public class User : BaseModel
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
    }
}
