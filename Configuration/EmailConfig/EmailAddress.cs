﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration.EmailConfig
{
    public class EmailAddress
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public static implicit operator List<object>(EmailAddress v)
        {
            throw new NotImplementedException();
        }
    }
}
