﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWCF.WebService.Services
{
    public class FooService : IFooService
    {
        public string Get(string str)
        {
            return str;
        }
    }
}