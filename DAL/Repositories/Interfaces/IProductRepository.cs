﻿// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {

        IEnumerable<Product> GetTopActiveProducts(int count);
        IEnumerable<Product> GetAllProductsData();

    }
}
