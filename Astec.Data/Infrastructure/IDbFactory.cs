﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astec.Data.Infrastructure
{
    public interface IDbFactory
    {
        AstecDbContext Init();
    }
}
