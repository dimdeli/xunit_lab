﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public interface IRepositoryService
    {
        ProductItem GetProductItem(int id);
    }
}