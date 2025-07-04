﻿using Company_Management.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Management.Core.Services
{
    public interface IProductService:IService<Product>
    {
        Task IncreaseStock(Product product);
        Task DecreaseStock(Product product);
    }
}
