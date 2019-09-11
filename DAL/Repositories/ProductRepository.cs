// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        { }


        public IEnumerable<Product> GetTopActiveProducts(int count)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Product> GetAllProductsData()
        {
            return _appContext.Products
                .OrderBy(c => c.Name)
                .ToList();
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
