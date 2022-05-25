﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.DAL.Entities;

namespace Transport.DAL.Interfaces.IRepositories
{
    public interface IMakeRepository : IGenericRepository<Make, int>
    {
    }
}
